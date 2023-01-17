using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10f;

    public bool gameOver;

    public float gravityMultiplier = 1.5f;
    
    private Rigidbody _rigidbody;
    private bool isOnTheGround = true;

    private Animator _animator;
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        Physics.gravity *= gravityMultiplier;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnTheGround && !gameOver)
        {
            isOnTheGround = false; // Dejo de tocar el suelo
            _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            // Llamamos al trigger para que se dé la transición de la animación de correr a salto
            _animator.SetTrigger("Jump_trig"); 
        }
    }
    
    private void OnCollisionEnter(Collision otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Obstacle"))
        {
            GameOver();
        } 
        else if (otherCollider.gameObject.CompareTag("Ground"))
        {
            isOnTheGround = true;
        }
    }

    private void GameOver()
    {
        gameOver = true;
        _animator.SetBool("Death_b", true);
        _animator.SetInteger("DeathType_int", Random.Range(1, 3));
    }
}
