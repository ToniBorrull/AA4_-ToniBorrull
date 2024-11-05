using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float speedRotation;
    public Transform target;
    public EnemyFinder enemy;
    Vector3 dir;
    private void Start()
    {

    }
    void Update()
    {
        Move();
        RotateToEnemy();
    }
    void Move()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
       
        dir = new Vector3(horizontal, 0, vertical);

        if (dir.magnitude > 1)
        {
            dir.Normalize();
        }

        transform.localPosition += dir * Time.deltaTime * speed;
    }
    void RotateToEnemy()
    {
        Quaternion playerRotation = Quaternion.LookRotation(enemy.transform.position - transform.position);
        float playerRotationSpeed = speedRotation * Time.deltaTime;
        transform.rotation = Quaternion.Lerp(transform.rotation, playerRotation, playerRotationSpeed);
    }

}
