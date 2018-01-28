using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controls player movement and jumping

public class AutoMove : MonoBehaviour
{
    public float baseSpeed = 3;
    public float jumpForce = 300;
    public Transform ground;
    public float crouchHeight = 1.75f;
    public ObjectDestroy despawnPoint;
    public float slideTime = 1f;
    public float slideMultiplier = 2f;

    public BoxCollider fullCollider;
    public BoxCollider halfCollider;

    bool grounded = true;
    [HideInInspector]
    public bool sliding;

    [HideInInspector]
    public bool isDead = false;

    BoxCollider col;
    Rigidbody rb;

    Animator anim;

    float yPosition;
    float speed;

	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<BoxCollider>();
        anim = GetComponentInChildren<Animator>();
        
        yPosition = transform.position.y;
        speed = baseSpeed;
	}
	
	void Update ()
    {
        if (!isDead)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Clamp(transform.position.z, 0, 0));
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
        if (!grounded || sliding) return;

        anim.SetBool("Jump", true);

        rb.AddForce(Vector3.up * jumpForce);
        grounded = false;
    }

    public void Slide()
    {
        if (sliding || !grounded) return;

        anim.SetBool("Slide", true);
        sliding = true;

        FlipColliders();
        StartCoroutine(Sliding());
        //rb.constraints = RigidbodyConstraints.FreezePosition;
    }

    IEnumerator Sliding()
    {
        speed *= slideMultiplier;
        yield return new WaitForSecondsRealtime(slideTime);
        speed = baseSpeed;
        anim.SetBool("Slide", false);
        sliding = false;
    }

    public void FlipColliders()
    {
        fullCollider.enabled = !fullCollider.enabled;
        halfCollider.enabled = !halfCollider.enabled;
    }

    public void Death()
    {
        isDead = true;
    }
}
