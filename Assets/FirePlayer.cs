using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePlayer : MonoBehaviour
{
    public float offset;

    private float timeBtwShots;
    private float startTimeBtwShots = 0.8f;
    private GameObject bullet;

    private float rechargeTime = -1f;
    private bool permissionShoot = false;
    private float scriptableObjectShootCooldown;

    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ);

        rechargeTime -= Time.deltaTime;
        if (rechargeTime < 0)
        {
            permissionShoot = true;
        }
    }

    public void Shot(GameObject bulletPrefab, GameObject gunPrefab)
    {
        if (gunPrefab.GetComponent< ItemObject>().scriptableObjectSO is GunSO gunPrefabScriptableObjectSO)
        {
            if(rechargeTime < 0)
            {
                scriptableObjectShootCooldown = gunPrefabScriptableObjectSO.shotCooldown;
                rechargeTime = scriptableObjectShootCooldown;

                if (permissionShoot)
                {
                    bullet = bulletPrefab;

                    Quaternion currentRotation = transform.rotation;
                    BulletPool.Instance.ActivateBullet(bullet, transform, currentRotation);
                    SoundManager.Instance.PlaySound(gunPrefabScriptableObjectSO.shotSound);

                    rechargeTime = scriptableObjectShootCooldown;
                    permissionShoot = false;
                }
            }
        }
    }
}
