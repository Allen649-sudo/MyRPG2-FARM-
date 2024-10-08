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

    [SerializeField] private DataPlayer dataPlayer;

    private PlayerControls playerControls;
    Quest quest;

    private Collider2D currentCollider;
    public bool interactOutsideCollider { get; private set; }

    public static Action OnClose;

    private GameObject interactObject;

   // Start is called before the first frame update
    void Start()
    {
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

    void Update()
    {
        playerControls.Player.Close.performed += Close;
    }

    void Close(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnClose?.Invoke();
    }

    void OnTriggerStay2D(Collider2D itemCollider)
    {
        interactObject = itemCollider.gameObject;
        quest = itemCollider.GetComponent<Quest>();
        interactOutsideCollider = true;

        playerControls.Player.QuestInteract.performed += QuestInteract_performed;
        
        if (itemCollider.GetComponent<ItemObject>())
        {
            inventoryPanel.AddItem(itemCollider.GetComponent<ItemObject>().scriptableObjectSO, itemCollider.GetComponent<ItemObject>(), itemCollider.gameObject.GetComponent<Collider2D>(), itemCollider.gameObject);
            itemCollider.GetComponent<ItemObject>().Deactivate();
            
            if (itemCollider.GetComponent<BulletMovement>())
            {
                ObjectPool.Instance.ItemObjectAddList(itemCollider.GetComponent<ItemObject>());
            }
        }
    }

    private void OnDisable()
    {
        playerControls.Player.Disable();
    }

    void OnTriggerExit2D(Collider2D itemCollider)
    {
        quest = itemCollider.GetComponent<Quest>();
        interactOutsideCollider = false;
    }

    void QuestInteract_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {

        if (interactOutsideCollider)
        {
            interactObject.GetComponent<InteractWithPlayer>().Interact();
            quest.OnQuestInteract_CheckCompleteQuest();
        }
    }

}
