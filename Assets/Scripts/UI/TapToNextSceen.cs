using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TapToNextSceen : MonoBehaviour {
	public string nextSceenName;

	void Start() {
        Button btn = this.gameObject.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick() {
		SceneManager.LoadScene(nextSceenName, LoadSceneMode.Single);  
	}
}
