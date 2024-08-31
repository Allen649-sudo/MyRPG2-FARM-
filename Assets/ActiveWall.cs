using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveWall : MonoBehaviour
{

   /* void Start()
    {
        gameObject.SetActive(false);

    }*/
    public void TryActiveWall()
    {
        Debug.Log("sfsf");
        gameObject.SetActive(true);
    }

    public void FalseActiveWall()
    {
        gameObject.SetActive(false);
    }
}
