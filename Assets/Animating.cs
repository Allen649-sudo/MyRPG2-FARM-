using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animating : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void StartAnimLoading()
    {
        animator.SetBool("Fade", true);
    }
}
