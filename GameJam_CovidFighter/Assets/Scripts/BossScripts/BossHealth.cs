using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
    public float startHealth = 200;
    public float health;
    public Slider healthBar;
    // Start is called before the first frame update
    void Start()
    {
        health = startHealth;
        healthBar.value = health / startHealth;
    }

    // Update is called once per frame
    void Update()
    {
        // if(health <= 0){
        //     //Boss Dies
        //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        // }
    }

    public void TakeDamage(int damage){
        health -= damage;
        Debug.Log(health);

         if(health <= 0){
            //Boss Dies
            SceneManager.LoadScene("WinScreen");
            //GameObject.Find("GameMaster").GetComponent<GameMaster>().ToNextLevel();
        }

        //updates the health bar
        healthBar.value = health / startHealth;
    }
}
