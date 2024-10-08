using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Gun/Bullet Parameters")]
public class BulletSO : ScriptableObjectSO
{
    [Header("BULLET PROPERTIES")]
    public int speed;
    public float lifetime;
    [Header("FOR ENEMY")]
    public int damage;

}

