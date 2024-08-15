using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [HideInInspector] public ScriptableObjectSO scriptableObjectSO;
    public int count = 0;

    [HideInInspector] public Transform iconGO;
    [HideInInspector] public TextMeshProUGUI itemAmountText;
    [HideInInspector] public DragAndDrop dragItem;


    void Start()
    {
        itemAmountText = gameObject.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>(); 
        iconGO = gameObject.transform.GetChild(0).GetChild(0); 
        dragItem = transform.GetChild(0).GetComponent<DragAndDrop>(); 

        itemAmountText.text = "";
    }

    public bool TryInventorySlotHaveitemObject()
    {
        return scriptableObjectSO == null;
    }

    public DragAndDrop GetDragAndDrop()
    {
        return dragItem;
    }

    public void CountInText()
    {
        itemAmountText.text = count.ToString();
    }
}
