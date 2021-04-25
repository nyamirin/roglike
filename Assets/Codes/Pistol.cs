using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pistol : Weapon
{
    // Start is called before the first frame update
    void Start()
    {
        reboundforce=3f;
        cooltime=0.3f;
        lastFire=-0.3f;
        dmg=3;
        loc=0.8f;
    }

    public override void Fire(){
        base.Fire();
    }

}
