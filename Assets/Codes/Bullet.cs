using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float bulletSpeed = 5;
    int dmg;
    Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AutoDestroy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init(Vector2 dir, int d){
        rigid=GetComponent<Rigidbody2D>();
        rigid.velocity=dir*bulletSpeed;
        dmg=d;
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag=="Ground"){
            Destroy(gameObject);
        }
        if(collider.gameObject.tag=="Enemy"){
            collider.gameObject.GetComponent<Damageable>().OnDamage(dmg);
            Destroy(gameObject);
        }

    }
    
    IEnumerator AutoDestroy(){
        yield return new WaitForSeconds(3f);
            Destroy(gameObject);

    }
}
