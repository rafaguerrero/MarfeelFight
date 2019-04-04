using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blink : MonoBehaviour {
    public bool state;
    public float offDuration = 0.5f;
    public float onDuration = 1f;
    private float nextSwitch;

    void Update(){
        if(Time.time > nextSwitch){
            state = !state;
            nextSwitch += (state ? onDuration : offDuration);
            GetComponent<Text>().enabled = state;
        }
    }
}
