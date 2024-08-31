using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private Transform parent;
    [SerializeField] private Canvas canvas;
    Transform child;

    void OnEnable()
    {
        Collision_With_Item.OnOpenShop += OnChestClose;
    }

    void OnDisable()
    {
        Collision_With_Item.OnOpenShop -= OnChestClose;
    }

    void Start()
    {
        parent = transform;
        child = transform.GetChild(0);
        child.gameObject.SetActive(false);
    }

    void OnMouseDown()
    {
        
        child.gameObject.SetActive(true);
        child.SetParent(canvas.transform); 
        
    }

    public void DeactivateChild()
    {
       
         child.SetParent(parent); 
         child.gameObject.SetActive(false);
    }

    void OnChestClose()
    {
        child.gameObject.SetActive(false);

    }
}
