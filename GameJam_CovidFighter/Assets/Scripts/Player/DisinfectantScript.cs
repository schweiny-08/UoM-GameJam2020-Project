using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisinfectantScript : MonoBehaviour
{
        void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Wall")
            Destroy(gameObject);
        else if(col.gameObject.tag == "LongRangeEnemy"){
            Debug.Log("ENEMY HIT");
            Destroy(gameObject);
        }
    }
}
