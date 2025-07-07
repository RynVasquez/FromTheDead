using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<Enemy> enemies = new List<Enemy>();
    public int currWave;
    public int waveValue;
    public List<GameObject> enemiesToSpawn = new List<GameObject>();

    [SerializeField] private Transform MainCharacterRefSpawner;


    [SerializeField] private GameObject spawnPoint;
    public int waveDuration;
    private float waveTimer;
    private float spawnInterval;
    private float spawnTimer;

    [SerializeField] private GameObject enemyRef;
    [SerializeField] private int totalEnemiesToSpawn = 10;
    //[SerializeField] private float spawnInterval = 2f; // seconds between spawns

    void Start()
    {
        //StartCoroutine(SpawnEnemiesOverTime());
        GenerateWave();
    }

    void FixedUpdate()
    {
        if (spawnTimer <= 0)
        {
            if (enemiesToSpawn.Count > 0)
            {
                Instantiate(enemiesToSpawn[0], spawnPoint.transform.position, Quaternion.identity);
                enemiesToSpawn[0].GetComponent<ZombieMovement>().MainCharacterRef = MainCharacterRefSpawner;
                enemiesToSpawn.RemoveAt(0);
                spawnTimer = spawnInterval;
            }
            else
            {
                waveTimer = 0;
            }
        }
        else
        {
            spawnTimer -= Time.fixedDeltaTime;
            waveTimer -= Time.fixedDeltaTime;
        }
    }

    public void GenerateWave()
    {
        waveValue = currWave * 10;
        GenerateEnemies();

        spawnInterval = waveDuration / enemiesToSpawn.Count;
        waveTimer = waveDuration;
    }

    public void GenerateEnemies()
    {
        List<GameObject> generatedEnemies = new List<GameObject>();
        while (waveValue > 0)
        {
            int randEnemyID = Random.Range(0, enemies.Count);
            int randEnemyCost = enemies[randEnemyID].cost;

            if (waveValue - randEnemyCost >= 0)
            {
                generatedEnemies.Add(enemies[randEnemyID].enemyPrefab);
                waveValue -= randEnemyCost;
            }
            else if (waveValue <= 0)
            {
                break;
            }

            enemiesToSpawn.Clear();
            enemiesToSpawn = generatedEnemies;
        }
    }
}

[System.Serializable]
public class Enemy
{
    public GameObject enemyPrefab;
    public int cost;
}

//IEnumerator SpawnEnemiesOverTime()
//{
//    int randomIndex = Random.Range(0, spawnPoint.Count);
//    Transform spawnPos = spawnPoint[randomIndex];

//    // Instantiate enemy
//    GameObject newEnemy = Instantiate(enemy, spawnPos.position, Quaternion.identity);
//    newEnemy.GetComponent<ZombieMovement>().MainCharacterRef = MainCharacterRefSpawner;

//    // Wait before spawning the next enemy
//    yield return new WaitForSeconds(spawnInterval);
//}
