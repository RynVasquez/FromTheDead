using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Transform MainCharacterRefSpawner;
    [SerializeField] private List<Transform> spawnPoint;
    [SerializeField] private GameObject enemy;


    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform spawnpoint in spawnPoint)
        {
            enemy.GetComponent<ZombieMovement>().MainCharacterRef = MainCharacterRefSpawner;
            Instantiate(enemy, spawnPoint[0].position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
