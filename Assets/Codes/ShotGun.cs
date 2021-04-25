using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotGun : Weapon
{
    // Start is called before the first frame update
    void Start()
    {
        reboundforce=10f;
        cooltime=1f;
        lastFire=-1f;
        dmg=1;
        loc=0.6f;
    }

    public override void Fire(){
        mousePos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        bulletDir=(mousePos - new Vector2(transform.position.x,transform.position.y)).normalized;
        float AngleRad=Mathf.Atan2(mousePos.y-transform.position.y,mousePos.x-transform.position.x);
        float AngleDeg=(180/Mathf.PI)*AngleRad;

        float AngleDeg2=AngleDeg+6;
        float AngleDeg3=AngleDeg-6;
        var x=bulletDir.x;
        var y=bulletDir.y;
        var t=0.10472f;
        Vector2 bulletDir2 = new Vector2(x*Mathf.Cos(t)-y*Mathf.Sin(t), x*Mathf.Sin(t)+y*Mathf.Cos(t));
        Vector2 bulletDir3 = new Vector2(x*Mathf.Cos(-1*t)-y*Mathf.Sin(-1*t), x*Mathf.Sin(-1*t)+y*Mathf.Cos(-1*t));

        
        float AngleDeg4=AngleDeg+3;
        float AngleDeg5=AngleDeg-3;
        t=0.0523599f;
        Vector2 bulletDir4 = new Vector2(x*Mathf.Cos(t)-y*Mathf.Sin(t), x*Mathf.Sin(t)+y*Mathf.Cos(t));
        Vector2 bulletDir5 = new Vector2(x*Mathf.Cos(-1*t)-y*Mathf.Sin(-1*t), x*Mathf.Sin(-1*t)+y*Mathf.Cos(-1*t));

        var prep=Instantiate(bullet, transform.position, Quaternion.Euler(0,0,AngleDeg));
        prep.GetComponent<Bullet>().Init(bulletDir,dmg);

        prep=Instantiate(bullet, transform.position, Quaternion.Euler(0,0,AngleDeg2));
        prep.GetComponent<Bullet>().Init(bulletDir2,dmg);
        prep=Instantiate(bullet, transform.position, Quaternion.Euler(0,0,AngleDeg3));
        prep.GetComponent<Bullet>().Init(bulletDir3,dmg);
        
        prep=Instantiate(bullet, transform.position, Quaternion.Euler(0,0,AngleDeg4));
        prep.GetComponent<Bullet>().Init(bulletDir4,dmg);
        prep=Instantiate(bullet, transform.position, Quaternion.Euler(0,0,AngleDeg5));
        prep.GetComponent<Bullet>().Init(bulletDir5,dmg);



        character.GetComponent<Character>().Rebound(bulletDir*-1,reboundforce);
    }

}
