using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootCooldown : MonoBehaviour
{
    ItemObject itemObject;
    private float rechargeTime;
    private bool permissionShoot = false;
    private float scriptableObjectShootCooldown;

    void Start()
    {
        itemObject = GetComponent<ItemObject>();
        if (itemObject.scriptableObjectSO is GunSO scriptableObjectSOShootCooldown)
        {
            scriptableObjectShootCooldown = scriptableObjectSOShootCooldown.shotCooldown;
        }
        rechargeTime = scriptableObjectShootCooldown;
    }

    void Update()
    {
        rechargeTime -= Time.deltaTime;

        if (rechargeTime < 0)
        {
            permissionShoot = true;
        }
    }

    public bool Recharge()
    {
        if (permissionShoot)
        {

            rechargeTime = scriptableObjectShootCooldown;
            permissionShoot = false;
            return true;
        }
        else
        {
            return false;
        }
    }
}
