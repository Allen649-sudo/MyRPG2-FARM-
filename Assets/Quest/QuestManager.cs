using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestManager : MonoBehaviour
{
    public DataPlayer dataPlayer;
    public GameObject player;
    public GameObject questWindow;
    public List<GameObject> questWindowTest = new List<GameObject>();

    private AnimationWindowQuest animationWindowQuest;

    public List<GameObject> selectedWindowsQuest = new List<GameObject>();
    private GameObject selected;


    void OnEnable()
    {
        Data_QuestWindow.OnDropQuestAction += ReturnWindowQuestIn_QuestWindowTest;
        Data_QuestWindow.OnAcceptQuestAction += UpdateSelectedQuestWindows;
    }

    void OnDisable()
    {
        Data_QuestWindow.OnDropQuestAction -= ReturnWindowQuestIn_QuestWindowTest;
        Data_QuestWindow.OnAcceptQuestAction -= UpdateSelectedQuestWindows;

    }

    void Start()
    {
        player = GameObject.Find("Player");
        dataPlayer = player.GetComponent<DataPlayer>();
        animationWindowQuest = questWindow.GetComponent<AnimationWindowQuest>();

        foreach (GameObject questWindowVar in questWindowTest)
        {
            questWindowVar.GetComponent<Data_QuestWindow>().InactiveQuest();
        }
    }

    public void ActiveQuest(GameObject questCarrier)
    {
        bool isFirstInstanceCreated = false;
        if (questCarrier.GetComponent<Quest>() != null)
        {
            if (questCarrier.GetComponent<Quest>().parametersQuest.activeQuest == true && questCarrier.GetComponent<Quest>().parametersQuest.playerAcceptQuest == false)
            {
                foreach (GameObject questWindowVar in questWindowTest)
                {
                    if (!isFirstInstanceCreated)
                    {
                        questWindowVar.GetComponent<Data_QuestWindow>().ActiveQuest();
                        TextMeshProUGUI nameQuest = questWindowVar.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
                        TextMeshProUGUI description = questWindowVar.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
                        Image conditions = questWindowVar.transform.GetChild(2).GetComponent<Image>();
                        Image reward = questWindowVar.transform.GetChild(3).GetComponent<Image>();

                        Quest quest = questCarrier.GetComponent<Quest>();
                        nameQuest.text = quest.parametersQuest.name;
                        description.text = quest.parametersQuest.description;
                        conditions.sprite = quest.parametersQuest.conditions;
                        reward.sprite = quest.parametersQuest.reward;
                        selected = questWindowVar;
                        AddedQuestWindow(questWindowVar, questCarrier);


                        isFirstInstanceCreated = true;
                        break;
                    }
                }
            }
        }
    }

    void AddedQuestWindow(GameObject questWindowVar, GameObject questCarrier)
    {
        questWindowVar.GetComponent<Data_QuestWindow>().temporarySelectedParametersQuest = questCarrier.GetComponent<Quest>().parametersQuest;
        questCarrier.GetComponent<Quest>().temporaryWindowQuest = questWindowVar;

        UpdateSelectedQuestWindows(questWindowVar);
    }

    void UpdateSelectedQuestWindows(GameObject questWindowVar)
    {

        if (selectedWindowsQuest.Count > 0)
        {
            List<GameObject> tempQuestWindows = new List<GameObject>();

            foreach (GameObject selectedquestWindowVar in selectedWindowsQuest)
            {
                if (!selectedWindowsQuest.Exists(selectedQuestWindow => selectedQuestWindow == questWindowVar))
                {
                    tempQuestWindows.Add(questWindowVar);
                }
            }

            selectedWindowsQuest.AddRange(tempQuestWindows);
        }
        else
        {
            selectedWindowsQuest.Add(questWindowVar);
        }
    }

    public void AcceptQuest()
    {
        questWindowTest.Remove(selected);
        
    }

    public void InactiveQuest(GameObject temporaryWindowQuest)
    {
        foreach (GameObject selectedWindowsQuestVar in questWindowTest)
        {
            if (selectedWindowsQuestVar != null)
            {
                Data_QuestWindow questWindowData = selectedWindowsQuestVar.GetComponent<Data_QuestWindow>();
                if (questWindowData != null) 
                {
                    if (questWindowData.temporarySelectedParametersQuest != null) 
                    {
                        questWindowData.InactiveQuest();
                        selectedWindowsQuest.Remove(selectedWindowsQuestVar);
                    }
                }
            }
        }
    }

    public void ReturnWindowQuestIn_QuestWindowTest(ParametersQuest sentParametersQuest, GameObject questWindow)
    {
         StartCoroutine(ReturnWindowQuest(sentParametersQuest, questWindow));
    }

    IEnumerator ReturnWindowQuest(ParametersQuest sentParametersQuest, GameObject questWindow)
    {
        if (selectedWindowsQuest.Count > 0)
        {
            for (int i = selectedWindowsQuest.Count - 1; i >= 0; i--)
            {
                GameObject selectedWindowsQuestVar = selectedWindowsQuest[i];
                if (sentParametersQuest == selectedWindowsQuestVar.GetComponent<Data_QuestWindow>().selectedParametersQuest)
                {
                    yield return new WaitForSeconds(0.1f);
                    questWindowTest.Insert(0, selectedWindowsQuestVar);
                    selectedWindowsQuest.RemoveAt(i); // Удаляем по индексу
                }
            }
        }
    }

}
