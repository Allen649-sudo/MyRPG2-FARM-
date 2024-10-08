using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreaturesAnimation : MonoBehaviour
{
    public Animator animator;

    public void AnimAttack()
    {
        animator.SetBool("Attack", true);
    }

    public void AnimDeactiveAttack()
    {
        animator.SetBool("Attack", false);
    }

    public void Animation(Vector3 moveDirection, Vector3 lastMoveDirection, Vector3 lastAttack)
    {       
        animator.SetFloat("Horizontal", moveDirection.x);
        animator.SetFloat("Vertical", moveDirection.y);

        animator.SetFloat("AnimMoveMagnitude", moveDirection.magnitude);

        animator.SetFloat("AnimLastMoveX", lastMoveDirection.x);
        animator.SetFloat("AnimLastMoveY", lastMoveDirection.y);

        animator.SetFloat("AnimLastAttackX", lastAttack.x);
        animator.SetFloat("AnimLastAttackY", lastAttack.y);
    }
}
