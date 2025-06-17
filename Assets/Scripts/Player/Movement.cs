using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Movement : MonoBehaviour
{
    [Header("Variáveis")]
    [SerializeField] Vector2 friction = new Vector2(-.1f, 0f);
    [SerializeField] Rigidbody2D Rb;

    [Header("Speed setup")]
    [SerializeField] float speed;
    [SerializeField] float speedRun;
    private float currentSpeed;

    [SerializeField] float jumpForce = 10f; // 15f ideal
    private bool ISJUMPING = false;

    [Header("Animation jumping setup")]
    [SerializeField] float jumpingScaleX = 0.8f; // 0.9f ideal
    [SerializeField] float jumpingScaleY = 1.2f; // 1.2f ideal
    [SerializeField] float animationJumpingDuration = 0.3f;

    [SerializeField] Ease ease = Ease.OutBack;

    #region Métodos 
    /// <summary>
    /// getter Speed
    /// </summary>
    /// <returns> retorna a sua atual velocidaed
    /// </returns>
    public float getSpeed()
    {
        return currentSpeed;
    }

    /// <summary>
    /// setter de Jumping
    /// </summary>
    /// <returns> sem retorno, apenas altera o valor do ISJUMPING para falso e reseta o 
    /// transform do objeto para a forma padrão
    /// </returns>
    public void SetJumping()
    {
        ISJUMPING = false;
        Rb.transform.localScale = Vector2.one;
    }

    /// <summary>
    /// movimento plataforma com dash
    /// </summary>
    /// <returns> sem retorno, mas altera o movimento do player</returns>
    public void HandleMovement()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            currentSpeed = speedRun;
        }
        else
        {
            currentSpeed = speed;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Rb.velocity = new Vector2(currentSpeed, Rb.velocity.y);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Rb.velocity = new Vector2(-currentSpeed, Rb.velocity.y);
        }

        Rb.velocity += friction * (Rb.velocity.x > 0 ? 1 : -1);
    }

    /// <summary>
    /// Movimento de Player
    /// </summary>
    /// <returns> sem retorno, mas cria um impulso no vertical (y) com o movimento horizontal atual (x) </returns>
    public void HandleJump()
    {   
        if (Input.GetKeyDown(KeyCode.Space) && !ISJUMPING)
        {
            Rb.velocity = new Vector2(Rb.velocity.x, jumpForce);
            ISJUMPING = true;
            HandleScaleJump();
        }
    }
    #endregion

    #region Metodos de Animação
    /// <summary>
    /// Animação de pulo
    /// </summary>
    /// <returns> sem retorno, mas distorce o corpo quando pula e volta fazendo animação de yoyo </returns>
    public void HandleScaleJump()
    {
        DOTween.Complete(Rb.transform);
        Rb.transform.DOScaleX(jumpingScaleX, animationJumpingDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        Rb.transform.DOScaleY(jumpingScaleY, animationJumpingDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }

    #endregion

    #region Anotações para estudo
    //[Header("Animation squash setup")]
    //[SerializeField] float squashScaleX = 1.2f;
    //[SerializeField] float squashScaleY = 0.8f;
    //[SerializeField] float minFallHeightForSquash = 3f;
    //[SerializeField] float fallAnimationDuration = 0.2f;
    //[SerializeField] float initialPositionY;
    //[Header("Animation dashing setup")]
    //[SerializeField] float dashingScaleX = 1.5f; // 1.5f ideal
    //[SerializeField] float dashingScaleY = 0.8f; // 0.8f ideal
    //[SerializeField] float animationDashingDuration = 0.3f;
    //private bool ISDASHING = false; 

    /// <summary>
    /// Animação de achatar
    /// </summary>
    /// <returns> sem retorno, mas distorce o corpo quando cai no chão numa certa altura e volta fazendo animação de yoyo </returns>
    /*
    public void HandleScaleSquash(float fallHeight)
    {
        DOTween.Kill(Rb.transform);
        float squashIntensity = Mathf.Clamp(fallHeight / minFallHeightForSquash, 1f, 3f);

        Rb.transform.DOScaleY(squashScaleY / squashIntensity, fallAnimationDuration)
            .SetLoops(2, LoopType.Yoyo)
            .SetEase(Ease.OutBounce);

        Rb.transform.DOScaleX(squashScaleX * squashIntensity, fallAnimationDuration)
            .SetLoops(2, LoopType.Yoyo)
            .SetEase(Ease.OutBounce);

    }
    */


    /*
    private void Update()
    {
        if (ISJUMPING && Rb.velocity.y < 0)
        {
            float fallHeight = initialYPosition - Rb.position.y;
            if (fallHeight >= minFallHeightForSquash)
            {
                HandleScaleSquash(fallHeight);
            }
        }
    }
    */

    /// <summary>
    /// Animação de dash
    /// </summary>
    /// <returns> sem retorno, mas distorce o corpo quando faz um dash e volta fazendo animação de yoyo </returns>
    /*
    public void HandleScaleDash()
    {
        if (!ISJUMPING)
        {
            Rb.transform.DOScaleX(dashingScaleX, animationDashingDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
            Rb.transform.DOScaleY(dashingScaleY, animationDashingDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        }

    }
    */

    /// <summary>
    /// setter de Dashing
    /// </summary>
    /// <returns> sem retorno, apenas altera o valor do DASHING para falso e reseta o 
    /// transform do objeto para a forma padrão
    /// </returns>
    /*
    public IEnumerator SetDashing()
    {
        ISDASHING = true;
        HandleScaleDash();
        yield return new WaitForSeconds(1f);
        ISDASHING = false;
    }
    */
    #endregion
}
