using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AnimationWindowQuest : MonoBehaviour
{
    [SerializeField] private Collision_With_Item collision_With_Item;
    private Collision_With_Item collision_With_ItemScript;

    Animator animator;
    [SerializeField] private CanvasGroup canvasGroup;

    DisablingButton disablingButton;
    Data_QuestWindow data_QuestWindow;

    void Start()
    {
        animator = GetComponent<Animator>();

        canvasGroup = GetComponent<CanvasGroup>();
        collision_With_ItemScript = collision_With_Item.GetComponent<Collision_With_Item>();
        data_QuestWindow = GetComponent<Data_QuestWindow>();
        disablingButton = GetComponent<DisablingButton>();
    }

    public void QuestComplete()
    {
        /*animator.SetBool("QuestComplete", true);*/
        StartCoroutine(QuestCompleteCoroutine());
    }

    public void NotPlayAnimation()
    {
        animator.SetBool("QuestComplete", false);
    }

    public void AcceptQuest()
    {

        animator.SetBool("AcceptQuest", true);
        disablingButton.DisablingAndEnablingButton();
    }

    public void DropQuest()
    {
        if (collision_With_ItemScript != null)
        {
            if (collision_With_ItemScript.interactOutsideCollider)
            {
                data_QuestWindow.ActiveQuest();
                animator.SetBool("AcceptQuest", false);

            }
            if(!collision_With_ItemScript.interactOutsideCollider)
            {
                data_QuestWindow.InactiveQuest();
            }
        }
    }

    IEnumerator QuestCompleteCoroutine()
    {
        animator.SetBool("AcceptQuest", false);

        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        QuestComplete_Idle();
    }


    void QuestComplete_Idle()
    {
        if (data_QuestWindow.temporarySelectedParametersQuest.activeQuest == false)
        {
            data_QuestWindow.InactiveQuest();
        }
        else
        {
            data_QuestWindow.ActiveQuest();
        }
    }


}

