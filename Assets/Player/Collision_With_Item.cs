using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;


public class Collision_With_Item : MonoBehaviour
{
    public GameObject firePlayer;
    FirePlayer firePlayerScript;

    public InventoryPanel inventoryPanel;
    public GameObject objectQuest;
    QuestManager questManager;

    [SerializeField] private DataPlayer dataPlayer;

    private PlayerControls playerControls;
    Quest quest;
    bool questStatus;

    private Collider2D currentCollider;
    public bool interactOutsideCollider { get; private set; }

    public static Action OnPlayerInteract;
    public static Action OnOpenShop;

   // Start is called before the first frame update
    void Start()
    {
        
        questManager = objectQuest.GetComponent<QuestManager>();
        
        if (firePlayerScript != null)
        {
            firePlayerScript = firePlayer.GetComponent<FirePlayer>();

        }
    }

    void Awake()
    {
        playerControls = new PlayerControls();
        playerControls.Player.Enable();
    }

    
    void OnTriggerStay2D(Collider2D itemCollider)
    {
        quest = itemCollider.GetComponent<Quest>();

        interactOutsideCollider = true;

        playerControls.Player.QuestInteract.performed += QuestInteract_performed;

        
        if (itemCollider.GetComponent<ItemObject>())
        {
            inventoryPanel.AddItem(itemCollider.GetComponent<ItemObject>().scriptableObjectSO, itemCollider.GetComponent<ItemObject>(), itemCollider.gameObject.GetComponent<Collider2D>());
            itemCollider.GetComponent<ItemObject>().Deactivate();
            if (itemCollider.GetComponent<BulletMovement>())
            {
                BulletPool.Instance.BulletAddList(itemCollider.gameObject);
            }
            else
            {
                ObjectPool.Instance.ItemObjectAddList(itemCollider.GetComponent<ItemObject>());

            }
        }
        

    }

    void Update()
    {
        playerControls.Player.Close.performed += OpenShop;

    }

    void OnTriggerEnter2D(Collider2D itemCollider)
    {
        if (itemCollider.GetComponent<Quest>() != null)
        {
            currentCollider = itemCollider;
            if (questManager != null)
            {
                if (itemCollider.GetComponent<Quest>().parametersQuest.activeQuest == true && itemCollider.GetComponent<Quest>().parametersQuest.playerAcceptQuest == false)
                {
                    questManager.ActiveQuest(itemCollider);
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D itemCollider)
    {
        quest = itemCollider.GetComponent<Quest>();

        if (itemCollider.GetComponent<Quest>() != null && questManager != null)
        {
            if (itemCollider.GetComponent<Quest>().parametersQuest.playerAcceptQuest == false)
            {
                questManager.InactiveQuest(itemCollider.GetComponent<Quest>().temporaryWindowQuest);
            }
        }

        CloseShop();
        interactOutsideCollider = false;
    }

    void QuestInteract_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnPlayerInteract?.Invoke();

        // Проверка на наличие quest
        if (quest != null && quest.parametersQuest != null)
        {
            if (quest.parametersQuest.activeQuest == true && quest.parametersQuest.playerAcceptQuest == true)
            {
                if (interactOutsideCollider)
                {
                    quest.OnQuestInteract_CheckCompleteQuest();
                }
            }
        }
    }

    void OpenShop(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnOpenShop?.Invoke();
    }

    void CloseShop()
    {
        OnOpenShop?.Invoke();
    }
}
