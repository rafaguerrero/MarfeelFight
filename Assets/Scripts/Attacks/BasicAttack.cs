using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : MonoBehaviour, Attack {
    public float getDamage() {
        return 1f;
    }

    public float getHeal() {
        return 0f;
    }

    public float getSpeed() {
        return 1f;
    }

    public float getJobPoints() {
        return 0f;
    }

    public string getDescription() {
        return "This is a basic attack";
    }

    public string getName() {
        return "Basic Attack";
    }
}
