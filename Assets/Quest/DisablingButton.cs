using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DisablingButton : MonoBehaviour
{
    [SerializeField] private Button closeButton;
    [SerializeField] private Button acceptButton;

    [SerializeField] private DataPlayer dataPlayer;

    [SerializeField] private Data_QuestWindow data_QuestWindow;

    void Start()
    {
        closeButton.gameObject.SetActive(false);
        data_QuestWindow = GetComponent<Data_QuestWindow>();
    }

    public void DisablingAndEnablingButton()
    {
        acceptButton.gameObject.SetActive(false); 
        closeButton.gameObject.SetActive(true);
        data_QuestWindow.temporarySelectedParametersQuest.playerAcceptQuest = true;
    }

    public void DropQuest()
    {

        acceptButton.gameObject.SetActive(true);
        closeButton.gameObject.SetActive(false);

        data_QuestWindow.FalsePlayerAcceptQuest();
        data_QuestWindow.OnDropQuest();

    }

    public void SwitchingButton()
    {
        acceptButton.gameObject.SetActive(true);
        closeButton.gameObject.SetActive(false);
    }

}
