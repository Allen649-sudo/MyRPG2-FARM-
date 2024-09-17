using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxWater : MonoBehaviour
{
    private Transform cameraTransform; 
    private Transform[] layers; 
    private int leftIndex; 
    private int rightIndex;
    private float speed = 0.4f;

    public GameObject pointCenter;

    private void Start()
    {
        cameraTransform = Camera.main.transform; 
        layers = new Transform[transform.childCount]; 
    }

    private void Update()
    {
         ScrollRight();
    }

    private void ScrollRight()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            layers[i] = transform.GetChild(i);
            layers[i].position += Vector3.right * Time.deltaTime * speed;

            if (layers[i].position.x > pointCenter.transform.position.x + 25f)
            {
                layers[i].transform.position -= new Vector3(layers[i].transform.position.x - ((pointCenter.transform.position.x - 25f) * 1.5f), 0, 0);
            }
        }
    }
}
