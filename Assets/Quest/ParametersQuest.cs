using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu()]
public class ParametersQuest : ScriptableObject
{
    public string name;
    public int questLevel;
    public string description;

    public GameObject carrier;

    public bool activeQuest;
    public bool playerAcceptQuest = false;

    [Space(1)]
    [Header("CONDITIONS")]
    public ScriptableObjectSO scriptableObjectSO;
    public int amountScriptableObjectSO;
    public Sprite conditions;
    [Space(1)]
    [Header("REWARD")]
    public ScriptableObjectSO scriptableObjectSOReward;
    public int amountRewardScriptableObjectSO;
    public Sprite reward;

}
