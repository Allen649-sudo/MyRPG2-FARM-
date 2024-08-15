using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Data_QuestWindow : MonoBehaviour
{
    public ParametersQuest selectedParametersQuest;
    public ParametersQuest temporarySelectedParametersQuest;
    [SerializeField] private Transform temporaryParent;

    public RectTransform rectTransform;
    private Vector3 originalPosition;
    public Canvas canvas;

    AnimationWindowQuest animationWindowQuest;

    public bool acceptQuest;

    public static Action<ParametersQuest, GameObject> OnDropQuestAction;
    public static Action<GameObject> OnAcceptQuestAction;


    void Start()
    {
        Transform parentTransform = transform.parent;
        temporarySelectedParametersQuest.activeQuest = true;
        temporarySelectedParametersQuest.playerAcceptQuest = false;
        originalPosition = transform.position;
        rectTransform = GetComponent<RectTransform>();

        animationWindowQuest = GetComponent<AnimationWindowQuest>();
    }


    public void OnAcceptQuest()
    {
        transform.SetParent(temporaryParent);
        selectedParametersQuest = temporarySelectedParametersQuest;
        OnAcceptQuestAction?.Invoke(gameObject);

    }

    public void OnDropQuest()
    {

        OnDropQuestAction?.Invoke(temporarySelectedParametersQuest, this.gameObject);
        transform.SetParent(canvas.transform);
        selectedParametersQuest = null;
        rectTransform.localPosition = originalPosition;

        rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
        rectTransform.anchorMax = new Vector2(0.5f, 0.5f);

    }

    public void FalsePlayerAcceptQuest()
    {
        temporarySelectedParametersQuest.playerAcceptQuest = false;
    }

    public void QuestComplete()
    {
        OnDropQuest();
        animationWindowQuest.QuestComplete();
    }

    public void InactiveQuest()
    {
        gameObject.SetActive(false);
    }

    public void ActiveQuest()
    {
        gameObject.SetActive(true);
    }
}
