using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public static class GameMaster {
    public static string player;
    public static GameObject playerObject;

    public static string enemy;
    public static GameObject enemyObject;

    public static List<Round> rounds;

    public static void nextRound() {
        rounds = new List<Round>();

        playerObject.GetComponent<GetReady>().Ready();
        enemyObject.GetComponent<GetReady>().Ready();
    }

    public static void selectAttack(GameObject character, Attack attack) {
        Character characterInfo = character.GetComponent<Character>();

        rounds.Add(new Round(character, calculate(characterInfo, attack)));

        if(rounds.Count == 2) {
            play();
        }
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

    private static Attack calculate(Character character, Attack attackBase) {
        Attack attack = new Attack();

        attack.damage = character.power * attackBase.damage;
        attack.heal = character.power * attackBase.heal;
        attack.speed = Random.Range(0, (character.speed * attackBase.speed));
        attack.jobPoints = attackBase.jobPoints;

        return attack;
    }

    private static void play() {
        int firstToPlay = (rounds[0].attack.speed >= rounds[1].attack.speed) ? 0 : 1;

        Round first = rounds[firstToPlay];
        Round second = rounds[(firstToPlay + 1) % 2];

        attack(first.character, second.character, first.attack);

        updateInfo(first.character);
        updateInfo(second.character);

        attack(second.character, first.character, second.attack);

        updateInfo(first.character);
        updateInfo(second.character);

        first.character.GetComponent<Character>().jobPoints += 5;
        second.character.GetComponent<Character>().jobPoints += 5;

        nextRound();
    } 

    private static void attack(GameObject origin, GameObject dest, Attack attack) {
        Character originInfo = origin.GetComponent<Character>();
        Character destInfo = dest.GetComponent<Character>();
        
        destInfo.life = Mathf.Max(0, destInfo.life - Mathf.RoundToInt(attack.damage));
        originInfo.life = Mathf.Min(originInfo.maxLive, originInfo.life + Mathf.RoundToInt(attack.heal));
        destInfo.jobPoints = Mathf.Max(0, destInfo.jobPoints - attack.jobPoints);

        if(originInfo.life == 0 || destInfo.life == 0) {
            end(destInfo.life == 0 ? origin.name : dest.name);
        }
    }

    private static void end(string winnerName) {
        Debug.Log("-------------------");
        Debug.Log("Winner is : " + winnerName);
        Debug.Log("-------------------");

        SceneManager.LoadScene("ChooseCharacter", LoadSceneMode.Single);  
    }
}
