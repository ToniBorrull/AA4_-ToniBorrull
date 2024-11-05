using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFinder : MonoBehaviour
{
    public float speedRotation;
    public GameObject[] enemies;
    public GameObject player;

    private void Start()
    {
        GetEnemies();
    }
    private void Update()
    {
        GetClosestEnemy();
        if (enemies.Length == 0)
        {
            transform.position = player.transform.position;
        }
    }

    void GetClosestEnemy()
    {
        if (enemies.Length <= 0)
        {
            transform.position = player.transform.position;
        }

        if (enemies.Length > 0)
        {
            var pos = player.transform.position;

            float dist = float.PositiveInfinity;
            GameObject nearest = null;
            foreach (var go in enemies)
            {
                var d = (go.transform.position - pos).sqrMagnitude;
                if (d < dist)
                {
                    nearest = go;
                    dist = d;
                    transform.position = nearest.transform.position;
                }
            }
        }
        

    }

    public void GetEnemies()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }
    
}
