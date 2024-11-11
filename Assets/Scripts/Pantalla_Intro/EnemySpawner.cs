using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    //float spawnx = 7.5f;

    public Transform player;
    //bool spawny = false;
    
    float cooldown = 2;
    public float time = 0;
    public float finalTime;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemies", 2, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        coolDown();
    }
    void coolDown()
    {
        time = Time.time + cooldown;
    }
    void SpawnEnemies()
    {
        if (time >= finalTime)
        {
            Instantiate(enemyPrefab, new Vector3(player.position.x, 9, 0), enemyPrefab.transform.rotation);
        }
    }
}
