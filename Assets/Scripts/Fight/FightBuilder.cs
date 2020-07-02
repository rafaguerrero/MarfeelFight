using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightBuilder : MonoBehaviour {
    public static string player = "Rafa";
    public static string enemy = "Cobas";
    
    private GameObject ring;
    private GameObject canvas;

    void Start() {
        ring = GameObject.FindGameObjectsWithTag("Ring")[0];
        canvas = GameObject.FindGameObjectsWithTag("Canvas")[0];

        GameMaster.playerObject = buildPlayer();
        GameMaster.enemyObject = buildEnemy();

        GameMaster.nextRound();
    }

    private GameObject buildPlayer() {
        string role = "Player";
        
        GameObject body = buildBody(player, role);
        body.transform.position = new Vector3(-5f, 0f, 0f);
        body.name = player;

        buildName(player, role);

        GameMaster.updateInfo(body);
        body.AddComponent<ShowFightUI>();

        return body;
    }

    private GameObject buildEnemy() {
        string role = "Enemy";
        
        GameObject body = buildBody(enemy, role);
        body.transform.position = new Vector3(5f, 0f, 0f);
        body.transform.Rotate(0, 180, 0, Space.World);
        body.name = enemy;

        buildName(enemy, role);
        
        GameMaster.updateInfo(body);
        body.AddComponent<IA>();

        return body;
    }

    private void buildName(string name, string role) {
        GameObject baseObject = (GameObject) Instantiate(Resources.Load("Prefabs/" + role + "Info"));
        baseObject.transform.parent = canvas.transform;

        foreach (Transform child in baseObject.transform) {
            GameObject childObject = child.gameObject;

            if(childObject.name == "Name") {
                childObject.tag = role + "Info";
            } else if(childObject.name == "Image") {
                childObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Characters/" + name + "/face");
            }
        }  
    }

    private GameObject buildBody(string name, string role) {
        GameObject prefab = Resources.Load<GameObject>("Characters/" + name + "/Character"); 
        Vector3 pos = new Vector3(0, 0, 0);

        GameObject body = Instantiate(prefab, pos, Quaternion.identity);
        body.tag = role;
        body.transform.parent = ring.transform;

        return body;
    }
}
