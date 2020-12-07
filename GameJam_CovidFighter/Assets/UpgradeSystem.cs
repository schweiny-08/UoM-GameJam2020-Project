using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpgradeSystem : MonoBehaviour
{
    public string sceneToLoad;
    public float sceneTransistionTime = 1f;

    private PlayerHealth playerStats;
    private bool upgradeSelected = false;

    // Start is called before the first frame update
    void Start()
    {
        playerStats = GameObject.Find("GameMaster").GetComponent<PlayerHealth>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void upgradeHealth()
    {
        if (upgradeSelected == false)
        {
            upgradeSelected = true;
            playerStats.maxHealth++;
            StartCoroutine(GoToScene(sceneTransistionTime));
        }

    }

    public void upgradeSpeed()
    {
        if (upgradeSelected == false)
        {
            upgradeSelected = true;
            playerStats.playerSpeed = playerStats.playerSpeed + 2; //Change to a speed increase
            StartCoroutine(GoToScene(sceneTransistionTime));
        }
    }

    public void upgradeAttack()
    {
        if (upgradeSelected == false)
        {
            upgradeSelected = true;
            playerStats.attackDamage++; //Change to an attack power increase
            StartCoroutine(GoToScene(sceneTransistionTime));
        }
    }

    //loads the scene after the given time
    IEnumerator GoToScene(float waitTime)
    {

        yield return new WaitForSeconds(waitTime);

        SceneManager.LoadScene(sceneToLoad);

    }
}
