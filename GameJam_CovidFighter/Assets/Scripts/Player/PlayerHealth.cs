using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    public float maxHealth = 10;
    public float currentHealth;
    public float timeLimit = 30;
    public bool lowhealth = false;
    public float timeTaken;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        timeTaken = 0;
    }

    private void Update()
    {
        if(lowhealth)
        {
            timeTaken += Time.deltaTime;

            if(timeTaken >= timeLimit)
            {
                SceneManager.LoadScene("CurrentScene");
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

        if(currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void OnMaxHealthIncreased (int newMaxhealth)
    {
        maxHealth = newMaxhealth;
        //currentHealth = maxHealth;
    }
}
