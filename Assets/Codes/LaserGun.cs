using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaserGun : Weapon
{
    LineRenderer lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer=GetComponent<LineRenderer>();
        lineRenderer.SetColors(new Color(28/255f,48/255f,172/255f),new Color(42/255f,183/255f,255/255f));
        lineRenderer.SetWidth(0.03f,0.03f);
        reboundforce=0;
        cooltime=1f;
        lastFire=-1f;
        dmg=3;
        loc=0.8f;
    }

    public override void Update(){
        base.Update();
        
    }

    public override void Fire(){
        //base.Fire();
        lineRenderer.SetPosition(0,transform.position);
        RaycastHit2D hit=Physics2D.Raycast(transform.position,bulletDir,20f);
        Debug.DrawRay(transform.position,bulletDir*20,Color.red,0.3f);
        if(hit){
            Debug.Log(hit.point);
            lineRenderer.SetPosition(1,hit.point);
            lineRenderer.enabled=true;
            StartCoroutine(AutoDestroy());
            if(hit.transform.tag!="Enemy")return;
            hit.transform.GetComponent<Damageable>().OnDamage(dmg);
        }

    }

    IEnumerator AutoDestroy(){
        yield return new WaitForSeconds(0.5f);
        lineRenderer.enabled=false;
    }

}
