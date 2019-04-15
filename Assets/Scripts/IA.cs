using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA : MonoBehaviour, GetReady {
    public void Ready() {
        Character character = this.gameObject.GetComponent<Character>();

        List<Attack> selectableAttacks = new List<Attack>();
        
        foreach (GameObject attacks in character.attacks) {
            Attack attackObject = attacks.GetComponent<Attack>();

            if(attackObject.jobPoints <= character.jobPoints) {
                selectableAttacks.Add(attackObject);
            }
        }

        Attack attack = selectableAttacks[Random.Range(0, selectableAttacks.Count - 1)];

        GameMaster.selectAttack(this.gameObject, attack);
    }
}
