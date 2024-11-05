using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastGun : MonoBehaviour
{
    public LineRenderer line;
    public float lineFadeSpeed;
    public LayerMask mask;
    public float knockbackForce = 10;
    public float distance = 1000f;
    public LayerMask layerMask;
    RaycastHit hit;


    void Update()
    {
        line.startColor = new Color(line.startColor.r, line.startColor.g, line.startColor.b, line.startColor.a - Time.deltaTime * lineFadeSpeed);
        line.endColor = new Color(line.endColor.r, line.endColor.g, line.endColor.b, line.endColor.a - Time.deltaTime * lineFadeSpeed);

        if (Input.GetButtonDown("Fire1"))
        {
            Raycast();
            line.startColor = new Color(line.startColor.r, line.startColor.g, line.startColor.b, 1);
            line.endColor = new Color(line.endColor.r, line.endColor.g, line.endColor.b, 1);

            line.SetPosition(0, transform.position);
            
        }
    }
    void Raycast()
    {
        
        if (Physics.Raycast(transform.position, transform.forward, out hit, distance, layerMask))
        {
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.yellow);
            
            EnemyController enemy = hit.transform.gameObject.GetComponent<EnemyController>();
            if (enemy != null)
            {
                enemy.Kill();
            }
            else
            {

                hit.rigidbody.AddForce(transform.forward * 100f);
            }
            line.SetPosition(1, transform.position + transform.forward * hit.distance);
            Debug.Log("Did Hit");
        }
        else
        {
            line.SetPosition(1, transform.position + transform.forward * 1000f);
            Debug.DrawRay(transform.position, transform.forward * distance, Color.red);
            Debug.Log("Not Hit");
        }
    }
}
