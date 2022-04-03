using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 10.0f;
    private float spawnPosZ = 30.0f;

    private float startDelay = 2.0f;
    private float spawnInterval = 1.5f; 
    // Start is called before the first frame update

    public float sideSpawnMinZ;
    public float sideSpawnMaxZ;
    public float sideSpawnX;

    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
        InvokeRepeating("SpawnLeftAnimal", startDelay, spawnInterval);
        InvokeRepeating("SpawnRightAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.S))
        // {
        //     SpawnRandomAnimal();
        // }
    }

    void SpawnRandomAnimal()
    {
        // Randomly generate animal index and spawnPosition
        Vector3 spawnPos = new Vector3(Random.Range( -spawnRangeX, spawnRangeX), 0, spawnPosZ);
        int animalIndex = Random.Range(0,animalPrefabs.Length);
        // Instantiate game Object on position generated
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }

    void SpawnLeftAnimal()
    {
        int animalIndex = Random.Range(0,animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(sideSpawnX,0,Random.Range(sideSpawnMinZ, sideSpawnMaxZ));
        // rotate object
        Vector3 rotation = new Vector3(0, -90, 0);
        // Instantiate game Object on position generated
        Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(rotation));
    }

    void SpawnRightAnimal()
    {
        int animalIndex = Random.Range(0,animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(-sideSpawnX,0,Random.Range(sideSpawnMinZ, sideSpawnMaxZ));
        // rotate object
        Vector3 rotation = new Vector3(0, 90, 0);
        // Instantiate game Object on position generated
        Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(rotation));
    }
}
