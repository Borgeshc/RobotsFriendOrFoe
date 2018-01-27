using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public float spawnTime = 2;

    // Use this for initialization
    void Start ()
    {
        InvokeRepeating("GenerateObj", spawnTime, spawnTime);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
