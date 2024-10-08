using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool Instance { get; private set; }

    public List<GameObject> listBullet = new List<GameObject>();
    private float lifeTime;
    public bool bulletHit = false;

    void Start()
    {
        Instance = this;
    }

    public void BulletAddList(GameObject bullet)
    {
        listBullet.Add(bullet);
    }

    public void ActivateBullet(GameObject bulletSO, int bulletDamage, Transform transform, Quaternion rotation = default)
    {
        bool foundInactive = false;
        foreach (GameObject bullet�Var in listBullet)
        {
            if (bullet�Var != null && !bullet�Var.activeInHierarchy)
            {
                foundInactive = true;
                bullet�Var.GetComponent<BulletMovement>().Active();
                bullet�Var.GetComponent<BulletMovement>().ReceivingAmountDamage(bulletDamage);
                Shot(bullet�Var, transform, rotation);
                break;
            }
        }

        if (!foundInactive)
        {
            GameObject bullet = Instantiate(bulletSO, transform.position, rotation);
            bullet.GetComponent<BulletMovement>().ReceivingAmountDamage(bulletDamage);
            BulletAddList(bullet);
            Shot(bullet, transform, rotation);
        }
    }

    void Shot(GameObject bullet, Transform transform, Quaternion rotation)
    {
        bullet.GetComponent<BulletMovement>().IgnorePlayer();
        bullet.transform.position = transform.position;
        bullet.transform.rotation = rotation;
        bullet.GetComponent<BulletMovement>().Shot();
        bullet.GetComponent<BulletMovement>().DeactiveBullet();
    }
}
