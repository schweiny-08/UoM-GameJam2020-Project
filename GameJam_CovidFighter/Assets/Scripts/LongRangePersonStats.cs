using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongRangePersonStats : MonoBehaviour
{
    public float speed = 3;
    public float shootDistance = 10f;
    public float followDistance = 30f;
    public float runDistance = 5f;
    public int health = 3;

    public GameObject curedPersonPrefabVarient;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "hurtEnemy")
        {
            health--;
            if (health == 0)
            {
                //diabling sprite and collisions now and waiting 2 seconds to destroy object to give time to play death effects/ sound effects
                this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                this.gameObject.GetComponent<BoxCollider2D>().enabled = false;

                //spawn one of the normal people depending on the prefab given
                Instantiate(curedPersonPrefabVarient, this.transform.position, Quaternion.identity);

                //wait to destroy
                StartCoroutine(DestroyObjectAfterWait(2f));
            }
        }
    }


    IEnumerator DestroyObjectAfterWait(float timeTillDestroy)
    {
        yield return new WaitForSeconds(timeTillDestroy);
        Destroy(gameObject);
    }
}
