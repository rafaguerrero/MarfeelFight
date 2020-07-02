using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowFightUI : MonoBehaviour, GetReady {
    
    GameObject pannel;

    IEnumerator waiter() {
        yield return new WaitForSeconds(2);
        
        //pannel.GetComponent<BattleUI>().Populate(this.gameObject.GetComponent<Character>().attacks);
    }

    private void FixPannel(Transform transform) {
        GameObject canvas = GameObject.FindGameObjectsWithTag("Canvas")[0];
        pannel.transform.parent = canvas.transform;

        Vector3 scale = transform.localScale;
        scale.Set(1, 1, 1);
        pannel.transform.localScale = scale;
    }
    
    public void Ready() {
        GameObject prefab = Resources.Load<GameObject>("Prefabs/BattleUI") as GameObject;
        pannel = Instantiate(prefab, new Vector3(0,0,0), Quaternion.identity);

        FixPannel(pannel.transform);

        StartCoroutine(waiter());
    }
}
