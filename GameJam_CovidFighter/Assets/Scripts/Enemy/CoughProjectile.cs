using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoughProjectile : MonoBehaviour
{
     public int damage = 1;

    public int projectileSpeed= 4;
     private Transform player;
     private Vector2 target;

    void Start(){
        player = GameObject.FindWithTag("Player").transform;

        target = player.position;
    }

    void Update(){
        transform.position = Vector2.MoveTowards(transform.position, target, projectileSpeed * Time.deltaTime);
        if((Vector2)transform.position == target)
            Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Wall")
            Destroy(gameObject);
        else if(col.gameObject.tag == "Player"){
            Debug.Log("PLAYER HIT");

            Destroy(gameObject); //Destroying the drop before enemy is destroyed (drop wont destroy if done after)

            //Hit Player
        }
    }
}
