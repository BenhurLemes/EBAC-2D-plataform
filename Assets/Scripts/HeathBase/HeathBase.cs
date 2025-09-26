using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeathBase : MonoBehaviour
{
    [Header("Variáveis privadas")]
    [SerializeField] int life;
    [SerializeField] int _currentlife;
    private bool _isDead = false;

    //--------------------------//

    [Header("Variáveis Animação")]
    [SerializeField] Animator animator;
    [SerializeField] string triggerToAnimationDeath = "Death";
    [SerializeField] float delayKill = 1.5f;

    //--------------------------//

    [Header("Variáveis Classes")]
    [SerializeField] FlashColor _flashcolor;

    #region UNITY METHODS
    private void Awake()
    {
        init();
        if (_flashcolor == null)
        {
            _flashcolor = gameObject.GetComponent<FlashColor>();
        }
    }
    #endregion

    #region PRIVATE METHODS

    private void init()
    {
        _currentlife = life;
        _isDead = false;
    }

    private void Kill()
    {
        _isDead = true;
        animator.SetBool(triggerToAnimationDeath, true);
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
        if(_flashcolor != null)
        {
            _flashcolor.Flash();
        }
    }
    #endregion

    #region GETTERS AND SETTERS
    public bool getDead()
    {
        return _isDead;
    }
    #endregion
}
