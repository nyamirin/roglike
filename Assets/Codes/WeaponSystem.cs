using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponSystem : MonoBehaviour
{
    public List<GameObject> weaponList = new List<GameObject>();
    float changeCoolTime=3f;
    float lastChange=-3f;
    int use=1;
    public InputManeger inpmng;
    // Start is called before the first frame update
    void Start()
    {
        inpmng.use=weaponList[use-1].GetComponent<Weapon>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            if(Time.time>=lastChange+changeCoolTime && use!=1){
                Change_Weapon(1);
            }
        }
        if(Input.GetKeyDown(KeyCode.Alpha2)){
            if(Time.time>=lastChange+changeCoolTime && use!=2){
                Change_Weapon(2);
            }
        }
        if(Input.GetKeyDown(KeyCode.Alpha3)){
            if(Time.time>=lastChange+changeCoolTime && use!=3){
                Change_Weapon(3);
            }
        }
    }
    private void Change_Weapon(int i){
        weaponList[i-1].SetActive(true);
        inpmng.use=weaponList[i-1].GetComponent<Weapon>();
        weaponList[use-1].SetActive(false);
        use=i;
    }
}
