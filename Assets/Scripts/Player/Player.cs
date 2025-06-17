using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Movement movement;
    [SerializeField] HeathBase heath;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("floor")){
            movement.SetJumping();
        }

        if (collision.gameObject.CompareTag("spike"))
        {
            heath.Damage(2);
        }
    }

    private void Start()
    {
        movement = GetComponent<Movement>();
        heath = GetComponent<HeathBase>();
    }

    private void Update()
    {
        movement.HandleMovement();
        movement.HandleJump();
    }
}
