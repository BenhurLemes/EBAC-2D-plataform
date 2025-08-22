using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeathBase : MonoBehaviour
{
    [Header("Variáveis padrão")]
    [SerializeField] int life;
    [SerializeField] int _currentlife;
    private bool _isDead = false;
    [SerializeField] float delayKill = 1.5f;

    [Header("Variáveis Animação")]
    [SerializeField] Animator animator;
    [SerializeField] string triggerToPlay = "Death";

    #region unity methods
    private void Awake()
    {
        init();
    }
    #endregion

    #region private methods

    private void init()
    {
        _currentlife = life;
        _isDead = false;
    }

    private void Kill()
    {
        _isDead = true;
        animator.SetBool(triggerToPlay, true);
        Destroy(gameObject, delayKill);
    }

    public void Damage(int damage)
    {
        if (_isDead)
        {
            return;
        }
        else
        {
            _currentlife -= damage;
            if (_currentlife <= 0)
            {
                Kill();
            }
        }
    }
    #endregion
    #region getters and setters
    public bool getDead()
    {
        return _isDead;
    }
    #endregion
}
