using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;

    float horizotnal;
    float vertical;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        horizotnal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizotnal, 0, vertical).normalized;
        movement *= speed * Time.deltaTime;
        rb.velocity = movement;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -17, 17), transform.position.y, Mathf.Clamp(transform.position.z, -6, 6));
    }
}
