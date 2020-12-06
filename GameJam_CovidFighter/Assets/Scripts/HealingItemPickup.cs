using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingItemPickup : MonoBehaviour
{
    public int heal = 1;
    PlayerHealth ph;

    // Start is called before the first frame update
    void Start()
    {
        ph = GameObject.Find("GameMaster").GetComponent<PlayerHealth>();
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Player" && ph.currentHealth < ph.maxHealth){
            
            Debug.Log("HELLO");

            ph.OnHealthIncreased(heal);

            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
