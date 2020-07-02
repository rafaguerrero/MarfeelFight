using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defend : AbstractOption {
    
    public override void Initialize() {
        Debug.Log ("Initialize - Defend");
    }

    public override void TaskOnClick() {
       Debug.Log ("Defend");
    }
}
