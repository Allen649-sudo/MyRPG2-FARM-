using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveWall : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D collider)
    {
        Debug.Log("True");
        gameObject.SetActive(true);
    }

    void OnCollisionExit2D(Collision2D collider)
    {
        Debug.Log("False");
        gameObject.SetActive(false);
    }
}
