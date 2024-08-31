using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePlayer : MonoBehaviour
{
    public float offset;

    private float timeBtwShots;
    private float startTimeBtwShots = 0.8f;
    public GameObject bullet;

    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
    }

    public void Shot(GameObject bulletPrefab)
    {
        bullet = bulletPrefab;

        Quaternion currentRotation = transform.rotation;
        BulletPool.Instance.ActivateBullet(bullet, transform, currentRotation);
    }
}
