using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class InventoryPanel : MonoBehaviour
{
    public List<InventorySlot> suitableSlots = new List<InventorySlot>();

    bool isOpened = false;

    public static InventoryPanel Instance { get; private set; }

    public Transform mainSlots;
    public Transform quikSlots;

    public void CheckInventorySlotHavescriptableObjectSO(InventorySlot inventorySlot)
    {
        if (inventorySlot.scriptableObjectSO == null)
        {
            suitableSlots.Add(inventorySlot);
        }
    }

    void Start()
    {
        Instance = this;

        for (int i = 0; i < quikSlots.childCount; i++)
        {
            Transform child = quikSlots.transform.GetChild(i);
            InventorySlot inventorySlot = child.GetComponent<InventorySlot>();

            if (inventorySlot != null)
            {
                CheckInventorySlotHavescriptableObjectSO(inventorySlot);
            }
        }
        for (int i = 0; i < mainSlots.childCount; i++)
        {
            Transform child = mainSlots.transform.GetChild(i);
            InventorySlot inventorySlot = child.GetComponent<InventorySlot>();

            if (inventorySlot != null)
            {
                CheckInventorySlotHavescriptableObjectSO(inventorySlot);
            }
        }
        mainSlots.gameObject.SetActive(false);
    }

    public void ExchangescriptableObjectSOBetweenSlots(DragAndDrop dragAndDrop, DropItemBetweenSlots dropItemBetweenSlots)
    {
        dropItemBetweenSlots.inventorySlot.scriptableObjectSO = dragAndDrop.inventorySlot.scriptableObjectSO;
        dropItemBetweenSlots.inventorySlot.count = dragAndDrop.inventorySlot.count;
        dropItemBetweenSlots.inventorySlot.itemAmountText.text = dragAndDrop.inventorySlot.itemAmountText.text;
        dropItemBetweenSlots.inventorySlot.iconGO.GetComponent<Image>().sprite = dragAndDrop.inventorySlot.scriptableObjectSO.sprite;

        ResetDragAndDrop(dragAndDrop);
    }

    public void ResetDragAndDrop(DragAndDrop dragAndDrop)
    {
        dragAndDrop.inventorySlot.scriptableObjectSO = null;
        dragAndDrop.inventorySlot.count = 0;
        dragAndDrop.inventorySlot.itemAmountText.text = null;
        dragAndDrop.inventorySlot.iconGO.GetComponent<Image>().sprite = Resources.Load<Sprite>("Empty");
    }

    public void AddItem(ScriptableObjectSO scriptableObjectSO, ItemObject itemObject, Collider2D itemCollider, GameObject prefabItem)
    {
        foreach (InventorySlot slot in suitableSlots)
        {
            if (slot.scriptableObjectSO == null)
            {
                slot.itemPrefab = prefabItem;
                slot.scriptableObjectSO = scriptableObjectSO;
                slot.iconGO.GetComponent<Image>().sprite = scriptableObjectSO.sprite;
                slot.count++;
                break;
            }
            else if (slot.scriptableObjectSO == scriptableObjectSO && slot.count + scriptableObjectSO.amount <= scriptableObjectSO.maxStackable)
            {
                slot.count++;
                slot.CountInText();
                return;
            }
            else
            {
                continue;
            }

        }
    }
}
