using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectPlayer : MonoBehaviour, Navigator {
    public GameObject body;
    
    public void Start() {
        body.transform.position = new Vector3(-5f, -3f, 0f);
    }

    public void Activate() {
        body.GetComponent<SpriteRenderer>().enabled = true;
    }

    public void Deactivate() {
        body.GetComponent<SpriteRenderer>().enabled = false;
    }

    public void Action() {
        Debug.Log("Move to next Sceen");

        PlayersInfo.player = this.gameObject.name;
        PlayersInfo.enemy = SelectEnemy(this.gameObject.name);


        Debug.Log("Playing with " + PlayersInfo.player + " VS " + PlayersInfo.enemy);

        SceneManager.LoadScene("Fight", LoadSceneMode.Single);  
    }

    private string SelectEnemy(string playerSelectedName) {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Navigation");
        List<string> selectablePlayers = new List<string>();
        
        foreach (GameObject player in players) {
            if(player.name != playerSelectedName) {
                selectablePlayers.Add(player.name);
            }
        }

        return selectablePlayers[Random.Range(0, selectablePlayers.Count - 1)];
    }
}
