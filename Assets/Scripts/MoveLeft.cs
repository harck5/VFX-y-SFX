using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 30f;
    private float leftBound = -15;

    private PlayerController playerControllerScript;

    private void Start()
    {
        playerControllerScript = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        if (!playerControllerScript.gameOver)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed, Space.World);
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
