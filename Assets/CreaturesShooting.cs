using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreaturesShooting : MonoBehaviour
{
    public GameObject creaturesBulletPool;
    private CreaturesPool creaturesPool;
    public MagicBlowEnemySO magicBlow;
    private GameObject playerObj;
    private bool permissionsShoot = false;

    private float shootCooldown;
    private float lastShootTime = 0f;

    void Start()
    {
        shootCooldown = 1f;
        creaturesPool = creaturesBulletPool.GetComponent<CreaturesPool>();
    }

    public void SavingPlayerPos(GameObject playerObject)
    {
        playerObj = playerObject;
        permissionsShoot = true;
    }

    void Update()
    {
        if (permissionsShoot)
        {
            Shot();
        }
    }

    public void Shot()
    {
        if (Time.time - lastShootTime >= shootCooldown)
        {
            if (magicBlow != null)
            {
                Quaternion currentRotation = transform.rotation;
                creaturesPool.ActivateCreaturesBullet(magicBlow.prefab, gameObject, playerObj, currentRotation);

                shootCooldown = Random.Range(magicBlow.minTimeShootCooldown, magicBlow.maxTimeShootCooldown);
                lastShootTime = Time.time;
            }
            else
            {
                Debug.LogWarning("Magic Blow is null.");
            }
        }
    }
}
