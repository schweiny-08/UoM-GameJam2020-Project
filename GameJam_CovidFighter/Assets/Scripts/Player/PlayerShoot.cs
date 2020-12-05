using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    private Transform firePoint;
    public GameObject projectile;
    public float projectileSpeed = 10f;

    //GameObject drop;
    // Start is called before the first frame update
    void Start()
    {
        firePoint = gameObject.transform.Find("FirePoint").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0)){

            //Creates correct rotation of drop
            Vector2 dropDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition)- transform.position;
            float dropAngle = Mathf.Atan2(dropDirection.y, dropDirection.x) * Mathf.Rad2Deg;
            
            Shoot(dropAngle);
        }
    }

    //Creates drop and propels it forward
    void Shoot(float angle){
        GameObject drop = Instantiate(projectile, firePoint.position, Quaternion.Euler(0f, 0f, angle-90f));//Quaternion.Inverse(Quaternion.Euler(0f, 0f, angle-90f)));
        drop.GetComponent<Rigidbody2D>().velocity = firePoint.up * projectileSpeed;
        //Rigidbody2D rb = drop.GetComponent<Rigidbody2D>();
    }
}
