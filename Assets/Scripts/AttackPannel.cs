using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackPannel : MonoBehaviour {
    private void Start() {
        GameObject[] camera = GameObject.FindGameObjectsWithTag("MainCamera");
        this.gameObject.GetComponent<Canvas>().worldCamera = camera[0].GetComponent<Camera>();   
    }

    private Transform GetParent() {
        return this.gameObject.transform.GetChild(0).transform.GetChild(0).transform;
    }

    private GameObject CreateAttack(GameObject prefab, GameObject attack, Transform attacksPannel, Vector3 position) {
        GameObject instance = (GameObject) Instantiate(prefab, new Vector3(0,0,0), Quaternion.identity);
        Attack attackInfo = attack.GetComponent<Attack>();

        string text = attackInfo.name;

        if(attackInfo.jobPoints > 0) {
            text += (" - " + attackInfo.jobPoints);
        }

        instance.GetComponent<Text>().text =  text;

        instance.transform.parent = attacksPannel;
        instance.transform.localScale = new Vector3(1f, 1f, 1f);
        instance.transform.localPosition = position;

        return instance;
    }

    public void Populate(List<GameObject> attacks) {
        Transform attacksPannel = GetParent();
        GameObject prefab = Resources.Load<GameObject>("Prefabs/AttackUI"); 
        Vector3 position = new Vector3(-100f, 350f, 0);
        GameObject lastAttackObject = null;

        foreach (GameObject attack in attacks) {
            position.y -= 100;
            GameObject attackObject = CreateAttack(prefab, attack, attacksPannel, position);
            attackObject.GetComponent<AttackUI>().attack = attack.GetComponent<Attack>();

            if(lastAttackObject == null) {
                attackObject.GetComponent<Navigation>().active = true;
            } else {
                lastAttackObject.GetComponent<Navigation>().down = attackObject;
                attackObject.GetComponent<Navigation>().up = lastAttackObject;
            }

            lastAttackObject = attackObject;
        }
    }
}

