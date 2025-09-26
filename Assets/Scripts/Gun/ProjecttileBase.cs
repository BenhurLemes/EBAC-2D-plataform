using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjecttileBase : MonoBehaviour
{
    [Header("Variáveis privadas")]
    [SerializeField] Vector3 direction;
    private float timeToDestroy = 3f;
    private float side = 1;
    private int damageamount = 9999;

    #region UNITY METHODS
    private void Awake()
    {
        Destroy(gameObject, timeToDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * Time.deltaTime * side);
    }
    #endregion

    #region GETTERS AND SETTERS

    public float getSide()
    {
        return side;
    }
    
    public void setSide(float value)
    {
        side = value;
    }

    #endregion

    #region COLLISION AND TRIGGERS
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("enemy"))
        {
            collision.gameObject.GetComponent<EnemyBase>().HeathDamage(damageamount);
            Destroy(gameObject);
        }
    }
    #endregion
}
