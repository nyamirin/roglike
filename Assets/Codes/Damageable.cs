using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public int hp;
    public int def;

    public GameObject hudDamageText;
    public Transform hudPos;
    
    public void OnDamage(int dmg){
        //int realdmg= (int)((10f/(10f+(float)def))*(float)dmg);
        int realdmg=dmg-def;
        if(realdmg<=0) realdmg=1;
        hp-=realdmg;
        GameObject hudText = Instantiate(hudDamageText);
        hudText.transform.position=hudPos.position;
        hudText.transform.Translate(new Vector3(Random.Range(-0.4f, 0.4f), 0, 0));
        hudText.GetComponent<DamageText>().damage=realdmg;
        
    }
}
