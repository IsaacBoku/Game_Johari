using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    float spawnx = 7.5f;
    //bool spawny = false;
    
    float cooldown = 2;
    public float time = 0;
    public float finalTime;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemies", 2, 2);
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
            float xPos = UnityEngine.Random.Range(spawnx, -spawnx);
            Instantiate(enemyPrefab, new Vector3(xPos, 9, 0), enemyPrefab.transform.rotation);
        }
    }

    void CambioSpawn()
    {
        if(time >= finalTime)
        {
            spawnx -= Time.deltaTime;

            if (spawnx <= 1f)
            {
                spawnx = 1f;
            }
        }
    }
}
