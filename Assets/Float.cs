using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float : MonoBehaviour
{
    private bool dirUp = true;
    public float speed = 2.0f;

    void Update()
    {
        if (dirUp)
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        else
            transform.Translate(-Vector2.up * speed * Time.deltaTime);

        if (transform.position.y >= .5f)
        {
            dirUp = false;
        }

        if (transform.position.y <= -.5f)
        {
            dirUp = true;
        }
    }
}
