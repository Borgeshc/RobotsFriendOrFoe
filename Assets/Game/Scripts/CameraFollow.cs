using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour 
{
    public Vector3 offset;

    GameObject player;

    private void Start()
    {
        player = GameObject.Find("Man");
    }

    void LateUpdate()
    {
        transform.position = new Vector3(player.transform.position.x + offset.x, offset.y, player.transform.position.z + offset.z);
    }
}
