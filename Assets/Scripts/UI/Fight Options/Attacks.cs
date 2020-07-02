using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : AbstractOption {

    public override void Initialize() {
        Debug.Log ("Initialize - Show attacks");
    }

    public override void TaskOnClick() {
       Debug.Log ("Show attacks");
    }
}
