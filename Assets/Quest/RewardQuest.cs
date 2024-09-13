using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quest/Reward Quest")]
public class RewardQuest : ScriptableObject
{
    public ScriptableObjectSO scriptableObjectSOReward;
    public int amountRewardScriptableObjectSO;

    public int amountMoney;
    public int amountExperience;

    public AudioClip rewardQuestSound;
}
