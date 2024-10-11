using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    private float spawnRange = 9;
    public int wave = 1;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(wave);
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate (enemyPrefab, getRandomSpawnPosition(), enemyPrefab.transform.rotation);
        }
        Instantiate(powerupPrefab, getRandomSpawnPosition(), powerupPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        int enemyCount = GameObject.FindObjectsOfType<EnemyController>().Length;
        if (enemyCount == 0) SpawnEnemyWave(++wave);
    }

    Vector3 getRandomSpawnPosition()
    {
        float spawnX = Random.Range(-spawnRange, spawnRange);
        float spawnZ = Random.Range(-spawnRange, spawnRange);
        Vector3 newPosition = new Vector3(spawnX, 0, spawnZ);

        return newPosition;
    }
}
