using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Character : MonoBehaviour
{

    //수치 설정
    float gravity=10f;
    float moveSpeed=4f;
    float jumpForce=3f;
    int maxJumpCount=2;
    int maxStamina=10;
    int nowStamina=10;
    int dashCost=1;
    

    //체크
    public bool isGrounded=false;
    int jumpcount=0;
    float lastLook=0;


    //물리
    float xinput=0;

    float yvel=0;
    float xvel=0;
    Vector2 Movedir;

    public float yvel_g=0;
    float xvel_m=0;
    float xvel_d=0;
    float xvel_r=0;



    //컴포넌트
    Rigidbody2D rigid;
    public GameObject dashEffect;
    Animator animator;
    
    

    // Start is called before the first frame update
    void Start()
    {
        rigid=GetComponent<Rigidbody2D>();
        animator=GetComponent<Animator>();
    }

    void Update(){
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Check_Grounded();
        xinput=Input.GetAxisRaw("Horizontal");
        if(xinput!=0) lastLook=xinput; 
        xvel_m=xinput;
        if(!isGrounded){
            yvel_g-=gravity*Time.deltaTime;
        }
        else{
            yvel_g=0;
        }
        yvel=yvel_g;
        xvel=xvel_m*moveSpeed+xvel_d+xvel_r;

        Movedir=new Vector2(xvel,yvel);
        rigid.velocity=Movedir;
    }
    
    //키입력
    public void Jump(){
        if(jumpcount<maxJumpCount){
            jumpcount++;
            yvel_g+=jumpForce;
            isGrounded=false;
            animator.SetBool("isGround",false);
        }
    }

    public void Dash(){
        if(nowStamina>=dashCost){
            dashEffect.SetActive(true);
            //nowStamina-=dashCost;
            gravity=0f;
            yvel_g=0;
            xvel_d=lastLook*(15-moveSpeed);
            StartCoroutine(DashEnd());
        }
    }
    IEnumerator DashEnd(){
        yield return new WaitForSeconds(0.1f);
        gravity=10f;
        xvel_d=0;
        dashEffect.SetActive(false);
    }


    //물리
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag=="Ground"){
            foreach(ContactPoint2D col in collision.contacts){
                if(col.normal.y==1){//바닥
                    jumpcount=0;
                    isGrounded=true;
                    animator.SetBool("isGround",true);
                }
            }
        }
    }
    void OnCollisionExit2D(Collision2D collision){
        if(collision.gameObject.tag=="Ground"){
            foreach(ContactPoint2D col in collision.contacts){
                //Debug.Log(col.normal);
                if(col.normal.y==1){
                    isGrounded=false;
                    animator.SetBool("isGround",false);
                }
            }
        }
    }
    
    public void Rebound(Vector2 dir, float force){
        if(isGrounded){
            xvel_r+=dir.x*force;
            yvel_g+=dir.y*force*0.1f;
            StartCoroutine(Grounddrag());
        }
        else{
            xvel_r+=dir.x*force*0.5f;
            yvel_g+=dir.y*force*0.2f;

            StartCoroutine(Airdrag());
        }
    }
    IEnumerator Grounddrag(){
        yield return new WaitForSeconds(0.1f);
        xvel_r=0;
    }
    IEnumerator Airdrag(){
        while(!isGrounded){
            yield return null;
        }
        StartCoroutine(Grounddrag());
    }
    
    
    

       
}
