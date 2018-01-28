using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour 
{
    public Vector3 offset;

   public GameObject player;

    private void Start()
    {
      //  player = GameObject.Find("Man");
    }

    void LateUpdate()
    {
        if(player.activeInHierarchy)
            transform.position = new Vector3(player.transform.position.x + offset.x, offset.y, player.transform.position.z + offset.z);
    }
}
