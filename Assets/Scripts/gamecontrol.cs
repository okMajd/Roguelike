using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class gamecontrol : MonoBehaviour
{
    public int wave;
    public int secondsPerWave = 60;
    int timeLeft = 60;
    public TextMeshProUGUI timer;
    public TextMeshProUGUI waveText;
    public enemyTracker enemyTracker;
    public float spawnedSoFar = 0f;
    public float maxEnemies;
    public float actualSpawnDelay;
    public float SpawnDelay = 2f;
    public float minDelay, maxDelay;

    //spawning enemies
    public GameObject enemyPre;

    public Transform corner1, corner2;
    private void Start()
    {
        actualSpawnDelay = SpawnDelay;

        beginWave();
    }

    public bool waiting = false;
    private void Update()
    {
        timer.text = $"{timeLeft}";
        if(enemyTracker.enemies.Count <=1 && !waiting)
        {
            waiting = true;
            StartCoroutine("checkDone");
        }
    }

    IEnumerator checkDone()
    {
        yield return new WaitForSeconds(3f);
        if(enemyTracker.enemies.Count <=1)
        {
            Debug.Log("all killed");
            endWave();
            waiting = false;
        }else{
            Debug.Log("false positive!");
            waiting = false;
        }
    }

    void beginWave()
    {
        wave++;
        waveText.text = $"Wave {wave}";
        timeLeft = 60;
        spawnedSoFar = 0;
        maxEnemies = Mathf.Round(15 * Mathf.Pow(wave, 0.23f));
        StartCoroutine("waveTimer");
        StartCoroutine("spawnEnemies");
    }

    void endWave()
    {
        StopCoroutine("spawnEnemies");
        StopCoroutine("waveTimer");
        beginWave();

    }

    Vector2 generateLocation()
    {
        return new Vector2(Random.Range(corner1.position.x, corner2.position.x), Random.Range(corner1.position.y, corner2.position.y));
    }

    IEnumerator spawnEnemies()
    {
        float delay = Random.Range(minDelay, maxDelay);
        if(timeLeft > delay && spawnedSoFar < maxEnemies)
        {
            yield return new WaitForSeconds(delay);
            GameObject enemy = Instantiate(enemyPre, generateLocation(), Quaternion.identity);
            enemyTracker.enemies.Add(enemy);
            spawnedSoFar++;
            StartCoroutine("spawnEnemies"); 
        }else{
            StopCoroutine("spawnEnemies");
        }

    }

    IEnumerator waveTimer()
    {
        if(timeLeft > 0)
        {
            yield return new WaitForSeconds(1f);
            timeLeft--;
            StartCoroutine("waveTimer");
        }else{
            endWave();
        }
    }
}
