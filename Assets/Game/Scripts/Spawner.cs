using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] enemyObject;
    public GameObject[] spawnPoints;

    public float timeRespawn;
    public static int numberOfJumps;
    public static int numberOfDucks;


    private Vector3 offsetRandom;
    private bool isSpawning;
    private int enemyChooser;
    private int spawnPointChooser;
    private float initalWait;

    void Start()
    {
        enemyChooser = 0;
        spawnPointChooser = 1;
        numberOfDucks = ObstacleGenerator.currDuck;
        numberOfJumps = ObstacleGenerator.currWall;
    }

    void Update()
    {
        initalWait += Time.deltaTime;
        if (!isSpawning && initalWait > 10)
        {
            isSpawning = true;
            StartCoroutine(spawn());
        }
    }

    public void SetDucks(int number)
    {
        numberOfDucks = number;
    }

    public void SetJumps(int number)
    {
        numberOfJumps = number;
    }

    public void makeEnemy(int number)
    {
        spawnPointChooser = Random.Range(0, spawnPoints.Length);
        offsetRandom = new Vector3(Random.Range(-1, 1), transform.position.y, Random.Range(-1, 1));
        Instantiate(enemyObject[number], spawnPoints[spawnPointChooser].transform.position + offsetRandom, Quaternion.identity);
    }
    IEnumerator spawn()
    {
        if (numberOfDucks + numberOfJumps < 15)
        {
            yield return new WaitForSeconds(timeRespawn);
            spawnPointChooser = Random.Range(0, spawnPoints.Length);
            offsetRandom = new Vector3(Random.Range(-1, 1), transform.position.y, Random.Range(-1, 1));
            if (ObstacleGenerator.currDuck > 0 && numberOfDucks == 0)
            {
                enemyChooser = 0;
            }
            else if (ObstacleGenerator.currWall > 0 && numberOfJumps == 0)
            {
                enemyChooser = 1;
            }
            else
            {
                enemyChooser = Random.Range(0, enemyObject.Length);
            }
            GameObject enemy = enemyObject[enemyChooser];
            if (enemy.GetComponent<Health>().enemyType == Health.EnemyType.JumpEnemy)
            {
                numberOfJumps++;
            }
            else if (enemy.GetComponent<Health>().enemyType == Health.EnemyType.DuckEnemy)
            {
                numberOfDucks++;
            }
            Instantiate(enemy, spawnPoints[spawnPointChooser].transform.position + offsetRandom, Quaternion.identity);
        }
        isSpawning = false;
    }
}
