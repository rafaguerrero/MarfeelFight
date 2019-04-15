using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightBuilder : MonoBehaviour {
    void Start() {
        // ------------ DEBUG MODE -------------
        GameMaster.player = "Cobas";
        GameMaster.enemy = "Rafa";
        // --------------------------------------

        GameMaster.playerObject = buildPlayer();
        GameMaster.enemyObject = buildEnemy();

        GameMaster.nextRound();
    }

    private GameObject buildPlayer() {
        string role = "Player";
        
        GameObject body = buildBody(GameMaster.player, role);
        body.transform.position = new Vector3(-5f, 0f, 0f);
        body.name = GameMaster.player;

        buildName(GameMaster.player, role);

        GameMaster.updateInfo(body);
        body.AddComponent<ShowPannel>();

        return body;
    }

    private GameObject buildEnemy() {
        string role = "Enemy";
        
        GameObject body = buildBody(GameMaster.enemy, role);
        body.transform.position = new Vector3(5f, 0f, 0f);
        body.transform.Rotate(0, 180, 0, Space.World);
        body.name = GameMaster.enemy;

        buildName(GameMaster.enemy, role);
        
        GameMaster.updateInfo(body);
        body.AddComponent<IA>();

        return body;
    }

    private void buildName(string name, string role) {
        GameObject baseObject = (GameObject) Instantiate(Resources.Load("Prefabs/" + role + "Info"));

        foreach (Transform child in baseObject.transform) {
            GameObject childObject = child.gameObject;

            if(childObject.name == "Name") {
                childObject.tag = role + "Info";
            } else if(childObject.name == "Image") {
                childObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Characters/" + name + "/Face");
            }
        }  
    }

    private GameObject buildBody(string name, string role) {
        GameObject prefab = Resources.Load<GameObject>("Characters/" + name + "/Character"); 
        Vector3 pos = new Vector3(0, 0, 0);

        GameObject body = Instantiate(prefab, pos, Quaternion.identity);
        body.tag = role;

        return body;
    }
}
