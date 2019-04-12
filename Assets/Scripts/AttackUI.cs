using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackUI : MonoBehaviour, Navigator {
    
    public void Activate() {
        Debug.Log("Activate -> " + this.gameObject.name);
    }

    public void Deactivate() {
        Debug.Log("Deactivate -> " + this.gameObject.name);
    }

    public void Action() {
        Debug.Log("Action -> " + this.gameObject.name);
    }
}
