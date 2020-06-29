using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TapToNextSceen : MonoBehaviour {
	void Start() {
        Button btn = this.gameObject.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick() {
		Debug.Log("Clicked!!!");

        //SceneManager.LoadScene("ChooseCharacter", LoadSceneMode.Single);  
	}
}
