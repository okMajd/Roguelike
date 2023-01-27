using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamecontrol : MonoBehaviour
{
    public int wave;
    public enemyTracker enemyTracker;
    public float spawnedSoFar = 0f;
    public float enemiesToSpawn;
    public float actualSpawnDelay;
    public float SpawnDelay = 2f;
    public float delayChangeMin, delayChangeMax;
    public GameObject enemyPre;

    public Transform corner1, corner2;

    private void Start()
    {
        actualSpawnDelay = SpawnDelay;
        enemiesToSpawn = 35 * Mathf.Pow(wave, 0.23f);
        StartCoroutine("spawnEnemies");
    }

    Vector2 generateLocation()
    {
        return new Vector2(Random.Range(corner1.position.x, corner2.position.x), Random.Range(corner1.position.y, corner2.position.y));
    }

    IEnumerator spawnEnemies()
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            GameObject enemy = Instantiate(enemyPre, generateLocation(), Quaternion.identity);
            enemyTracker.enemies.Add(enemy);
            spawnedSoFar++;
            yield return new WaitForSeconds(actualSpawnDelay);
            if(actualSpawnDelay > 0)
            { 
                actualSpawnDelay -= Random.Range(delayChangeMin, delayChangeMax); 
            }else{
                actualSpawnDelay += 1f;
            }
        }
    }
}
