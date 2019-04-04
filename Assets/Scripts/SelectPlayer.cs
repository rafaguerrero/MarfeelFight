using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPlayer : MonoBehaviour {

    public bool active = false;
    private GameObject body;
    public void Start() {
        Transform bodyTransform = transform.Find("Body");
        
        body = bodyTransform.gameObject;
        bodyTransform.position = new Vector3(-5f, -3f, 0f);
    }

    public void OnMouseDown() {
        if(!active) {
            NotifyDeactivation();
            Activate();
        }
    }

    private void NotifyDeactivation() {
        GameObject[] activeObjects = GameObject.FindGameObjectsWithTag("Active");
        
        foreach (GameObject activeObj in activeObjects) {
            activeObj.GetComponent<SelectPlayer>().Deactivate();
        }
    }

    public void Activate() {
        active = true;
        gameObject.tag = "Active";
        body.GetComponent<SpriteRenderer>().enabled = true;
    }

    public void Deactivate() {
        active = false;
        gameObject.tag = "Untagged";
        body.GetComponent<SpriteRenderer>().enabled = false;
    }
}
