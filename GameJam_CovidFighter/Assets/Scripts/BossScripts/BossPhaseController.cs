using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPhaseController : MonoBehaviour
{
    private int maxBossHealth, bossHealth;

    public GameObject meleeEnemies;

    private GameObject enemySpawnPoint;

    public float spawnInterval = 5f, timeToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        maxBossHealth = GetComponent<BossHealth>().startHealth;

        enemySpawnPoint = GameObject.Find("EnemiesSpawn");

        timeToSpawn = spawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        bossHealth = GetComponent<BossHealth>().health;

        if(bossHealth <= maxBossHealth	&& bossHealth > maxBossHealth/2){
            PhaseOneStart();
        }
    }

    public void PhaseOneStart(){
        if(gameObject.GetComponent<EnemyShoot>().enabled == false)
            gameObject.GetComponent<EnemyShoot>().enabled = true;

        GameObject.Find("CovidBoss").GetComponent<EnemyShoot>().startShootDelay = 4f;

        if(bossHealth <= maxBossHealth - 20){
            //Speeds up rate the boss fires projectiles
            GameObject.Find("CovidBoss").GetComponent<EnemyShoot>().startShootDelay = 1f;
        }

        if(bossHealth <= maxBossHealth - 50){


            //Start Spawning MeleeEnemies
            if(timeToSpawn <= 0){
                Instantiate(meleeEnemies, enemySpawnPoint.transform.position, Quaternion.identity);
                timeToSpawn = spawnInterval;
            }else{
                timeToSpawn -= Time.deltaTime;
            }
        }


    }
}
