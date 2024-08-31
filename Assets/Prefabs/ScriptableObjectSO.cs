using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableObjectSO : ScriptableObject
{
    [Header("BASIC SETTINGS")]

    public string name;
    public GameObject prefab;
    public Sprite sprite;
    public int amount;
    public int maxStackable;

    public int price;

}
