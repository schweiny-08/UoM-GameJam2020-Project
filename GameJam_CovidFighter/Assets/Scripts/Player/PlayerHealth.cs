using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 5;
    public int currentHealth;
    public float timeLimit = 30;
    public bool lowhealth = false;
    public float timeTaken;

    public float playerSpeed = 6f;
    public int attackDamage = 1;

    private GUI gui;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        timeTaken = 0;

        gui = GetComponent<GUI>();
    }

    private void Update()
    {
        if(lowhealth)
        {
            timeTaken += Time.deltaTime;
            gui.SetCounter((int)timeTaken);



            if(timeTaken >= timeLimit)
            {
                StartCoroutine(InfectedPlayer());
                //Load current scene
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    public void OnDamageTaken (int damageTaken)
    {
        currentHealth -= damageTaken;

        if(currentHealth <= 0)
        {
            lowhealth = true;
            Debug.Log("VERY LOW HEALTH. RETURN TO SAFE ZONE WITHIN " + timeLimit + " SECONDS");

        }
    }

    public void OnHealthIncreased (int healthIncrease)
    {
        currentHealth += healthIncrease;

        /*
        if(currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
        */
    }

    public void OnMaxHealthIncreased (int newMaxhealth)
    {
        maxHealth = newMaxhealth;
        currentHealth = maxHealth;
    }

    IEnumerator InfectedPlayer(){

        GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>().color = Color.green;
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().enabled = false;

        yield return new WaitForSeconds(4f);
    }
}
