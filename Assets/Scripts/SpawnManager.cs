using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{

    private float startDelay = 2f;
    private float repeatRate = 2f;
    public GameObject[] obstaclePrefabs;

    private PlayerController playerControllerScript;

    private void Start()
    {
        playerControllerScript = FindObjectOfType<PlayerController>();
        
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    private void Update()
    {
        if (playerControllerScript.gameOver)
        {
            CancelInvoke("SpawnObstacle");
        }
    }

    private void SpawnObstacle()
    {
        int randomIdx = Random.Range(0, obstaclePrefabs.Length);
        Instantiate(obstaclePrefabs[randomIdx], transform.position, obstaclePrefabs[randomIdx].transform.rotation);
    }
}
