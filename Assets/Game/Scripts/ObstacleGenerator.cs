using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public float spawnTriggerTime = 4;
    public float spawnTime = 0;
    public Transform[] spawnPoints;
    public GameObject[] wallObjects;
    public GameObject[] duckObjects;
    public GameObject ground;
    public float tileSize = 68f;
    public List<GameObject> previousGrounds;

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
        {
            int wallObjectIndex = Random.Range(0, wallObjects.Length);
            Instantiate(wallObjects[wallObjectIndex], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        }

        if (spawnPointIndex == 1)
        {
            int duckObjectIndex = Random.Range(0, duckObjects.Length);
            Instantiate(duckObjects[duckObjectIndex], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        }

        spawnTriggerTime = Random.Range(4, 8);
    }

    public void GenerateGround(GameObject other)
    {
        previousGrounds.Add(other);
        Instantiate(ground, other.transform.position + new Vector3(tileSize, 0, 0), Quaternion.identity);

        if(previousGrounds.Count >= 3 && previousGrounds[0] != null)
        {
            GameObject previousGround = previousGrounds[0];
            previousGrounds.Remove(previousGround);
            Destroy(previousGround);
        }
    }
}
