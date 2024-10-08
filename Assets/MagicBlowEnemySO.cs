using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CreaturesSO/Magic Blow")]
public class MagicBlowEnemySO : ScriptableObjectSO
{
    [Header("MAGIC BLOW ENEMY PROPERTIES")]
    public int speed;
    public float lifetime;
    public float minTimeShootCooldown;
    public float maxTimeShootCooldown;
}

