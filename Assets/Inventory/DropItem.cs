using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class DropItem : MonoBehaviour, IDropHandler
{
    public bool test = false;
    public void OnDrop(PointerEventData eventData)
    {
        bool test = true;

        var otherItemTransform = eventData.pointerDrag.transform;
        otherItemTransform.SetParent(transform);
        otherItemTransform.localPosition = Vector3.zero;

    }
}
