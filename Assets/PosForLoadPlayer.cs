using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosForLoadPlayer : MonoBehaviour
{
    bool contactWitnPlayer = false;
    public Loader.Scene scene;

    void OnEnable()
    {
        InteractWithPlayer.OnInteractWithPlayer += LoadInMainScene;
    }

    void OnDisable()
    {
        InteractWithPlayer.OnInteractWithPlayer -= LoadInMainScene;
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
        }
    }

    void LoadInMainScene()
    {
        if (contactWitnPlayer == true)
        {
            Loader.Load(scene);
        }
    }
}
