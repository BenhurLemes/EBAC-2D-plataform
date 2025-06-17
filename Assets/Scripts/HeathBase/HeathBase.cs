using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeathBase : MonoBehaviour
{
    [SerializeField] int life;
    [SerializeField] int _currentlife;
    private bool _isDead = false;
    [SerializeField] float delayKill = 2f;

    private void Awake()
    {
        init();
    }

    private void init()
    {
        _currentlife = life;
        _isDead = false;
    }

    private void Kill()
    {
        _isDead = true;
        Destroy(gameObject, delayKill);
    }

    public void Damage(int damage)
    {
        if (_isDead) return;
        else
        { 
            _currentlife -= damage;
            if (_currentlife <= 0)
            {
                Kill();
            }
        }
    }
}
