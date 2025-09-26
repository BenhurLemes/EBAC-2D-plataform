using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlashColor : MonoBehaviour
{
    [Header("Variáveis privadas")]
    public List<SpriteRenderer> spriteRenderers;
    public Color flashColor = Color.red;
    public float flashDuration = .3f;
    private Tween _currentTwen;

    #region UNITY METHODS
    private void OnValidate()
    {
        spriteRenderers = new List<SpriteRenderer>();
        foreach(var child in transform.GetComponentsInChildren<SpriteRenderer>())
        { 
            spriteRenderers.Add(child);
        }
    }
    #endregion

    #region PRIVATE METHODS
    public void Flash()
    {
        if(_currentTwen != null)
        {
            _currentTwen.Kill();
            spriteRenderers.ForEach(i => i.color = Color.white);
        }

        foreach(var spriteRenderer in spriteRenderers)
        {       
            spriteRenderer.DOColor(flashColor, flashDuration).SetLoops(2, LoopType.Yoyo);
        }
    }
    #endregion
}
