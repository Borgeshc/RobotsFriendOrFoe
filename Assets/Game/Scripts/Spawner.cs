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

	void Start ()
    {
        enemyChooser = 0;
        spawnPointChooser = 1;
        numberOfDucks = ObstacleGenerator.currDuck;
        numberOfJumps = ObstacleGenerator.currWall;
    }
	
	void Update ()
    {
	    if(!isSpawning)
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

    private void makeEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoints[spawnPointChooser].transform.position + offsetRandom, Quaternion.identity);
    }
    public void makeEnemy(int number)
    {
        spawnPointChooser = Random.Range(0, spawnPoints.Length);
        Instantiate(enemyObject[number], spawnPoints[spawnPointChooser].transform.position + offsetRandom, Quaternion.identity);
    }
    IEnumerator spawn()
    {
        if (numberOfDucks+numberOfJumps < 15)
        {
            spawnPointChooser = Random.Range(0, spawnPoints.Length);
            offsetRandom = new Vector3(Random.Range(-1,1), transform.position.y, Random.Range(-1,1));
            if(ObstacleGenerator.currDuck > 0 && numberOfDucks == 0)
            {
                enemyChooser = 1;
            }
            else if(ObstacleGenerator.currWall > 0 && numberOfJumps == 0)
            {
                enemyChooser = 0;
            }
            else
            {
                enemyChooser = Random.Range(0, enemyObject.Length);
            }
            GameObject enemy = enemyObject[enemyChooser];
            if(enemy.GetComponent<Health>().enemyType == Health.EnemyType.JumpEnemy)
            {
                numberOfJumps++;
            }
            else if (enemy.GetComponent<Health>().enemyType == Health.EnemyType.DuckEnemy)
            {
                numberOfDucks++;
            }
            makeEnemy(enemy);
        }
        yield return new WaitForSeconds(timeRespawn);
        isSpawning = false;
    }
}
