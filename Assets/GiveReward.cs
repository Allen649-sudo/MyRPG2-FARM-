using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveReward : MonoBehaviour
{
    void OnEnable()
    {
        Quest.OnGiveReward += GiveRewardPlayer;
    }

    void OnDisable()
    {
        Quest.OnGiveReward -= GiveRewardPlayer;
    }

    public void GiveRewardPlayer(int amountRewardScriptableObjectSO, ScriptableObjectSO prefabReward, Transform spawnPos)
    {
        /*prefabReward.prefab.GetComponent<ItemObject>().AnimationReward();*/
        ObjectPool.Instance.ActivateItem(amountRewardScriptableObjectSO, prefabReward, spawnPos);
    }

}
