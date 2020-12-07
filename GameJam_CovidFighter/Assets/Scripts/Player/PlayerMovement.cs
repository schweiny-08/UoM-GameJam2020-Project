using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private bool isDead; //---!!Temporary till playerHealth script is made !!---
    private float velocity;
    private Animator anim;

    //Variables for player rotate with mouse
    private Transform playerPos;
    Vector2 mousePos;
    public float angle;

    private Transform firePoint;

    //public AudioClip cityWalk;
    private AudioSource audio;
    
    // Start is called before the first frame update
    void Start()
    {
        //setting the speed at the start of a level to the speed 
        speed = GameObject.Find("GameMaster").GetComponent<PlayerHealth>().playerSpeed;

        isDead = false;
        rb = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

        //Player rotate with mouse
        playerPos = GetComponent<Transform>();

        firePoint = GameObject.Find("FirePoint").GetComponent<Transform>();

        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        //Player rotate with mouse

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Debug.DrawRay(firePoint.position, firePoint.up, Color.blue);

        Vector2 mouseDir = mousePos - rb.position;
        angle = ((Mathf.Atan2(mouseDir.y, mouseDir.x) / Mathf.PI) * 180f) - 135f;//* Mathf.Rad2Deg;
        if (angle < 0)
            angle += 360f;
        
        //Debug.Log(angle);

        //Rotates the fire point according to the mouse position
        firePoint.rotation = Quaternion.Euler(0,0, angle+45f);
        Debug.DrawRay(firePoint.position, firePoint.up, Color.blue);


        if (angle >= 0f && angle <= 90f) {
            //Debug.Log("LEFT");
            anim.SetBool("isUp", false);
            anim.SetBool("isLeft", true);
            anim.SetBool("isRight", false);
            anim.SetBool("isDown", false);

            firePoint.position = new Vector2((playerPos.position.x-0.1f), firePoint.position.y);//Changes firepoint position according to bottle on animation
            
        } else if (angle > 90F && angle <= 180F) {
            //Debug.Log("DOWN");
            anim.SetBool("isUp", false);
            anim.SetBool("isLeft", false);
            anim.SetBool("isRight", false);
            anim.SetBool("isDown", true);

            firePoint.position = new Vector2((playerPos.position.x-0.15f), firePoint.position.y);//Changes firepoint position according to bottle on animation

        } else if (angle > 180f && angle <= 270f) {
            //Debug.Log("RIGHT");
            anim.SetBool("isUp", false);
            anim.SetBool("isLeft", false);
            anim.SetBool("isRight", true);
            anim.SetBool("isDown", false);

            firePoint.position = new Vector2((playerPos.position.x + 0.1f), firePoint.position.y);//Changes firepoint position according to bottle on animation

        } else if (angle > 270f && angle <= 359.999) {
            //Debug.Log("UP");
            anim.SetBool("isUp", true);
            anim.SetBool("isLeft", false);
            anim.SetBool("isRight", false);
            anim.SetBool("isDown", false);
        
            firePoint.position = new Vector2((playerPos.position.x + 0.15f), firePoint.position.y);//Changes firepoint position according to bottle on animation
           
        }
    }

    //Fixed Update functiion for movement
    void FixedUpdate()
    {
        if (!isDead) {
            //Left-Right
            if (Input.GetKey(KeyCode.A))
            {
                anim.SetBool("isUp", false);
                anim.SetBool("isLeft", true);
                anim.SetBool("isRight", false);
                anim.SetBool("isDown", false);

                anim.SetBool("isWalking", true);

                rb.velocity = new Vector2(-speed, 0);
            }else if (Input.GetKey(KeyCode.D)){
                rb.velocity = new Vector2(speed, 0);

                anim.SetBool("isUp", false);
                anim.SetBool("isLeft", false);
                anim.SetBool("isRight", true);
                anim.SetBool("isDown", false);

                anim.SetBool("isWalking", true);
            } 
            //Down-Up
            else if (Input.GetKey(KeyCode.S)){
                rb.velocity = new Vector2(0, -speed);

                anim.SetBool("isUp", false);
                anim.SetBool("isLeft", false);
                anim.SetBool("isRight", false);
                anim.SetBool("isDown", true);

                anim.SetBool("isWalking", true);

            } else if (Input.GetKey(KeyCode.W)){
                rb.velocity = new Vector2(0, speed);

                anim.SetBool("isUp", true);
                anim.SetBool("isLeft", false);
                anim.SetBool("isRight", false);
                anim.SetBool("isDown", false);

                anim.SetBool("isWalking", true);

            }
            else //If no directional key is pressed
            {
                rb.velocity = new Vector2(0, 0);
                anim.SetBool("isWalking", false);
            }

            if(anim.GetBool("isWalking")){
                if(!audio.isPlaying)
                    audio.Play();
            }
            else
                audio.Stop();
        }
    }
}
