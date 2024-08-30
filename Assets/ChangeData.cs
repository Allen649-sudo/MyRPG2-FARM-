using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ChangeData : MonoBehaviour
{
    DataPlayer dataPlayer;
    public static Action<int> OnChangeMoneyVisual;

    void Start()
    {
        dataPlayer = GetComponent<DataPlayer>();
    }

    void OnEnable()
    {
        GiveReward.OnChangeMoney += ChangeMoney;
    }

    void OnDisable()
    {
        GiveReward.OnChangeMoney -= ChangeMoney;
    }

    void ChangeMoney(int money, int experience)
    {

        if (money > 0)
        {
            dataPlayer.amountMoney += money;
        }

        if (experience > 0)
        {
            dataPlayer.experience += experience;
        }

        OnChangeMoneyVisual?.Invoke(dataPlayer.amountMoney);
    }

    public int CheckMoney()
    {
        return dataPlayer.amountMoney;
    }

    public void SpendMoney(int productPrice)
    {
        dataPlayer.amountMoney -= productPrice;
        OnChangeMoneyVisual?.Invoke(dataPlayer.amountMoney);

    }
}
