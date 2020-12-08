using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisinfectantScript : MonoBehaviour
{

    public int damage;
    public ParticleSystem popParticles;

        private void Start()
    {
        damage = GameObject.Find("GameMaster").GetComponent<PlayerHealth>().attackDamage;
    }


    void OnCollisionEnter2D(Collision2D col){
        if (col.gameObject.tag == "Wall")
        {
            Instantiate(popParticles, this.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if (col.gameObject.tag == "LongRangeEnemy")
        {
            Debug.Log("ENEMY HIT");
            Instantiate(popParticles, this.transform.position, Quaternion.identity);
            Destroy(gameObject); //Destroying the drop before enemy is destroyed (drop wont destroy if done after)
            col.gameObject.GetComponent<LongRangePersonStats>().CharacterDamage(damage);

        }
        else if (col.gameObject.tag == "MeleeEnemy")
        {
            Debug.Log("ENEMY HIT");
            Instantiate(popParticles, this.transform.position, Quaternion.identity);
            Destroy(gameObject); //Destroying the drop before enemy is destroyed (drop wont destroy if done after)

            col.gameObject.GetComponent<ShortRangePersonStats>().CharacterDamage(damage);
        }
        else if (col.gameObject.name == "CovidBoss")
        {
            Debug.Log("BossHit");

            col.gameObject.GetComponent<BossHealth>().TakeDamage(damage);
            Instantiate(popParticles, this.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
     }
}
