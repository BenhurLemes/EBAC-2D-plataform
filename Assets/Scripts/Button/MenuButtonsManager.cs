using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MenuButtonsManager : MonoBehaviour
{
    public List<GameObject> buttons;

    [Header("Animation")]
    public float duration = .2f;
    public float delay = .05f;
    public Ease ease = Ease.OutBack;

    private void OnEnable()
    {
        StartCoroutine(ShowButtons());
    }


    private IEnumerator ShowButtons()
    {
        foreach (var button in buttons)
        {
            if(button != null)
            {
                button.transform.localScale = Vector3.zero;
            }
        }

        yield return null;

        for(int i = 0; i < buttons.Count; i++)
        {

            if (buttons[i] != null)
            {
                buttons[i].transform.DOScale(1, duration)
                    .SetDelay(i * delay)
                    .SetEase(ease)
                    .SetLink(buttons[i]);
            }
        }

    }

    private void OnDisable()
    {
        foreach(var button in buttons)
        {
            if(button != null)
            {
                DOTween.Kill(button.transform);
            }
        }
    }

}
