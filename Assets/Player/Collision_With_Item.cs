using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Collision_With_Item : MonoBehaviour
{
    public InventoryPanel inventoryPanel;
    public GameObject objectQuest;
    QuestManager questManager;

    [SerializeField] private DataPlayer dataPlayer;

    private PlayerControls playerControls;
    Quest quest;
    bool questStatus;

    private Collider2D currentCollider;
    public bool interactOutsideCollider { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        questManager = objectQuest.GetComponent<QuestManager>();
    }

    void Awake()
    {
        playerControls = new PlayerControls();
        playerControls.Player.Enable();
    }

    /*void OnTriggerStay2D(Collider2D itemCollider)
    {
        questStatus = dataPlayer.HaveQuest;
        quest = itemCollider.GetComponent<Quest>();

        interactOutsideCollider = true;

        if (itemCollider.GetComponent<Quest>() != null)
        {
            if (questStatus == false && itemCollider.GetComponent<Quest>().parametersQuest.activeQuest == true)
            {
                questManager.ActiveQuest(itemCollider);
            }
            playerControls.Player.QuestInteract.performed += QuestInteract_performed;
        }
        if (itemCollider.GetComponent<ItemObject>())
        {
            inventoryPanel.AddItem(itemCollider.GetComponent<ItemObject>().scriptableObjectSO, itemCollider.GetComponent<ItemObject>(), itemCollider.gameObject.GetComponent<Collider2D>());
        }
    }*/

    void OnTriggerStay2D(Collider2D itemCollider)
    {
        questStatus = dataPlayer.HaveQuest;
        quest = itemCollider.GetComponent<Quest>();

        interactOutsideCollider = true;

        playerControls.Player.QuestInteract.performed += QuestInteract_performed;

        if (itemCollider.GetComponent<ItemObject>())
        {
            inventoryPanel.AddItem(itemCollider.GetComponent<ItemObject>().scriptableObjectSO, itemCollider.GetComponent<ItemObject>(), itemCollider.gameObject.GetComponent<Collider2D>());
        }
    }

    void OnTriggerEnter2D(Collider2D itemCollider)
    {
        if (itemCollider.GetComponent<Quest>() != null)
        {
            currentCollider = itemCollider;

            if (itemCollider.GetComponent<Quest>().parametersQuest.activeQuest == true && itemCollider.GetComponent<Quest>().parametersQuest.playerAcceptQuest == false)
            {
                questManager.ActiveQuest(itemCollider);
            }
        }
    }

    void OnTriggerExit2D(Collider2D itemCollider)
    {
        quest = itemCollider.GetComponent<Quest>();

        if (itemCollider.GetComponent<Quest>() != null)
        {
            if (itemCollider.GetComponent<Quest>().parametersQuest.playerAcceptQuest == false)
            {
                questManager.InactiveQuest(itemCollider.GetComponent<Quest>().temporaryWindowQuest);
            }
        }
        interactOutsideCollider = false;
    }

    void QuestInteract_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (quest.parametersQuest.activeQuest == true && quest.parametersQuest.playerAcceptQuest == true)
        {
            if (interactOutsideCollider)
            {
                quest.OnQuestInteract_CheckCompleteQuest();
            }
        }
    }

    /*void OnTriggerExit2D(Collider2D itemCollider)
    {
        if (itemCollider.GetComponent<Quest>() != null)
        {
            if (questStatus == false)
            {

                 questManager.InactiveQuest();
            }
        }
        interactOutsideCollider = false;
    }*/

    /*void QuestInteract_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (quest.parametersQuest.activeQuest == true && questStatus)
        {
            if (interactOutsideCollider)
            {
                OnQuestInteract?.Invoke();
            }
        }
    }*/
}
