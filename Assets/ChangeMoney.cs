using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ChangeMoney : MonoBehaviour
{
    [HideInInspector] public TextMeshProUGUI moneyText;

    void Start()
    {
        moneyText = gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>();

    }

    void OnEnable()
    {
        ChangeData.OnChangeMoneyVisual += ChangeMoneyText;
    }

    void OnDisable()
    {
        ChangeData.OnChangeMoneyVisual -= ChangeMoneyText;
    }

    void ChangeMoneyText(int newMoney)
    {
        moneyText.text = newMoney.ToString();
    }
}
