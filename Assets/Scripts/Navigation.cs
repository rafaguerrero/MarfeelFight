using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigation : MonoBehaviour, Navigator {
    public bool active = false;

    public GameObject right;
    public GameObject left;
    public GameObject up;
    public GameObject down;

    public string scriptName;
    private Navigator script;

    void Start() {
        script = GetComponent(scriptName) as Navigator;

        if(active) {
            Activate();  
        }
    }

    void Update() {
        if(active) {
            if (Input.GetKeyDown(KeyCode.LeftArrow) && left != null) {
                MoveTo(left);
            } else if(Input.GetKeyDown(KeyCode.RightArrow) && right != null) {
                MoveTo(right);
            } else if(Input.GetKeyDown(KeyCode.UpArrow) && up != null) {
                MoveTo(up);
            } else if(Input.GetKeyDown(KeyCode.DownArrow) && down != null) {
                MoveTo(down);
            } else if (Input.GetKeyDown(KeyCode.Return)) {
                Action();
            }
        }  
    }

    public void OnMouseDown() {
        Action();
    }

    void OnMouseOver() {
        if(!active) {
            NotifyDeactivation();
            Activate();
        }
    }

    private void NotifyDeactivation() {
        GameObject[] activeObjects = GameObject.FindGameObjectsWithTag("Navigation");
        
        foreach (GameObject activeObj in activeObjects) {
            activeObj.GetComponent<Navigation>().Deactivate();
        }
    }

    public void Activate() {
        active = true;
        script.Activate();
    }

    public void Deactivate() {
        active = false;
        script.Deactivate();
    }

    private void MoveTo(GameObject direction) {
        Deactivate();
        direction.GetComponent<Navigation>().Activate();
    }

    public void Action() {
        script.Action();
        Debug.Log("Action!!");
    }
}
