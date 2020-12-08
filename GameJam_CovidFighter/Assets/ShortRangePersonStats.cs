using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShortRangePersonStats : MonoBehaviour
{
    public float speed = 3f;
    public float followDistance = 30f;
    public float health = 3f;
    public float attackCooldown = 2f;

    public GameObject curedPersonPrefabVarient;
    public Slider healthSlider;
    public ParticleSystem attackParticles;

    private float maxhealth;

    private int damage;
    private PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        maxhealth = health;
        healthSlider.value = health / maxhealth;

        playerHealth = GameObject.Find("GameMaster").GetComponent<PlayerHealth>();
        damage = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*
        if (collision.gameObject.tag == "hurtEnemy")
        {
            health--;
            healthSlider.value = health / maxhealth;
            if (health == 0)
            {
                //diabling sprite and collisions now and waiting 2 seconds to destroy object to give time to play death effects/ sound effects
                this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                healthSlider.GetComponentInParent<Canvas>().enabled = false;
                //Destroy(healthSlider);

                //spawn one of the normal people depending on the prefab given
                Instantiate(curedPersonPrefabVarient, this.transform.position, Quaternion.identity);

                //wait to destroy
                StartCoroutine(DestroyObjectAfterWait(2f));
            }     
        }
        */

        if (collision.gameObject.tag == "Player")
        {
            this.GetComponent<Animator>().SetBool("WaitAfterAttack", true);
            StartCoroutine(AttackCooldown(attackCooldown));
            attackParticles.Play();

            playerHealth.OnDamageTaken(damage);

            Debug.Log("PLAYER HIT");
        }
    }

    public void CharacterDamage(int damageTaken){
        health -= damageTaken;
            healthSlider.value = health / maxhealth;
            if (health <= 0)
            {
                //diabling sprite and collisions now and waiting 2 seconds to destroy object to give time to play death effects/ sound effects
                this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                healthSlider.GetComponentInParent<Canvas>().enabled = false;
                //Destroy(healthSlider);

                //spawn one of the normal people depending on the prefab given 
                //doesnt happen in the boss fight
                if (SceneManager.GetActiveScene().name != "BossScene")
                {
                    Instantiate(curedPersonPrefabVarient, this.transform.position, Quaternion.identity);
                }

                //wait to destroy
                StartCoroutine(DestroyObjectAfterWait(2f));
            }     
    }


    IEnumerator DestroyObjectAfterWait(float timeTillDestroy)
    {
        yield return new WaitForSeconds(timeTillDestroy);
        Destroy(gameObject);
    }

    //attack cooldown timer
    IEnumerator AttackCooldown(float attackCooldown)
    {
        yield return new WaitForSeconds(attackCooldown);
        this.GetComponent<Animator>().SetBool("WaitAfterAttack", false);
    }
}
