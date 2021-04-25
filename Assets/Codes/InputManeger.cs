using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManeger : MonoBehaviour
{
    public UnityEvent onSpace;
    public UnityEvent onShift;
    public UnityEvent onEsc;
    //public UnityEvent onClick;
    public Weapon use;

    // Start is called before the first frame update
    void Start()
    {
          
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.W)) onSpace.Invoke();
        else if(Input.GetKeyDown(KeyCode.RightShift)||Input.GetKeyDown(KeyCode.LeftShift)) onShift.Invoke();
        else if(Input.GetKeyDown(KeyCode.Escape)) onEsc.Invoke();
        else if(Input.GetMouseButtonDown(0)) OnClick();//onClick.Invoke();
    }

    public void OnClick(){
        if(Time.time<use.lastFire+use.cooltime) return;
        use.Fire();
        use.lastFire=Time.time;
    }

}
