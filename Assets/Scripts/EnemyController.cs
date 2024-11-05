using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyController : MonoBehaviour
{
    public float speedRotation;
    public float stoppingDistance;
    public float stoppingSpeed;
    public GameObject player;
    public Animator anim;
    public float enemySpeed = 0;
    public EnemyFinder target;
    Rigidbody rB;
    Collider coll;
    public bool dead;
    private void Start()
    {
        anim = GetComponent<Animator>();
        rB = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();

    }
    private void Update()
    {

        if (dead)
        {
            Kill();
        }
        Quaternion playerRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        float enemyRotationSpeed = speedRotation * Time.deltaTime;
        transform.rotation = Quaternion.Lerp(transform.rotation, playerRotation, enemyRotationSpeed);
        Vector3 distance = transform.position - player.transform.position;
        if (distance.magnitude > stoppingDistance)
        {
            SpeedUp();
        }
        else
        {
            SpeedDown();
        }
    }

    public void Kill()
    {
        rB.isKinematic = true;
        anim.enabled = false;
        coll.enabled = false;
        Rigidbody[] huesos = GetComponentsInChildren<Rigidbody>();
        foreach (var rB in huesos)
        {
            rB.isKinematic = false;
        }
        Destroy(this);

    }

    void SpeedUp()
    {
        enemySpeed += stoppingSpeed * Time.deltaTime;
        if(enemySpeed >= 1) {
            enemySpeed = 1;
        }
        anim.SetFloat("Velocity", enemySpeed);
    }
    void SpeedDown()
    {
        enemySpeed -= stoppingSpeed * Time.deltaTime;
        if (enemySpeed <= 0)
        {
            enemySpeed = 0;
        }
        anim.SetFloat("Velocity", enemySpeed);
    }
}
