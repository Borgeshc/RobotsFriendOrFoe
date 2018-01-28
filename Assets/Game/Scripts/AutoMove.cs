using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controls player movement and jumping

public class AutoMove : MonoBehaviour
{
    public float speed = 3;
    public float jumpForce = 300;
    public Transform ground;
    public float crouchHeight = 1.75f;
    public ObjectDestroy despawnPoint;

    bool grounded = true;
    bool ducking;

    [HideInInspector]
    public bool isDead = false;

    BoxCollider col;
    Rigidbody rb;

    Animator anim;

    float yPosition;

	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<BoxCollider>();
        anim = GetComponentInChildren<Animator>();
        
        yPosition = transform.position.y;
	}
	
	void Update ()
    {
        if (!isDead)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Ground")
        {
            ground = col.gameObject.transform;
            anim.SetBool("Jump", false);
            grounded = true;
        }

        if (col.gameObject.tag == "Wall" || col.gameObject.tag == "Duckable")
        {
            Death();
        }
    }

    public void Jump()
    {
        if (!grounded || ducking) return;

        anim.SetBool("Jump", true);

        rb.AddForce(Vector3.up * jumpForce);
        grounded = false;
    }

    public void Duck()
    {
        if (ducking || !grounded) return;

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

        rb.constraints = ~RigidbodyConstraints.FreezePositionX;
        rb.constraints = ~RigidbodyConstraints.FreezePositionY;
        transform.position = new Vector3(transform.position.x, yPosition, transform.position.z);
        ducking = false;
    }

    public void Death()
    {
        isDead = true;
    }
}
