using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit : AbstractOption {
    
    public override void Initialize() {
        Debug.Log ("Initialize - Quit");
    }

    public override void TaskOnClick() {
       SceneManager.LoadScene("Main", LoadSceneMode.Single);  
    }
}