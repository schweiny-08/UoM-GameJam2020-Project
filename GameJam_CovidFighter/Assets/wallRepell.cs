using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallRepell : MonoBehaviour
{
    private GameObject player;
    private float speed;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        speed = this.GetComponentInParent<LongRangePersonStats>().speed;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Wall")
        {
            Debug.Log("Hello Wall");
            this.GetComponentInParent<Transform>().position = Vector2.MoveTowards(this.transform.position, player.transform.position, -1 * speed * Time.deltaTime);
        }
    }
}
