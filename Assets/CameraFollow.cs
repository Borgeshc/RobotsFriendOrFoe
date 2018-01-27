using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour 
{
    public float speed = 3;

    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }
}
