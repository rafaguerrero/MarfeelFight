using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightBuilder : MonoBehaviour {
    void Start() {
        
        // ------------ DEBUG MODE -------------
        PlayersInfo.player = "Rafa";
        PlayersInfo.enemy = "Cobas";
        // --------------------------------------


        buildPlayer();
        buildEnemy();
    }

    private void buildPlayer() {
        GameObject go = (GameObject) Instantiate(Resources.Load("Prefabs/PlayerInfo"));
        buildName(go, PlayersInfo.player);
    }

    private void buildEnemy() {
        GameObject go = (GameObject) Instantiate(Resources.Load("Prefabs/EnemyInfo"));
        buildName(go, PlayersInfo.enemy);
    }

    private void buildName(GameObject baseObject, string name) {
        foreach (Transform child in baseObject.transform) {
            GameObject childObject = child.gameObject;

            if(childObject.name == "Name") {
                childObject.GetComponent<Text>().text = name;
            } else if(childObject.name == "Image") {
                childObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Characters/" + name + "/face");
            }
        }   
    }
}
