using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator animator;

    void OnEnable()
    {
        PlayerInput.OnMove += PlayerInput_OnMove;
    }

    void OnDisable()
    {
        PlayerInput.OnMove -= PlayerInput_OnMove;
    }

    void PlayerInput_OnMove(Vector2 moveDirection)
    {
        float isMoving = moveDirection.magnitude;
        animator.SetFloat("Speed", isMoving);
    }

}
