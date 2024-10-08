using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    private int speedBullet = 10;
    bool movement = false;
    private Collider2D collider2D;
    public BulletSO bulletSO;
    LayerMask playerLayer = 6;
    int bulletDamage = 90;

    public GameObject playerPos;

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

    void OnTriggerEnter2D(Collider2D collider)
    {
        int layer = collider.gameObject.layer;

        if (layer == LayerMask.NameToLayer("Enemy"))
        {
            Vector3 posSpawnBlood = transform.position;
            collider.gameObject.GetComponent<GettingWoundAndDeath>().GetInjury(posSpawnBlood, bulletDamage, playerPos);
            ReturnInPool();
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
         Physics2D.IgnoreLayerCollision(gameObject.layer, playerLayer, true);
    }

    public void EnableTrigger()
    {
         Physics2D.IgnoreLayerCollision(gameObject.layer, playerLayer, false);
    }

    private void ReturnInPool()
    {
        StopCoroutine(DeactiveBulletCoroutine());
        EnableTrigger();
        Deactive();
    }

    public void DeactiveBullet()
    {
        StartCoroutine(DeactiveBulletCoroutine());
    }

    IEnumerator DeactiveBulletCoroutine()
    {
        yield return new WaitForSeconds(bulletSO.lifetime);

        EnableTrigger();
        Deactive();
    }

    public void ReceivingAmountDamage(int gunDamage)
    {
        bulletDamage = gunDamage;
    }
}
