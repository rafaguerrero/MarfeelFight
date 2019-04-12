using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class GameMaster {
    public static string player;
    public static GameObject playerObject;

    public static string enemy;
    public static GameObject enemyObject;
    

    public static void nextRound() {
        playerObject.GetComponent<GetReady>().Ready();
        enemyObject.GetComponent<GetReady>().Ready();
    }

    public static void attack(GameObject origin, GameObject attack, List<GameObject> buffs) {
        Debug.Log(origin.name);
        Debug.Log(attack.name);
    }

    public static void updateInfo(GameObject character) {
        GameObject[] infos = GameObject.FindGameObjectsWithTag(character.tag + "Info");
        Character characterInfo = character.GetComponent<Character>();

        foreach (GameObject info in infos) {            
            info.GetComponent<Text>().text = characterInfo.name + "\n" + 
                                                "HP : " + characterInfo.life + " / " + characterInfo.maxLive + "\n" + 
                                                "JP : " + characterInfo.jobPoints + " / " + characterInfo.maxJobPoints;
        }
    }
}
