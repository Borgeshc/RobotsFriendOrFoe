using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] enemyObject;
    public GameObject[] spawnPoints;

    public GameObject[] spawnEffects;

    public float timeRespawn;
    public float timeDelay;
    public static int numberOfJumps;
    public static int numberOfDucks;


    private bool isSpawning;
    private int enemyChooser;
    private int spawnPointChooser1;
    private int spawnPointChooser2;
    private float initalWait;

    void Start()
    {
        enemyChooser = 0;
        numberOfDucks = ObstacleGenerator.currDuck;
        numberOfJumps = ObstacleGenerator.currWall;
    }

    void Update()
    {
        initalWait += Time.deltaTime;
        if (!isSpawning && initalWait > timeRespawn)
        {
            isSpawning = true;
            StartCoroutine(spawn());
            initalWait = 0;
            timeRespawn = Mathf.Min(2f,timeRespawn-.5f);
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
        StartCoroutine(spawnone(number));
    }

    IEnumerator spawn()
    {

        if (numberOfDucks + numberOfJumps < 15)
        {
            spawnPointChooser1 = Random.Range(0, spawnPoints.Length);
            spawnEffects[spawnPointChooser1].SetActive(true);
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

            yield return new WaitForSeconds(timeDelay);

            Instantiate(enemy, spawnPoints[spawnPointChooser1].transform.position, Quaternion.identity);
        }
        isSpawning = false;
    }

    IEnumerator spawnone(int number)
    {
        if (numberOfDucks + numberOfJumps < 15)
        {
            spawnPointChooser2 = Random.Range(0, spawnPoints.Length);
            spawnEffects[spawnPointChooser2].SetActive(true);
            yield return new WaitForSeconds(timeDelay);
            Instantiate(enemyObject[number], spawnPoints[spawnPointChooser2].transform.position, Quaternion.identity);
        }
        isSpawning = false;
    }
}
