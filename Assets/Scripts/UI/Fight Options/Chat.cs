using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chat : AbstractOption {
    
    public override void Initialize() {
        Debug.Log ("Initialize - Chat");
    }

    public override void TaskOnClick() {
       Debug.Log ("Chat");
    }
}
