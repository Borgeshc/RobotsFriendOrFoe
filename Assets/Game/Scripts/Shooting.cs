using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public LayerMask targetLayer;
    public Camera mainCamera;
    public float rotationSpeed = 100f;
    public KeyCode fireKey;
    public int damage;

    LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity, targetLayer))
        {
            LookAt(hit.point);
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, hit.point);

            if (Input.GetKeyDown(fireKey))
            {
                lineRenderer.enabled = true;

                if(hit.transform.tag.Equals("Enemy"))
                {
                    hit.transform.GetComponent<Health>().TookDamage(damage);
                }
            }
            else if (Input.GetKeyUp(fireKey))
                lineRenderer.enabled = false;
        }
    }

    void LookAt(Vector3 hitPoint)
    {
        Vector3 direction = (hitPoint - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }
}
