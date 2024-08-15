using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    /*public GameObject UIPanel;
    private Camera mainCamera;
    public Transform inventoryPanel;
    public Collision_With_Item collisionWithItem;
    public GameObject player;

    public List<InventorySlot> slots = new List<InventorySlot>();
    public bool isOpened;


    // Start is called before the first frame update
    private void Awake()
    {
        UIPanel.SetActive(true);
    }
    void Start()
    {
        mainCamera = Camera.main;
        player = GameObject.Find("Player");
        collisionWithItem = player.GetComponent<Collision_With_Item>();

        for (int i = 0; i < inventoryPanel.childCount; i++)
        {
            if (inventoryPanel.GetChild(i).GetComponent<InventorySlot>() != null)
            {
                slots.Add(inventoryPanel.GetChild(i).GetComponent<InventorySlot>());
            }
        }
        UIPanel.SetActive(false);
        inventoryPanel.gameObject.SetActive(false);//new line

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isOpened = !isOpened;
            if (isOpened)
            {
                UIPanel.SetActive(true);
                inventoryPanel.gameObject.SetActive(true); // new line
            }
            else
            {
                UIPanel.SetActive(false);
                inventoryPanel.gameObject.SetActive(false); // new line
            }
        }
       
    }

    public void FindItem(Collider2D itemCollider)
    {
        if (itemCollider.gameObject.GetComponent<Item>() != null)
        {
            AddItem(itemCollider.GetComponent<Item>().item, itemCollider.GetComponent<Item>().amount, itemCollider);
        }
    }

    public void AddItem(ItemScriptableObject _item, int _amount, Collider2D itemCollider)
    {
        foreach (InventorySlot slot in slots)
        {
            if (slot.isEmpty == true)
            {
                Destroy(itemCollider.gameObject);

                slot.iconGO.SetActive(true);
                slot.isEmpty = false;

                slot.item = _item;
                slot.amount = _amount;
                slot.SetIcon(_item.icon);
                slot.itemAmountText.text = _amount.ToString();
                break;
            }

            if (slot.item == _item)
            {
                if (slot.amount + _amount <= _item.maximumAmount)
                {
                    Destroy(itemCollider.gameObject);

                    slot.iconGO.SetActive(true);

                    slot.amount += _amount;
                    slot.itemAmountText.text = slot.amount.ToString();
                    return;

                }

            }
        }
    }*/
}
