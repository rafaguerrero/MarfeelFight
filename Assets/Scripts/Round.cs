using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Round {
    public GameObject character;
    public Attack attack;
     
    public Round(GameObject character, Attack attack) {
        this.character = character;
        this.attack = attack;
    }
}
