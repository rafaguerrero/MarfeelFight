using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AttackButton : MonoBehaviour, Navigator {
    public Attack attack;
    private GameObject player;

    public void Start() {
        Debug.Log("Creating attack " + attack.name);
        GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];

        Button btn = this.gameObject.GetComponent<Button>();
		btn.onClick.AddListener(SelectAttack);
    }

    public void Activate() {
        Debug.Log("Active -> " + attack.name);
    }

    public void Deactivate() {
        Debug.Log("Deactive -> " + attack.name);
    }

    public void Action() {
        GameMaster.selectAttack(player, attack);
    }

	private void SelectAttack() {
		Debug.Log("Attack Selected -> " + attack.name);
	}
}