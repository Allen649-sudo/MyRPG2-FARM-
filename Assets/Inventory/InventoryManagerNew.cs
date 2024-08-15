using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class InventoryManagerNew : MonoBehaviour
{
    public Transform mainSlots; //рср
    private bool isOpened;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isOpened = !isOpened;
            if (isOpened)
            {
                mainSlots.gameObject.SetActive(true); 
            }
            else
            {
                mainSlots.gameObject.SetActive(false);
            }
        }

    }
}
