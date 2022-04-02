using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionItem : MonoBehaviour
{
    private const string ShowTrigger = "show";
    private const string HideTrigger = "hide";

    [SerializeField] private Animator animator;

    public void ShowItem(bool show)
    {
        animator.SetTrigger(show ? ShowTrigger : HideTrigger);
    }
}
