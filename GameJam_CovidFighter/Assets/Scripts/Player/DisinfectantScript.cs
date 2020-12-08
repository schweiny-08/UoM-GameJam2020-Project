using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisinfectantScript : MonoBehaviour
{

    public int damage;

        private void Start()
    {
        damage = GameObject.Find("GameMaster").GetComponent<PlayerHealth>().attackDamage;
    }


    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Wall")
            Destroy(gameObject);
        else if(col.gameObject.tag == "LongRangeEnemy"){
            Debug.Log("ENEMY HIT");

            Destroy(gameObject); //Destroying the drop before enemy is destroyed (drop wont destroy if done after)

            col.gameObject.GetComponent<LongRangePersonStats>().CharacterDamage(damage);
            
        }else if(col.gameObject.tag == "MeleeEnemy"){
            Debug.Log("ENEMY HIT");

            Destroy(gameObject); //Destroying the drop before enemy is destroyed (drop wont destroy if done after)

            col.gameObject.GetComponent<ShortRangePersonStats>().CharacterDamage(damage);
        }else if(col.gameObject.name == "CovidBoss"){
            Debug.Log("BossHit");

            col.gameObject.GetComponent<BossHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }else if(col.gameObject.tag == "Barrier"){
            Destroy(gameObject);
        }
     }
}
