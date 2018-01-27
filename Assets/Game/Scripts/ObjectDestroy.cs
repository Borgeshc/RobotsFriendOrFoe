using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroy : MonoBehaviour
{
    public Transform playerGround;      // Ground the player is running on
    public GameObject player;
    public GameObject ground;           // Ground gameObject to instantiate

    private void Start()
    {
        player = GameObject.Find("Man");
        playerGround = player.GetComponent<AutoMove>().ground;
    }

    private void Update()
    {
        playerGround = player.GetComponent<AutoMove>().ground;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall" || other.gameObject.tag == "Duckable")
        {
            Destroy(other.gameObject);
        }

        if(other.gameObject.tag == "Ground")
        {
            Instantiate(ground, playerGround.position + new Vector3(30, 0, 0), playerGround.rotation);
            Destroy(other.gameObject);
        }
    }
}
