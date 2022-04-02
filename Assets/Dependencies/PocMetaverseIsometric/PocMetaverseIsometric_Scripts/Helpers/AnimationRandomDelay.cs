using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationRandomDelay : MonoBehaviour
{
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        float randomDelay = Random.Range(0, animator.GetCurrentAnimatorStateInfo(0).length);
        animator.Play("Floating", 0, randomDelay);
    }
}
