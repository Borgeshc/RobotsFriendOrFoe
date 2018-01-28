using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public LayerMask groundLayer;
    public LayerMask targetLayer;
    public Camera mainCamera;
    public float rotationSpeed = 100f;
    public KeyCode fireKey;
    public int damage;

    public ArcReactor_Launcher lightningEffect;

   // LineRenderer lineRenderer;

    private void Start()
    {
      //  lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity, groundLayer))
        {
            Vector3 lookPos = hit.point - transform.position;
            lookPos.y = 0;
            Quaternion rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
        }

        if (Input.GetKeyDown(fireKey))
        {
            RaycastHit hitAttack;
            // lightningEffect.enabled = true;
            // lineRenderer.SetPosition(0, transform.position);
            lightningEffect.LaunchRay();
            if (Physics.Raycast(transform.position, transform.forward, out hitAttack, Mathf.Infinity))
            {
                if (hitAttack.transform.tag.Equals("Enemy"))
                {
                    hitAttack.transform.GetComponent<Health>().TookDamage(damage);

                    //   lineRenderer.SetPosition(1, hitAttack.point);
                   // lightningEffect.shapePoints[1] = hitAttack.point;

                }
               // else
                   // lightningEffect.shapePoints[1] = transform.forward * 1000;
                //else
                //  lineRenderer.SetPosition(1, transform.forward * 1000);
            }
        }
        else if (Input.GetKeyUp(fireKey))
        {
           // lightningEffect.enabled = false;
            //lineRenderer.enabled = false;
            //  lightningEffect.SetActive(false);
        }
    }
    

    void LookAt(Vector3 hitPoint)
    {
        Vector3 direction = (hitPoint - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }
}
