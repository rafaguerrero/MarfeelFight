using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class AbstractOption : MonoBehaviour {
    
    public void Start() {
        Button btn = this.gameObject.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);

        Initialize();
	}

	public virtual void Initialize() {
       Debug.Log ("Original Initialize");
    }

	public virtual void TaskOnClick() {
       Debug.Log ("Original Task");
    }
}
