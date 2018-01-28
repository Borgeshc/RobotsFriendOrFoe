using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour 
{
    public Vector3 offset;
    public float speed = 15f;

    GameObject player;
    Vector3 velocity;

    private void Start()
    {
        player = GameObject.Find("Man");
    }

    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + offset, ref velocity, speed * Time.deltaTime);
    }
}
