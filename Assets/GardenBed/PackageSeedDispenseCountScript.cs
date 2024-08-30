using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageSeedDispenseCountScript : MonoBehaviour
{
    public int seedDispenseCountItem;
    ItemObject itemObject;
    PackageObjectSO packageObjectSO;

    void Start()
    {
        itemObject = GetComponent<ItemObject>();
        if (itemObject.scriptableObjectSO is PackageObjectSO temporaryScriptableObjectPlayerHand)
        {
            packageObjectSO = temporaryScriptableObjectPlayerHand;
        }
        if (packageObjectSO.seedDispenseCount != 0)
        {
            seedDispenseCountItem = packageObjectSO.seedDispenseCount;

        }
        packageObjectSO.prefab = this.gameObject;

    }

    public void DispenseSeeds()
    {
        seedDispenseCountItem--;
        Debug.Log(seedDispenseCountItem);

        if (seedDispenseCountItem <= 0)
        {
            QuickslotInventory.Instance.OnNullifySlot();

        }
    }
}
