using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public float spawnTriggerTime = 2;
    public float spawnTime = 0;
    public Transform[] spawnPoints;
    public GameObject wallObj;
    public GameObject duckObj;

    private void Update()
    {
        spawnTime += Time.deltaTime;

        if(spawnTime >= spawnTriggerTime)
        {
            GenerateObj();
            spawnTime = 0;
        }    
    }

    void GenerateObj()
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        if(spawnPointIndex == 0)
            Instantiate(wallObj, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

        if (spawnPointIndex == 1)
            Instantiate(duckObj, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

        spawnTriggerTime = Random.Range(2, 6);
    }
}
