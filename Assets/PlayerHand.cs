using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHand : MonoBehaviour
{
    public static PlayerHand Instance { get; private set; }

    [SerializeField] private QuickslotInventory quickslotInventory;
    private QuickslotInventory quickslotInventoryScript;
    InventorySlot activeSlot;
    public Sprite empty;
    public ScriptableObjectSO scriptableObjectSO { get; private set; }

    [SerializeField] private SpriteRenderer spriteRenderer;

    void Awake()
    {
        Instance = this;

        quickslotInventoryScript = quickslotInventory.GetComponent<QuickslotInventory>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (quickslotInventoryScript != null)
        {
            activeSlot = quickslotInventoryScript.GetActiveSlot();
        }
        if (activeSlot != null)
        {
            scriptableObjectSO = activeSlot.scriptableObjectSO;
        }
        if (spriteRenderer.sprite != null)
        {
            spriteRenderer.sprite = activeSlot.iconGO.GetComponent<Image>().sprite;
        }
    }
}
