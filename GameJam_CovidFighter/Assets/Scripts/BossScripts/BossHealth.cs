using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int startHealth = 200;
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        health = startHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0){
            //Boss Dies
        }
    }

    public void TakeDamage(int damage){
        health -= damage;
        Debug.Log(health);
    }
}
