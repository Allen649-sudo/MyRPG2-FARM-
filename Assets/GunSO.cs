using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Gun/Gun Parameters")]
public class GunSO : ScriptableObjectSO
{
    [Header("GUN PROPERTIES")]
    public BulletSO suitableBullet;
    public float shotCooldown;

    public AudioClip shotSound;
}
