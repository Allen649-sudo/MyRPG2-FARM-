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
        InteractWithPlayer.OnInteractWithPlayer += OnShowShop;
        Collision_With_Item.OnClose += OnCloseShop;
    }

    void OnDisable()
    {
        InteractWithPlayer.OnInteractWithPlayer -= OnShowShop;
        Collision_With_Item.OnClose -= OnCloseShop;

    }

    void Start()
    {
        parent = transform;
        child = transform.GetChild(0);
        child.gameObject.SetActive(false);
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        int layer = collider.gameObject.layer;

        if (layer == LayerMask.NameToLayer("Player"))
        {
            contactWitnPlayer = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        int layer = collider.gameObject.layer;

        if (layer == LayerMask.NameToLayer("Player"))
        {
            contactWitnPlayer = false;
            OnCloseShop();
        }
    }

    void OnCloseShop()
    {
        child.gameObject.SetActive(false);
    }

    void OnShowShop()
    {
        if (contactWitnPlayer == true)
        {
            child.gameObject.SetActive(true);
            child.SetParent(canvas.transform);
        }
    }
}
