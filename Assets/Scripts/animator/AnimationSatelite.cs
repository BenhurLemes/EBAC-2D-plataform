using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSatelite : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] string triggerToPlay = "flybool";
    [SerializeField] bool AnimationActive = false;
    private const float switchTime = 5f;

    // uma função que valida um valor
    private void OnValidate()
    {
        if(animator == null) animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Start()
    {
        StartCoroutine(SwitchAnimationRoutine());
    }

    IEnumerator SwitchAnimationRoutine()
    {
        while (true)
        {
            AnimationActive = !AnimationActive;
            animator.SetBool(triggerToPlay, AnimationActive);
            yield return new WaitForSeconds(switchTime);
        }
    }



}
