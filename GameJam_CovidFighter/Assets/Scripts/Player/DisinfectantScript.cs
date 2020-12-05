using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisinfectantScript : MonoBehaviour
{

    public int damage = 1;

        void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Wall")
            Destroy(gameObject);
        else if(col.gameObject.tag == "LongRangeEnemy"){
            Debug.Log("ENEMY HIT");

            Destroy(gameObject); //Destroying the drop before enemy is destroyed (drop wont destroy if done after)

            col.gameObject.GetComponent<LongRangePersonStats>().CharacterDamage(damage);
            
        }
    }
}
