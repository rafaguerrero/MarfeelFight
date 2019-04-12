using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Attack {
    float getDamage();
    float getHeal();
    float getSpeed();
    float getJobPoints();
    string getDescription();
    string getName();
}
