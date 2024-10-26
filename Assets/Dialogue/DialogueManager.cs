using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    private Story currentStory;
    private string storyText; // ���������� ������ �������

    public bool dialogueIsPlaying;
    private bool continueSentence = false;

    public GameObject questManager;
    private GameObject currentInterlocutor;

    private void Start()
    {
        Instance = this;
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON, GameObject interlocutor)
    {
        currentInterlocutor = interlocutor;
        storyText = inkJSON.text; // ��������� ����� �������
        currentStory = new Story(storyText);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        ContinueStory();
    }

    public void ExitFromDialogue()
    {
        StartCoroutine(ExitDialogueMode());
    }

    private IEnumerator ExitDialogueMode()
    {
        yield return new WaitForSeconds(0.04f);

        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue && dialogueIsPlaying)
        {
            string nextLine = currentStory.Continue();

            if (string.IsNullOrEmpty(nextLine.Trim()) || nextLine.StartsWith("+ ["))
            {
                ContinueStory();
                return;
            }

            dialogueText.text = nextLine;

            // �������� ���������� �������� ������
            HideChoices();

            // �������� ��������� ������� �������
            List<Ink.Runtime.Choice> currentChoices = currentStory.currentChoices;

            if (currentChoices.Count == 0)
            {
                // ���� ��� �������, ��������� ���������� ��� ������� Enter
                continueSentence = true;
            }
            else
            {
                continueSentence = false;
                DisplayChoices();
            }
        }
        else
        {
            StartCoroutine(ExitDialogueMode());
        }
    }

    private void HideChoices()
    {
        // �������� ��� �������� ������
        foreach (var choice in choices)
        {
            choice.SetActive(false);
        }
    }


    private void DisplayChoices()
    {
        List<Ink.Runtime.Choice> currentChoices = currentStory.currentChoices;

        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("Error" + currentChoices.Count);
        }

        int index = 0;

        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }

        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }
        StartCoroutine(SelectFirstChoise());
    }

    private IEnumerator SelectFirstChoise()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }

    public void MakeChoice(int choiceIndex)
    {
        Choice chosenChoice = currentStory.currentChoices[choiceIndex];

        if (chosenChoice.text == "� ���� ���� ��� �������")
        {
            RestartDialogue();
            Debug.Log("Restart");
        }
        else if (chosenChoice.text == "������, � ������� ���� �������")
        {
            questManager.GetComponent<QuestManager>().ActiveQuest(currentInterlocutor);
            currentStory.ChooseChoiceIndex(choiceIndex);
            ContinueStory();
        }
        else
        {
            currentStory.ChooseChoiceIndex(choiceIndex);
            ContinueStory();
        }
    }

    private void RestartDialogue()
    {
        currentStory = new Story(storyText);
        ContinueStory();
    }

    // ����������� ����� ��� ��������� ������� Enter
    private void Update()
    {
        if (dialogueIsPlaying && Input.GetKeyDown(KeyCode.Return))
        {
            if (continueSentence)
            {
                // ���� ���������� �����������, ������ ���������� �������
                ContinueStory();
            }
            else
            {
                // ��������� ������, ���� ����� ��������
                if (currentStory.currentChoices.Count > 0)
                {
                    // ����� ��������� ��������
                    MakeChoice(0);
                }
            }
        }
    }
}