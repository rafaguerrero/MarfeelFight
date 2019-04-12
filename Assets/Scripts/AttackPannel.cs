using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackPannel : MonoBehaviour {
    
    private void UpdateCamera() {
        GameObject[] camera = GameObject.FindGameObjectsWithTag("MainCamera");
        this.gameObject.GetComponent<Canvas>().worldCamera = camera[0].GetComponent<Camera>();   
    }

    private Transform GetParent() {
        return this.gameObject.transform.GetChild(0).transform.GetChild(0).transform;
    }

    private void CreateAttack(GameObject prefab, GameObject attack, Transform attacksPannel, Vector3 position) {
        GameObject instance = (GameObject) Instantiate(prefab, attacksPannel.position, Quaternion.identity);
        Attack attackInfo = attack.GetComponent<Attack>();

        string text = attackInfo.getName();

        if(attackInfo.getJobPoints() > 0) {
            text += (" - " + attackInfo.getJobPoints());
        }

        instance.GetComponent<Text>().text =  text;

        instance.transform.parent = attacksPannel;
        instance.transform.localScale = new Vector3(1f, 1f, 1f);
        instance.transform.position += position;
    }

    public void Populate(List<GameObject> attacks) {
        Transform attacksPannel = GetParent();
        GameObject prefab = Resources.Load<GameObject>("Prefabs/AttackUI"); 
        Vector3 position = new Vector3(-50, 85, 0);

        foreach (GameObject attack in attacks) {
            position.y -= 25;
            CreateAttack(prefab, attack, attacksPannel, position);
        }
    }
}

