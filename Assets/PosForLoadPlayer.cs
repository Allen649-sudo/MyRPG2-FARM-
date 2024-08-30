using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosForLoadPlayer : MonoBehaviour
{
    bool contactWitnPlayer = false;
    public Loader.Scene scene;

    void OnEnable()
    {
        Collision_With_Item.OnPlayerInteract += LoadInMainScene;
    }

    void OnDisable()
    {
        Collision_With_Item.OnPlayerInteract -= LoadInMainScene;
    }

    void OnTriggerStay2D(Collider2D itemCollider)
    {
        contactWitnPlayer = true;
    }

    void OnTriggerExit2D(Collider2D itemCollider)
    {
        contactWitnPlayer = false;
    }

    void LoadInMainScene()
    {
        if (contactWitnPlayer == true)
        {
            Loader.Load(scene);
        }

    }

}
