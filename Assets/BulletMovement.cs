using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    private int speedBullet = 10;
    bool movement = false;
    private Collider2D collider2D;

    void Start()
    {
        collider2D = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (movement == true)
        {
            transform.Translate(speedBullet * Time.deltaTime, 0f, 0f);
        }
    }

    public void Shot()
    {
        movement = true;
    }

    public void Deactive()
    {
        gameObject.SetActive(false);
    }

    public void Active()
    {
        gameObject.SetActive(true);
    }

    public void IgnorePlayer()
    {
        Physics2D.IgnoreLayerCollision(gameObject.layer, 0, true);
    }

    public void EnableTrigger()
    {
        Physics2D.IgnoreLayerCollision(gameObject.layer, 0, false);

    }
}
