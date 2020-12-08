using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPhaseController : MonoBehaviour
{
    private float maxBossHealth, bossHealth;

    public int bossDamage = 1;
    public GameObject meleeEnemies, longRangeEnemies;

    private GameObject enemySpawnPoint, enemySpawnPointTwo;

    public float spawnInterval = 5f, timeToSpawn;

    public float hitDisableLimit = 3f, hitDisableTimer;

    private bool hitDisabled;

    public GameObject[] moveSpots;

    private int moveSpotIndex;

    public int moveSpeed = 5;

    private bool phaseTwoStarted;
    // Start is called before the first frame update
    void Start()
    {
        hitDisabled = false;

        hitDisableTimer = hitDisableLimit;

        phaseTwoStarted = false;

        moveSpotIndex = 0;

        maxBossHealth = GetComponent<BossHealth>().startHealth;

        enemySpawnPoint = GameObject.Find("EnemiesSpawn");
        enemySpawnPointTwo	 = GameObject.Find("EnemiesSpawn (1)");

        timeToSpawn = spawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        bossHealth = GetComponent<BossHealth>().health;

        if(bossHealth <= maxBossHealth	&& bossHealth > maxBossHealth/2){
            PhaseOneStart();
        }else if(bossHealth <= maxBossHealth/2){
            if(!phaseTwoStarted)
                PhaseOneStop();
            PhaseTwo();
            if(hitDisabled){
                hitDisableTimer -= Time.deltaTime;
                if(hitDisableTimer <= 0){
                    hitDisableTimer = hitDisableLimit;
                    hitDisabled = false;
                }
            }
        }

        if(bossHealth <= 0)
            CovidDead();
    }

    void PhaseOneStart(){
        if(gameObject.GetComponent<EnemyShoot>().enabled == false)
            gameObject.GetComponent<EnemyShoot>().enabled = true;

        GameObject.Find("CovidBoss").GetComponent<EnemyShoot>().startShootDelay = 4f;

        if(bossHealth <= maxBossHealth - 20){
            //Speeds up rate the boss fires projectiles
            GameObject.Find("CovidBoss").GetComponent<EnemyShoot>().startShootDelay = 1f;
        }

        if(bossHealth <= maxBossHealth - 50){

            GameObject.Find("CovidBoss").GetComponent<EnemyShoot>().startShootDelay = 0.6f;

            //Start Spawning MeleeEnemies
            if(timeToSpawn <= 0){
                Instantiate(meleeEnemies, enemySpawnPoint.transform.position, Quaternion.identity);
                timeToSpawn = spawnInterval;
            }else{
                timeToSpawn -= Time.deltaTime;
            }
        }
    }

    void PhaseOneStop(){
        gameObject.GetComponent<EnemyShoot>().enabled = false;
        Destroy(GameObject.Find("EnemyFirePoint"));

        //gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

        phaseTwoStarted = true;
    }

    void PhaseTwo(){

        spawnInterval = 3f;

        if(moveSpotIndex >= moveSpots.Length)
            moveSpotIndex = 0;

        Vector2 currSpot = moveSpots[moveSpotIndex].transform.position;

        if(Vector2.Distance(transform.position, currSpot) < 0.00001){
            moveSpotIndex++;
        }else{
            transform.position = Vector2.MoveTowards(transform.position, currSpot, moveSpeed * Time.deltaTime);
        }

        if(bossHealth <= (maxBossHealth/2)-25 && bossHealth > (maxBossHealth/2)-50){
            bossDamage = 2;

             if(timeToSpawn <= 0){
                Instantiate(longRangeEnemies, enemySpawnPointTwo.transform.position, Quaternion.identity);
                timeToSpawn = spawnInterval;
            }else{
                timeToSpawn -= Time.deltaTime;
            }
            moveSpeed = 7;
        }
        if(bossHealth <= (maxBossHealth/2)-50 && bossHealth > (maxBossHealth/2)-75){
            moveSpeed = 12;
            if(timeToSpawn <= 0){
                Instantiate(longRangeEnemies, enemySpawnPointTwo.transform.position, Quaternion.identity);
                Debug.Log("SPEED: " + moveSpeed + "LONG ENEMY");

                Debug.Log("SHORT ENEMY");
                Instantiate(meleeEnemies, enemySpawnPoint.transform.position, Quaternion.identity);

                timeToSpawn = spawnInterval;
            }
            else{
                timeToSpawn -= Time.deltaTime;
            }
        }
        if(bossHealth <= (maxBossHealth/2)-75){
            moveSpeed = 15;
        }
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Player"){
            GameObject.Find("GameMaster").GetComponent<PlayerHealth>().OnDamageTaken(bossDamage);
            hitDisabled = true;
        }
    }

    void CovidDead(){
        Destroy(gameObject);

        //Add rest of death stuff
    }
}
