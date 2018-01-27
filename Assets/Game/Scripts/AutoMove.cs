﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controls player movement and jumping

public class AutoMove : MonoBehaviour
{
    public float speed = 3;
    public float jumpForce = 300;
    public Transform ground;
    public float crouchHeight = 1.75f;

    bool grounded = true;
    bool ducking;

    BoxCollider col;
    Rigidbody rb;

    Vector3 originalSize;
    Vector3 originalCenter;
    Animator anim;

    float yPosition;

	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<BoxCollider>();
        anim = GetComponentInChildren<Animator>();

        originalSize = col.size;
        originalCenter = col.center;
        yPosition = transform.position.y;
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

        anim.SetTrigger("Jump");

        rb.AddForce(Vector3.up * jumpForce);
        grounded = false;
    }

    public void Duck()
    {
        if (ducking) return;

        anim.SetTrigger("Duck");

        ducking = true;
        rb.constraints = RigidbodyConstraints.FreezePosition;
        col.size -= new Vector3(col.size.x, crouchHeight, col.size.z);
        col.center -= new Vector3(col.center.x, crouchHeight / 2, col.center.z);
        StartCoroutine(Ducking());
    }

    IEnumerator Ducking()
    {
        yield return new WaitForSeconds(1);

        col.size += new Vector3(1, crouchHeight, 1);
        col.center += new Vector3(0, crouchHeight / 2, 0);

        rb.constraints = ~RigidbodyConstraints.FreezePosition;
        transform.position = new Vector3(transform.position.x, yPosition, transform.position.z);
        ducking = false;
    }
}
