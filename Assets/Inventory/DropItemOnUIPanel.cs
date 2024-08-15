using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class DropItemOnUIPanel : MonoBehaviour, IDropHandler
{
    [SerializeField] private InventoryPanel inventoryPanel;
    private InventoryPanel inventoryPanelScripts;

    void Awake()
    {
        inventoryPanelScripts = inventoryPanel.GetComponent<InventoryPanel>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        DragAndDrop.OnDropItem += GetDragAndDrop;
    }

    void OnDisable()
    {
        DragAndDrop.OnDropItem -= GetDragAndDrop;
    }

    void GetDragAndDrop(DragAndDrop dragAndDrop)
    {
        ObjectPool.Instance.ActivateItem(dragAndDrop.inventorySlot.count, dragAndDrop.inventorySlot.scriptableObjectSO);
        inventoryPanelScripts.ResetDragAndDrop(dragAndDrop);
        OnDisable();
        
    }
}