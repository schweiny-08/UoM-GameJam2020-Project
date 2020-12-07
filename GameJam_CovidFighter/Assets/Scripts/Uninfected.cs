using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uninfected : MonoBehaviour
{

    public float speed;
    public GameObject player;
    public GameObject uninfected;
    public bool safe;

    public PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        uninfected = GameObject.FindGameObjectWithTag("Uninfected");
        player = GameObject.FindGameObjectWithTag("Player");
        speed = playerMovement.speed;
        safe = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!safe)
        {
            uninfected.transform.position = Vector2.MoveTowards(uninfected.transform.position, player.transform.position, speed * Time.deltaTime);
        }
        
    }

    void OnDamageTaken (int damageTaken)
    {
        if(damageTaken > 0)
        {
            //diabling sprite and collisions now and waiting 2 seconds to destroy object to give time to play death effects/ sound effects
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;

            //spawn one of the infected people depending on the prefab given
            //Instantiate(infectedPersonPrefabVarient, this.transform.position, Quaternion.identity);


            //Destroy(gameObject.transform.Find("FirePoint"));
            Destroy(this.gameObject);
            //wait to destroy
            //StartCoroutine(DestroyObjectAfterWait(0.5f));
        }
    }
}
