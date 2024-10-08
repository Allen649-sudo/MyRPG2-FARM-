using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InteractWithPlayer : MonoBehaviour
{
    public static Action OnInteractWithPlayer;

    public void Interact()
    {
        OnInteractWithPlayer?.Invoke();
    }
}
