using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool Instance { get; private set; }

    public List<GameObject> listBullet = new List<GameObject>();
    private float lifeTime;
    void Start()
    {
        Instance = this;
    }

    public void BulletAddList(GameObject bullet)
    {
        listBullet.Add(bullet);
    }

    public void ActivateBullet(GameObject bulletSO, Transform transform, Quaternion rotation = default)
    {
        bool foundInactive = false;
        foreach (GameObject bulletåVar in listBullet)
        {
            if (bulletåVar != null && !bulletåVar.activeInHierarchy)
            {
                foundInactive = true;
                bulletåVar.GetComponent<BulletMovement>().Active();
                Shot(bulletåVar, transform, rotation);
                StartCoroutine(DeactiveBullet(bulletåVar));
                break;
            }
        }

        if (!foundInactive)
        {
            GameObject bullet = Instantiate(bulletSO, transform.position, rotation);
            BulletAddList(bullet);
            Shot(bullet, transform, rotation);
            StartCoroutine(DeactiveBullet(bullet));
        }
    }

    void Shot(GameObject bullet, Transform transform, Quaternion rotation)
    {
        bullet.transform.position = transform.position;
        bullet.transform.rotation = rotation;
        bullet.GetComponent<BulletMovement>().Shot();
        bullet.GetComponent<BulletMovement>().IgnorePlayer();
    }

    IEnumerator DeactiveBullet(GameObject bullet)
    {
        if (bullet.GetComponent<ItemObject>().scriptableObjectSO is BulletSO bulletSO)
        {
            lifeTime = bulletSO.lifetime;
        }
        yield return new WaitForSeconds(lifeTime);
        bullet.GetComponent<BulletMovement>().EnableTrigger();
        bullet.GetComponent<BulletMovement>().Deactive();
    }
}
