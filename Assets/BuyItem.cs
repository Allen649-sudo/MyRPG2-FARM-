using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyItem : MonoBehaviour
{
    public List<ScriptableObjectSO> listProduct = new List<ScriptableObjectSO>();
    private Transform[] childrenTransforms;

    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            // Получаем компонент ShowProduct из дочернего объекта
            ShowProduct showProduct = child.GetComponent<ShowProduct>();

            if (showProduct != null)
            {
                int randomIndex = Random.Range(0, listProduct.Count);
                showProduct.SettingProduct(listProduct[randomIndex]);
            }

        }
    }
}
