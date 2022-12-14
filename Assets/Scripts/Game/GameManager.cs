using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    public Spawner spawner;
    public HealthSystem health;
    public CurrencySystem currency;

    void Start()
    {
        GetComponent<HealthSystem>().Init();
        GetComponent<CurrencySystem>().Init();

        StartCoroutine(WaveStartDelay());
    }

    IEnumerator WaveStartDelay()
    {
        // Wait for X seconds
        yield return new WaitForSeconds(5f);

        // Start the enemy spawning
        GetComponent<EnemySpawner>().StartSpawning();
    }
}
