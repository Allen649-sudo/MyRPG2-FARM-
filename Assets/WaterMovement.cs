using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMovement : MonoBehaviour
{
    public float speed = 1f; 
    private float spriteWidth; 
    private Vector3 startPos; 

    void Start()
    {
        spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        startPos = transform.position; 
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position += Vector3.right * Time.deltaTime;

        if (transform.position.x > startPos.x + spriteWidth)
        {
            transform.position = startPos; 
        }
    }
}
