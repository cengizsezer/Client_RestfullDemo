using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AnimationUtil
{
    public static IEnumerator PlayAnimAndSetStateWhenFinished(GameObject parent, Animator animator, string clipName,
        bool activeStateAtTheEnd = true)
    {
        animator.Play(clipName);
        var animationLength = animator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSecondsRealtime(animationLength);
        parent.SetActive(activeStateAtTheEnd);
    }
}
