using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{


    public SpawnerBox enemiesSpawner;
    private bool shouldSpawnWave = true;
    public GameObject asteroid;
    public float spawnEveryNSeconds = 0.5f;
    public float waitAfterWave = 5.0f;
    public int enemiesInWave = 10;
    public float waitOnStart = 2.0f;
 

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnWave());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator SpawnWave()
    {
        yield return new WaitForSeconds(waitOnStart);

        int enemiesSpawned = 0;

        while (shouldSpawnWave)
        {
            if (enemiesSpawned < enemiesInWave) {
                enemiesSpawner.Spawn(asteroid);
                enemiesSpawned++;
                yield return new WaitForSeconds(spawnEveryNSeconds);
            }
            else {
                enemiesSpawned = 0;
                yield return new WaitForSeconds(waitAfterWave);
            }
        }
    }
}