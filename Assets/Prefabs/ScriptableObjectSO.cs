using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableObjectSO : ScriptableObject
{
    public string name;
    public GameObject prefab;
    public Sprite sprite;
    public int amount;
    public int maxStackable;

    [Header("Package seed")]
    public ItemObjectSO finishedItem;

    public int timeFirstStage;
    public Sprite spriteFirstStage;

    public int timeSecondtStage;
    public Sprite spriteSecondtStage;

    public int timeThirdStage;
    public Sprite spriteThirdStage;

    public int timeFourthStage;
    public Sprite spriteFourthStage;

    public int minFinishedItem;
    public int maxFinishedItem;
}
