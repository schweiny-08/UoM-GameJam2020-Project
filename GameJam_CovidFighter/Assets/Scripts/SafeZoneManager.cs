using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZoneManager : MonoBehaviour
{

    public PlayerHealth playerhealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            //some script to rotate enemy
        }

        if(col.gameObject.tag == "Player")
        {
            if (playerhealth.lowhealth)
            {
                playerhealth.lowhealth = false;
                playerhealth.timeTaken = 0;
                playerhealth.currentHealth = playerhealth.maxHealth;
                Debug.Log("Health Restored");
            }
        }
    }
}
