using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;

    private Rigidbody2D rb;
    private bool isDead; //---!!Temporary till playerHealth script is made !!---
    private float velocity;
    
    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() { 
    
    }

    //Fixed Update functiion for physics related stuffs
    void FixedUpdate()
    {
        if (!isDead) {
            //Left-Right
            if (Input.GetKey(KeyCode.A))
            {
                rb.velocity = new Vector2(-speed, 0);
            }else if (Input.GetKey(KeyCode.D)){
                rb.velocity = new Vector2(speed, 0);
            } 
            //Down-Up
            else if (Input.GetKey(KeyCode.S)){
                rb.velocity = new Vector2(0, -speed);
            } else if (Input.GetKey(KeyCode.W)){
                rb.velocity = new Vector2(0, speed);
            }
            else
            {
                rb.velocity = new Vector2(0, 0);
            }

        }
    }

    
}
