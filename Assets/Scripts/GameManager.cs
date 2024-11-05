using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] spawners;
    public GameObject enemies;
    public EnemyController[] activeEnemies;
    public float enemiesNum;

    private void Awake()
    {
        spawners = GameObject.FindGameObjectsWithTag("spawner");
    }

    private void Start()
    {
    }
    void Update()
    {
        
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < enemiesNum; i++) {

            Instantiate(enemies, spawners[i].transform.position ,transform.rotation);
        }
    }
    void GetAllEnemies()
    {
       // activeEnemies = GameObject.FindObjectsOfType<EnemyController>;
    }
}
