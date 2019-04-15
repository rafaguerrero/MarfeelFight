using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPannel : MonoBehaviour, GetReady {
    
    GameObject pannel;

    IEnumerator waiter() {
        yield return new WaitForSeconds(2);
        
        pannel.GetComponent<AttackPannel>().Populate(this.gameObject.GetComponent<Character>().attacks);
        pannel.GetComponent<Canvas>().enabled = true;
    }
    
    public void Ready() {
        GameObject prefab = Resources.Load<GameObject>("Prefabs/AttackPannel");
        pannel = Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);

        StartCoroutine(waiter());
    }
}
