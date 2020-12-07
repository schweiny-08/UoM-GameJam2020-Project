using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class curedPersonScript : MonoBehaviour
{
    public float destroyAfterTime = 4f;

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
        if (collision.tag == "SafeZone")
        {
            //increment uninfected counter
            GameObject.Find("GameMaster").GetComponent<GUI>().unifectedCounter++;
            this.GetComponent<Animator>().SetBool("SafeArea",true);
            StartCoroutine(HideAfter(destroyAfterTime));
        }
    }

    IEnumerator HideAfter(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponentInChildren<ParticleSystem>().Play();
        StartCoroutine(DestroyAfter(1f)); //to give time for effects
    }


    IEnumerator DestroyAfter(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
    }
}
