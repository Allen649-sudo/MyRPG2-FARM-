using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Quest : MonoBehaviour
{
    public ParametersQuest parametersQuest;
    private int itemStorage;

    [SerializeField] private QuickslotInventory quickslotInventory;
    private QuickslotInventory quickslotInventoryScript;

    public static Action<Quest> OnAudioClipSource;
    public static Action<RewardQuest, Transform> OnGiveReward;

    [SerializeField] private AnimationWindowQuest animationWindowQuest;
    private AnimationWindowQuest animationWindowQuestScript;

    public GameObject temporaryWindowQuest;

    void Start()
    {
        parametersQuest.activeQuest = true;
        parametersQuest.playerAcceptQuest = false;

        quickslotInventoryScript = quickslotInventory.GetComponent<QuickslotInventory>();
        animationWindowQuestScript = animationWindowQuest.GetComponent<AnimationWindowQuest>();
    }

    public void OnQuestInteract_CheckCompleteQuest()
    {
        if (parametersQuest.activeQuest == true && parametersQuest.playerAcceptQuest == true)
        {
            if (quickslotInventoryScript.GetActiveSlot().scriptableObjectSO != null)
            {
                if (quickslotInventoryScript.GetActiveSlot().scriptableObjectSO.name == parametersQuest.scriptableObjectSO.name && quickslotInventoryScript.GetActiveSlot().count < parametersQuest.amountScriptableObjectSO)
                {
                    itemStorage += quickslotInventoryScript.GetActiveSlot().count;
                    QuickslotInventory.Instance.OnNullifySlot();


                }
                else if (quickslotInventoryScript.GetActiveSlot().scriptableObjectSO.name == parametersQuest.scriptableObjectSO.name && quickslotInventoryScript.GetActiveSlot().count == 0)
                {
                    return;
                }

                if ((quickslotInventoryScript.GetActiveSlot().scriptableObjectSO == parametersQuest.scriptableObjectSO && quickslotInventoryScript.GetActiveSlot().count >= parametersQuest.amountScriptableObjectSO) || itemStorage == parametersQuest.amountScriptableObjectSO)
                {
                    TriggerEventCompleteQuest();
                    ResetStates();
                    temporaryWindowQuest.GetComponent<Data_QuestWindow>().QuestComplete();
                    if (quickslotInventoryScript.GetActiveSlot().count - parametersQuest.amountScriptableObjectSO > 0 && itemStorage == 0)
                    {
                        int newCount = quickslotInventoryScript.GetActiveSlot().count - parametersQuest.amountScriptableObjectSO;
                        quickslotInventoryScript.GetActiveSlot().count = newCount;
                        quickslotInventoryScript.GetActiveSlot().CountInText();
                    }
                    else if(quickslotInventoryScript.GetActiveSlot().count - itemStorage > 0 && itemStorage != 0)
                    {
                        int newCount = quickslotInventoryScript.GetActiveSlot().count - itemStorage;
                        quickslotInventoryScript.GetActiveSlot().count = newCount;
                        quickslotInventoryScript.GetActiveSlot().CountInText();
                    }
                    else
                    {
                        QuickslotInventory.Instance.OnNullifySlot();
                    }
                    itemStorage = 0;
                }
            }
        }
        
    }

    void TriggerEventCompleteQuest()
    {
        SoundManager.Instance.PlaySound(parametersQuest.rewardQuest.rewardQuestSound);
        OnGiveReward?.Invoke(parametersQuest.rewardQuest, this.gameObject.transform);
    }

    void ResetStates()
    {
        parametersQuest.activeQuest = false;
    }

    void AcceptQuest()
    {
        parametersQuest.playerAcceptQuest = true;
    }

    void DropQuest()
    {
        parametersQuest.playerAcceptQuest = false;
    }

    public void SetTemporaryWindowQuest(GameObject temporaryWindowQuest)
    {
        this.temporaryWindowQuest = temporaryWindowQuest;
    }
}
