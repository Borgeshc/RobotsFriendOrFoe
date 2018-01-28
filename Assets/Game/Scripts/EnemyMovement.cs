using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    public Transform mTarget;
    private float speed;
    public Vector3 randomDirection;
    private int movementDecider;
    public float minVelocity;

	// Use this for initialization
	void Start () {
        mTarget = GameObject.Find("Player").transform;
        minVelocity = .1f;
     
        randomDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
      //  transform.rotation = Quaternion.Euler(randomDirection);
        movementDecider = Random.Range(0, 3);

    }
	
	// Update is called once per frame
	void Update () {
        if (movementDecider == 1)
        {
            transform.position += (mTarget.position - transform.position).normalized * speed;
        }
        else if (movementDecider == 0)
        {
            transform.position += randomDirection * minVelocity;
        }
	}

    private void OnCollisionEnter(Collision other)
    {
        if (movementDecider == 0)
        {
            if (other.transform.tag.Equals("ImpWall"))
            {
                speed = randomDirection.magnitude;
                randomDirection = Vector3.Reflect(randomDirection.normalized, other.contacts[0].normal) * Mathf.Max(speed, minVelocity);
            }
        }
    }
}
