using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShowProduct : MonoBehaviour
{
    ScriptableObjectSO product;

    Image childIcon;
    TextMeshProUGUI childPriceText;
    public GameObject player;


    public void SettingProduct(ScriptableObjectSO scriptableObjectSO)
    {
        product = scriptableObjectSO;

        childIcon = gameObject.transform.GetChild(0).GetChild(0).GetComponent<Image>();
        childPriceText = gameObject.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();

        childIcon.sprite = scriptableObjectSO.sprite;
        childPriceText.text = scriptableObjectSO.price.ToString();
    }

    public void BuyProduct()
    {
        if (player.GetComponent<ChangeData>().CheckMoney() >= product.price)
        {
            ObjectPool.Instance.ActivateItem(1, product, player.transform);
            player.GetComponent<ChangeData>().SpendMoney(product.price);
        }
    }
}
