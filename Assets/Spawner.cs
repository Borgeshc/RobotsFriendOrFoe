using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] enemyObject;
    public GameObject[] spawnPoints;

    public float timeRespawn;

    private bool isSpawning;
    private int enemyChooser;
    private int spawnPointChooser;
    // Use this for initialization
	void Start () {
        enemyChooser = 0;
        spawnPointChooser = 1;
	}
	
	// Update is called once per frame
	void Update () {
	    if(!isSpawning)
        {
            isSpawning = true;
            StartCoroutine(spawn());
        }

	}

    IEnumerator spawn()
    {
        enemyChooser = Random.Range(0, enemyObject.Length);
        spawnPointChooser = Random.Range(0, spawnPoints.Length);
        Instantiate(enemyObject[enemyChooser],spawnPoints[spawnPointChooser].transform.position,Quaternion.identity);
        yield return new WaitForSeconds(timeRespawn);
        isSpawning = false;
    }
}
