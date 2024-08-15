using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class DropItemBetweenSlots : MonoBehaviour, IDropHandler
{
    [SerializeField] private InventoryPanel inventoryPanel;
    private InventoryPanel inventoryPanelScripts;
    [HideInInspector] public InventorySlot inventorySlot;


    void Awake()
    {
        inventorySlot = GetComponent<InventorySlot>();
        inventoryPanelScripts = inventoryPanel.GetComponent<InventoryPanel>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (inventorySlot.scriptableObjectSO == null)
        {
            var otherItemTransform = eventData.pointerDrag.transform;
        
            var dragAndDropComponent = otherItemTransform.GetComponent<DragAndDrop>();
        
            if (dragAndDropComponent != null)
            {
                SendDragAndDropAndDropItemBetweenSlots(dragAndDropComponent); 
            }
        }
    }

    public void SendDragAndDropAndDropItemBetweenSlots(DragAndDrop dragAndDrop)
    {
        InventoryPanel.Instance.ExchangescriptableObjectSOBetweenSlots(dragAndDrop, this);
    }

}
