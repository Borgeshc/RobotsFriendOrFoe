using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public float spawnTriggerTime;
    public float timerDecrement;
    public float spawnTime;
    public Transform[] spawnPoints;
    public static int currWall = 0;
    public static int currDuck = 0;
    public GameObject[] wallObjects;
    public GameObject[] duckObjects;
    public GameObject[] groundTiles;
    public float tileSize = 68f;
    public Spawner spawner;
    public List<GameObject> previousGrounds;
    private int spawnTriggerMax = 30;

    private void Update()
    {
        spawnTime += Time.deltaTime;
        timerDecrement += Time.deltaTime;

        if (spawnTriggerMax >= 8 && timerDecrement >= 30)
        {
            spawnTriggerMax--;
            timerDecrement = 0;
        }

        if (spawnTime >= spawnTriggerTime)
        {
            GenerateObj();
            spawnTime = 0;
        }    
    }

    void GenerateObj()
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        if(spawnPointIndex == 0)
        {
            currWall++;
            spawner.makeEnemy(1);
            Spawner.numberOfJumps++;
            int wallObjectIndex = Random.Range(0, wallObjects.Length);
            Instantiate(wallObjects[wallObjectIndex], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        }

        if (spawnPointIndex == 1)
        {
            currDuck++;
            spawner.makeEnemy(0);
            Spawner.numberOfDucks++;
            int duckObjectIndex = Random.Range(0, duckObjects.Length);
            Instantiate(duckObjects[duckObjectIndex], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        }

        spawnTriggerTime = Random.Range(4, spawnTriggerMax);
    }

    public void GenerateGround(GameObject other)
    {
        previousGrounds.Add(other);
        int groundObjIndex = Random.Range(0, groundTiles.Length);
        Instantiate(groundTiles[groundObjIndex], other.transform.position + new Vector3(tileSize, 0, 0), Quaternion.identity);

        if(previousGrounds.Count >= 3 && previousGrounds[0] != null)
        {
            GameObject previousGround = previousGrounds[0];
            previousGrounds.Remove(previousGround);
            Destroy(previousGround);
        }
    }
}
