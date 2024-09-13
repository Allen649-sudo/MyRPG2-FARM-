using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowShop : MonoBehaviour
{
    private Transform parent;
    [SerializeField] private Canvas canvas;
    Transform child;

    bool contactWitnPlayer = false;

    void OnEnable()
    {
        Collision_With_Item.OnPlayerInteract += OnShowShop;
        Collision_With_Item.OnOpenShop += OnShowClose;
    }

    void OnDisable()
    {
        Collision_With_Item.OnPlayerInteract -= OnShowShop;
        Collision_With_Item.OnOpenShop -= OnShowClose;
    }

    void Start()
    {
        parent = transform;
        child = transform.GetChild(0);
        child.gameObject.SetActive(false);
    }

    void OnTriggerStay2D(Collider2D itemCollider)
    {
        contactWitnPlayer = true;
    }

    void OnTriggerExit2D(Collider2D itemCollider)
    {
        contactWitnPlayer = false;
    }


    void OnShowShop()
    {
        if (contactWitnPlayer == true)
        {
            child.gameObject.SetActive(true);
            child.SetParent(canvas.transform);
        }
    }

    void OnShowClose()
    {
        child.gameObject.SetActive(false);
    }
}
