using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    public Transform mTarget;
    private float speed;
    public Vector3 direction;
    public int movementDecider;
    public float randomVelocity;
    private float randomChaseVelocity;

	// Use this for initialization
	void Start () {
        mTarget = GameObject.Find("Player").transform;
        randomVelocity = Random.Range(.1f,.15f);
        randomChaseVelocity = Random.Range(.06f, .08f);
     
        direction = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));

        movementDecider = Random.Range(0, 2);

    }
	
	// Update is called once per frame
	void Update () {
        if (movementDecider == 1)
        {
            transform.position += (mTarget.position - transform.position).normalized * randomChaseVelocity;
        }
        else if (movementDecider == 0)
        {
            transform.position += direction * randomVelocity;
        }
	}

    private void OnCollisionEnter(Collision other)
    {
        if (movementDecider == 0)
        {
            if (other.transform.tag.Equals("ImpWall"))
            {
                //speed = randomDirection.magnitude;
                direction = (Vector3.Reflect(direction.normalized, other.contacts[0].normal)+ other.contacts[0].normal *.05f).normalized;
            }
        }
    }
}
