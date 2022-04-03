using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    private float startDelay = 2;
    private float repeatRate = 1.5f;
    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        //instantiate a game Object Script file
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        //Invoke Repeating a function by setting start delay and repeat  rate 
        InvokeRepeating("SpawnObstacles", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacles () 
    {

        Vector3 spawnPos = new Vector3(Random.Range(30, 40), 0, 0);
        int index = Random.Range(0, obstaclePrefabs.Length);
        //if game Over in Player Controller script is false spawn Obstacle else do nothing
        if (playerController.gameOver == false)
        {
            //instantiate a prefab, assign position and set its rotation
            Instantiate(obstaclePrefabs[index], spawnPos, obstaclePrefabs[index].transform.rotation);
        }
    }
}
