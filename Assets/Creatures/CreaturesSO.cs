using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CreaturesSO/CreaturesSO")]
public class CreaturesSO : ScriptableObject
{
    public string name;
    public int health;
    public int minAttack;
    public int maxAttack;

    public AudioClip hitSound;
    public bool shooter;
}
