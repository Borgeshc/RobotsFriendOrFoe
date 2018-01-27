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
    bool ducking;

    BoxCollider col;
    Rigidbody rb;

	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<BoxCollider>();
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
        if (ducking) return;
        ducking = true;
        col.size = new Vector3(col.size.x, col.size.y * .5f, col.size.z);
        col.center = new Vector3(col.center.x, col.size.y * .5f, col.center.z);
        StartCoroutine(Ducking());
    }

    IEnumerator Ducking()
    {
        yield return new WaitForSeconds(1);

        col.size = Vector3.one;
        col.center = Vector3.zero;
        ducking = false;
    }
}
