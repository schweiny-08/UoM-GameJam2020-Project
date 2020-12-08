using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoughProjectile : MonoBehaviour
{
     public int damage = 1;

    public int projectileSpeed= 4;
    public ParticleSystem popParticles;

    private Transform player;
     private Vector2 target;

    private PlayerHealth playerHealth;

    void Start(){
        player = GameObject.FindWithTag("Player").transform;

        playerHealth = GameObject.Find("GameMaster").GetComponent<PlayerHealth>();

        target = player.position;

        TrailRenderer trail = this.GetComponent<TrailRenderer>();
        trail.sortingLayerName = "Projectile";
        trail.sortingOrder = 2;
    }

    void Update(){
        transform.position = Vector2.MoveTowards(transform.position, target, projectileSpeed * Time.deltaTime);
        if ((Vector2)transform.position == target)
        {
            Instantiate(popParticles, this.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Wall")
            Destroy(gameObject);
        else if(col.gameObject.tag == "Player"){
            Debug.Log("PLAYER HIT");
            playerHealth.OnDamageTaken(damage);
            Instantiate(popParticles, this.transform.position, Quaternion.identity);
            Destroy(gameObject); //Destroying the drop before enemy is destroyed (drop wont destroy if done after)
        }else if(col.gameObject.tag == "Barrier"){
            Destroy(gameObject);
        }
    }
}
