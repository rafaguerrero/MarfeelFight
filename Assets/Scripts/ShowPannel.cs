using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPannel : MonoBehaviour, GetReady {
    public void Ready() {
        GameObject prefab = Resources.Load<GameObject>("Prefabs/AttackPannel"); 
        Vector3 pos = new Vector3(0, 0, 0);

        GameObject pannel = Instantiate(prefab, pos, Quaternion.identity);

        pannel.GetComponent<AttackPannel>().Populate(this.gameObject.GetComponent<Character>().attacks);
    }
}
