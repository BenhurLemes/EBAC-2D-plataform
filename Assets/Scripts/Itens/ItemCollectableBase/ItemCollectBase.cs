using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectBase : MonoBehaviour
{
    [Header("Variáveis")]
    [SerializeField] private string trigger;

    #region PRIVATES METHODS
    protected virtual void Collect()
    {
        gameObject.SetActive(false);
        OnCollect();
    }

    protected virtual void OnCollect()
    {
        // Implementar a lógica de coleta aqui
        Debug.Log("Item coletado!");
    }
    #endregion

    #region COLLISIONS AND TRIGGERS
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(trigger))
        {
            Collect();
        }
    }
    #endregion
}
