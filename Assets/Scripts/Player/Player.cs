using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Variáveis privadas")]
    [SerializeField] Movement movement;
    [SerializeField] HeathBase heath;

    #region UNITY METHODS
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
    #endregion


    #region COLISSION & TRIGGER
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("floor"))
        {
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
    #endregion

    #region GETTERS AND SETTERS
    public HeathBase GetHeath()
    {
        return heath;
    }

    public void HeathDamage(int damage)
    {
        heath.Damage(damage);
    }
    #endregion
}
