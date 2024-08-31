using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuickslotInventory : MonoBehaviour
{
    [SerializeField] private Transform InventoryPanelTransform;
    private int currentQuickslotID = 0;
    [SerializeField] private Sprite selectedSprite;
    [SerializeField] private Sprite notSelectedSprite;
    private InventorySlot activeSlot = null;

    public static QuickslotInventory Instance;


    void Start()
    {
        Instance = this;
    }

    void Update()
    {
        float mw = Input.GetAxis("Mouse ScrollWheel");
        if (mw < 0.1)
        {
            InventoryPanelTransform.GetChild(currentQuickslotID).GetComponent<InventorySlot>().GetComponent<Image>().sprite = notSelectedSprite;

            if (currentQuickslotID >= InventoryPanelTransform.childCount - 1)
            {
                currentQuickslotID = 0;
            }
            else
            {
                currentQuickslotID++;
            }

            InventoryPanelTransform.GetChild(currentQuickslotID).GetComponent<InventorySlot>().GetComponent<Image>().sprite = selectedSprite;
            activeSlot = InventoryPanelTransform.GetChild(currentQuickslotID).GetComponent<InventorySlot>();

        }
        if (mw > -0.1)
        {

            InventoryPanelTransform.GetChild(currentQuickslotID).GetComponent<InventorySlot>().GetComponent<Image>().sprite = notSelectedSprite;

            if (currentQuickslotID <= 0)
            {
                currentQuickslotID = InventoryPanelTransform.childCount - 1;
            }
            else
            {
                currentQuickslotID--;
            }

            InventoryPanelTransform.GetChild(currentQuickslotID).GetComponent<InventorySlot>().GetComponent<Image>().sprite = selectedSprite;
            activeSlot = InventoryPanelTransform.GetChild(currentQuickslotID).GetComponent<InventorySlot>();
        }
        // Используем цифры
        for (int i = 0; i < InventoryPanelTransform.childCount; i++)
        {
            if (Input.GetKeyDown((i + 1).ToString()))
            {
                if (currentQuickslotID == i)
                {
                    return;
                }
                else
                {
                    InventoryPanelTransform.GetChild(currentQuickslotID).GetComponent<InventorySlot>().GetComponent<Image>().sprite = notSelectedSprite;

                    currentQuickslotID = i;

                    InventoryPanelTransform.GetChild(currentQuickslotID).GetComponent<InventorySlot>().GetComponent<Image>().sprite = selectedSprite;
                    activeSlot = InventoryPanelTransform.GetChild(currentQuickslotID).GetComponent<InventorySlot>();
                }
            }
        }
    }

    public InventorySlot GetActiveSlot()
    {
        return activeSlot;
    }

    public void OnNullifySlot()
    {
        InventoryPanel.Instance.ResetDragAndDrop(activeSlot.GetDragAndDrop());
    }
}
