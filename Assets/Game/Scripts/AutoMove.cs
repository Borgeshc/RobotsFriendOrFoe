using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controls player movement and jumping

public class AutoMove : MonoBehaviour
{
    public float speed = 3;
    public float jumpForce = 300;
    public Transform ground;

    bool grounded = true;
    Rigidbody rb;

	void Start ()
    {
        rb = GetComponent<Rigidbody>();
	}
	
	void Update ()
    { 
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
	}

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Ground")
        {
            ground = col.gameObject.transform;
            grounded = true;
        }
    }

    public void Jump()
    {
        if (!grounded) return;
        rb.AddForce(Vector3.up * jumpForce);
        grounded = false;
    }

    public void Duck()
    {
        print("Duck");
    }
}
