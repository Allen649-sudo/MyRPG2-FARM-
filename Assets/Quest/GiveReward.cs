using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GiveReward : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private DataPlayer dataPlayer;
    public static Action<int, int> OnChangeMoney;

    void Start()
    {
        dataPlayer = player.GetComponent<DataPlayer>();
    }

    void OnEnable()
    {
        Quest.OnGiveReward += GiveRewardPlayer;
    }

    void OnDisable()
    {
        Quest.OnGiveReward -= GiveRewardPlayer;
    }

    public void GiveRewardPlayer(RewardQuest rewardQuest, Transform spawnPos)
    {
        ObjectPool.Instance.ActivateItem(rewardQuest.amountRewardScriptableObjectSO, rewardQuest.scriptableObjectSOReward, spawnPos);
        OnChangeMoney?.Invoke(rewardQuest.amountMoney, rewardQuest.amountExperience);
    }

}
