using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    protected float reboundforce;
    public float cooltime;
    public float lastFire;
    protected int dmg;
    protected float loc;
    
    

    protected Vector2 mousePos;
    protected Vector2 bulletDir;
    public GameObject bullet;
    public GameObject character;

    // Update is called once per frame
    public virtual void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        bulletDir=(mousePos - new Vector2(character.transform.position.x,character.transform.position.y)).normalized;
        transform.position= bulletDir*loc + new Vector2(character.transform.position.x,character.transform.position.y);
        float AngleRad=Mathf.Atan2(mousePos.y-character.transform.position.y,mousePos.x-character.transform.position.x);
        float AngleDeg=(180/Mathf.PI)*AngleRad;
        if(-90<AngleDeg&&AngleDeg<=90){
            transform.localScale=new Vector3(1,1,1);
            transform.rotation=Quaternion.Euler(0,0,AngleDeg-45);
        }
        else{
            transform.localScale=new Vector3(-1,1,1);
            transform.rotation=Quaternion.Euler(0,0,AngleDeg-135);
        }
    }

    public virtual void Fire(){
        //mousePos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        //bulletDir=(mousePos - new Vector2(transform.position.x,transform.position.y)).normalized;
        //Debug.Log(bulletDir);
        float AngleRad=Mathf.Atan2(mousePos.y-character.transform.position.y,mousePos.x-character.transform.position.x);
        float AngleDeg=(180/Mathf.PI)*AngleRad;
        Debug.Log(AngleDeg);

        var prep=Instantiate(bullet, transform.position, Quaternion.Euler(0,0,AngleDeg));
        prep.GetComponent<Bullet>().Init(bulletDir,dmg);
        character.GetComponent<Character>().Rebound(bulletDir*-1,reboundforce);
    }

}
