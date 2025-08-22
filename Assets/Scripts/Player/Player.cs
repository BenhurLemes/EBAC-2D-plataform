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
            movement.SetAnimationFalses();
            movement.SetJumping();
            Debug.Log("Landed on: " + collision.transform.name);
        }

        if (collision.gameObject.CompareTag("spike"))
        {
            heath.Damage(1000);
            Debug.Log(collision.transform.name);
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
