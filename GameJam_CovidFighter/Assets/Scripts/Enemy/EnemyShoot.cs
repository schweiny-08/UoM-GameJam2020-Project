using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject projectile;
    //public int projectileSpeed= 4;
    private Transform firePoint;

    public float startShootDelay = 1f;
    private float shootDelayTime;

    private Transform playerPos;



    // Start is called before the first frame update
    void Start()
    {
        firePoint = gameObject.transform.Find("EnemyFirePoint");//GameObject.Find("EnemyFirePoint").transform;

        shootDelayTime = startShootDelay;
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = GameObject.FindWithTag("Player").GetComponent<Transform>();

        float distance = Vector2.Distance(playerPos.position, transform.position);

        if(distance < gameObject.GetComponent<LongRangePersonStats>().shootDistance && distance > gameObject.GetComponent<LongRangePersonStats>().runDistance){
            if(shootDelayTime <= 0){
                //Shoot
                Instantiate(projectile, firePoint.position, Quaternion.identity);

                shootDelayTime = startShootDelay;
            }else{
                shootDelayTime -= Time.deltaTime;
            }
        }
    }
}
