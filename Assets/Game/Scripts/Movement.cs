using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;

    float horizotnal;
    float vertical;

    Rigidbody rb;

    [HideInInspector]
    public bool isDead;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!isDead)
        {
            horizotnal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");

            Vector3 movement = new Vector3(horizotnal, 0, vertical).normalized;
            movement *= speed * Time.deltaTime * .02f;
            transform.position += movement;

            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -17, 17), transform.position.y, Mathf.Clamp(transform.position.z, -6, 6));
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Death();
        }

    }

    private void Death()
    {
        isDead = true;
    }
}
