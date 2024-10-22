using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    float spawnx = 7.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemies", 2, 2);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnEnemies()
    {
        float xPos = UnityEngine.Random.Range(spawnx, -spawnx);
        Instantiate(enemyPrefab, new Vector3(xPos, 9, 0), enemyPrefab.transform.rotation);
    }
}
