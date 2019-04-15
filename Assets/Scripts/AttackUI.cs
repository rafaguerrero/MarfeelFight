using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackUI : MonoBehaviour, Navigator {
    
    private GameObject arrow = null;
    public Attack attack;

    public void CreateArrow() {
        arrow = (GameObject) Instantiate(Resources.Load<GameObject>("Prefabs/SelectionArrow"), 
                                            new Vector3(0,0,0), 
                                            Quaternion.identity);

        arrow.transform.SetParent(this.gameObject.transform);
        arrow.transform.localScale = new Vector3(20f, 20f, 1f);
        arrow.transform.localPosition = new Vector3(-480f, 0f, -1f);
    }

    public void Activate() {
        if(arrow == null) CreateArrow();

        arrow.GetComponent<SpriteRenderer>().enabled = true;
    }

    public void Deactivate() {
        if(arrow == null) CreateArrow();

        arrow.GetComponent<SpriteRenderer>().enabled = false;
    }

    public void Action() {
        GameObject pannel = GameObject.FindGameObjectsWithTag("Pannel")[0];
        Destroy(pannel);

        GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];
        GameMaster.selectAttack(player, attack);
    }
}
