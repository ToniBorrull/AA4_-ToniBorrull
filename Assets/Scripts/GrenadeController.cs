using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GrenadeController : MonoBehaviour
{
    Rigidbody rb;
    public LayerMask mask;
    public float launchForce;
    public float timer;
    float realtime;
    public float radius;
    public float explosionForce;
    public GameObject particles;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * launchForce);
        rb.AddTorque(Random.Range(-200, 200), Random.Range(-200, 200), Random.Range(-200, 200));
    }

    private void Update()
    {
        realtime +=  Time.deltaTime;
        if(realtime >= timer)
        {
            Instantiate(particles, transform.position, transform.rotation);
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach(GameObject enemy in enemies)
            {
                Vector3 distance = enemy.transform.position - transform.position;
                if (distance.magnitude <= radius)
                {
                    EnemyController controller;
                    controller = enemy.GetComponent<EnemyController>();

                    if (controller != null)
                    {
                        controller.Kill();
                    }
                }
            }

            
          
           
            Rigidbody[] rB = GameObject.FindObjectsOfType<Rigidbody>();
            foreach (Rigidbody r in rB)
            {
                Vector3 rbDis = r.position - transform.position;
            if (rbDis.magnitude <= radius)
            {
                r.AddForce(r.transform.position - transform.position * explosionForce);
            }
            }
            Destroy(gameObject);
        }
    }

}
