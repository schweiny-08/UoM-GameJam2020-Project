using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerQuarantine : MonoBehaviour
{
    GUI gui;
    //PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        gui = GameObject.Find("GameMaster").GetComponent<GUI>();
        //playerHealth = GameObject.Find("GameMaster").GetComponent<PlayerHealth>();
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Player"){
            //playerHealth.currentHealth = playerHealth.maxHealth;
            //playerHealth.lowhealth = false;
            //playerHealth
            gui.ResetCounter();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
