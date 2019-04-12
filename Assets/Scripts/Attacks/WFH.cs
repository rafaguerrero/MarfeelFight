using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WFH : MonoBehaviour, Attack {
    public float getDamage() {
        return 0.5f;
    }

    public float getHeal() {
        return 0.2f;
    }

    public float getSpeed() {
        return 1f;
    }

    public float getJobPoints() {
        return 0f;
    }

    public string getDescription() {
        return "Working From Home enables you to recover life and attack at the same time";
    }

    public string getName() {
        return "WFH";
    }
}
