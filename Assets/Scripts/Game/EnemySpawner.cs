using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner instance;

    void Awake()
    {
        instance = this;
    }

    // Enemy prefabs
    public List<GameObject> prefabs;

    // Enemy spawn root points
    public List<Transform> spawnPoints;

    // Enemy spawn interval
    public float spawnInterval = 11f;

    public int enemiesSpawned = 0;

    public int enemiesKilled = 0;

    public bool userHasWon = false;

    public int stopUpdateFunctionLoop = 0;

    public int totalNumberOfEnemies;

    public GameObject panelYouWin;

    void Update()
    {
        if (enemiesKilled > enemiesSpawned)
        {
            enemiesKilled = enemiesSpawned;
        }

        if (enemiesKilled > 49)
        {
            userHasWon = true;
        }

        if (userHasWon == true && stopUpdateFunctionLoop == 0)
        {
            StartCoroutine(WaitBeforeRestartingScene2());

            stopUpdateFunctionLoop = 1;
        }
    }

    IEnumerator WaitBeforeRestartingScene2()
    {
        panelYouWin.SetActive(true);

        yield return new WaitForSeconds(5f);

        BackToMainMenuFromVictory();
    }

    public void BackToMainMenuFromVictory()
    {
        SceneManager.LoadScene(0);
    }

    public void StartSpawning()
    {
        // Call the spawn coroutine
        StartCoroutine(SpawnDelay());
    }

    IEnumerator SpawnDelay()
    {
        if (enemiesSpawned > 49)
        {
            yield break;
        }

        else
        {
            if (enemiesSpawned > -1 && enemiesSpawned < 5)
            {
                spawnInterval = 11f;

                // Wait spawn interval
                yield return new WaitForSeconds(spawnInterval);

                // Call the spawn method
                SpawnEnemy();
            }

            if (enemiesSpawned > 4 && enemiesSpawned < 10)
            {
                spawnInterval = 9f;

                // Wait spawn interval
                yield return new WaitForSeconds(spawnInterval);

                // Call the spawn method
                SpawnEnemy();
            }

            if (enemiesSpawned > 9 && enemiesSpawned < 20)
            {
                spawnInterval = 7f;

                // Wait spawn interval
                yield return new WaitForSeconds(spawnInterval);

                // Call the spawn method
                SpawnEnemy();
            }

            if (enemiesSpawned > 19 && enemiesSpawned < 30)
            {
                spawnInterval = 5f;

                // Wait spawn interval
                yield return new WaitForSeconds(spawnInterval);

                // Call the spawn method
                SpawnEnemy();
            }

            if (enemiesSpawned > 29 && enemiesSpawned < 51)
            {
                spawnInterval = 3f;

                // Wait spawn interval
                yield return new WaitForSeconds(spawnInterval);

                // Call the spawn method
                SpawnEnemy();
            }
        }

        // Recall the same coroutine
        StartCoroutine(SpawnDelay());
    }

    void SpawnEnemy()
    {
        // Randomise the enemy spawned
        int randomPrefabID = Random.Range(0, prefabs.Count);

        // Randomise the spawn point
        int randomSpawnPointID = Random.Range(0, spawnPoints.Count);

        // Instantiate the enemy prefab
        GameObject spawnedEnemy = Instantiate(prefabs[randomPrefabID], spawnPoints[randomSpawnPointID]);

        enemiesSpawned++;
    }
}
