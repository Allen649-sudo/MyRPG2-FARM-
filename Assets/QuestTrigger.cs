using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTrigger : MonoBehaviour
{
    Quest quest;
    public GameObject questManager;

    void Start()
    {
        quest = GetComponent<Quest>();
    }

    void OnTriggerExit2D(Collider2D itemCollider)
    {
        if (quest.parametersQuest.playerAcceptQuest == false)
        {
            questManager.GetComponent<QuestManager>().InactiveQuest(quest.temporaryWindowQuest);
        }
    }
}
