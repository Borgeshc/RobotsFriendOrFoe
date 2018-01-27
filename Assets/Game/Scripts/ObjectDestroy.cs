using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroy : MonoBehaviour
{
    public GameObject player;
    public GameObject ground;           // Ground gameObject to instantiate\
    public float tileSize;

    ObstacleGenerator obstacleGenerator;

    private void Start()
    {
        player = GameObject.Find("Man");
        obstacleGenerator = GameObject.Find("GameManager").GetComponent<ObstacleGenerator>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            ObstacleGenerator.currWall--;
            Destroy(other.gameObject);
        }

        else if(other.gameObject.tag == "Duckable")
        {
            ObstacleGenerator.currDuck--;
            Destroy(other.gameObject);
        }
        
        if(other.gameObject.tag == "Player")
        {
            obstacleGenerator.GenerateGround(transform.parent.gameObject);
        }
    }
}
