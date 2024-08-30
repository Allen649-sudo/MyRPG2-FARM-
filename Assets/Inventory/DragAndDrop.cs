using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    [SerializeField] private Canvas canvas;
    private CanvasGroup canvasGroup;

    private DropItemBetweenSlots dropItemBetweenSlots;

    [HideInInspector] public InventorySlot inventorySlot;
    [SerializeField] private GameObject UIPanel;

    Transform parentTransform;
    Transform grandma;

    public static Action<DragAndDrop> OnDropItem;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    void Start()
    {
        parentTransform = transform.parent;
        grandma = parentTransform.transform.parent;
        inventorySlot = parentTransform.GetComponent<InventorySlot>();
        dropItemBetweenSlots = GetComponent<DropItemBetweenSlots>();

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetParent(grandma.parent.parent, true);
        rectTransform.SetAsLastSibling();
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = .6f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.localPosition = Vector3.zero;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
        transform.SetParent(parentTransform, true);

        OnDropItem?.Invoke(this);
        if(dropItemBetweenSlots != null)
        {

        dropItemBetweenSlots.SendDragAndDropAndDropItemBetweenSlots(this);  
        }
    }
}
