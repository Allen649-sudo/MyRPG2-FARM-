using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class PackageObjectSO : ScriptableObjectSO
{
    [Header("PACKAGE SEED")]
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

    public int seedDispenseCount = 4;
}
