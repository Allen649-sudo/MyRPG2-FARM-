using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance { get; private set; }

    public List<ItemObject> listItemObject = new List<ItemObject>();

    void Start()
    {
        Instance = this;
    }

    public void ItemObjectAddList(ItemObject itemObject)
    {
        listItemObject.Add(itemObject);

    }

    public void ActivateItem(int count, ScriptableObjectSO scriptableObjectSO, Transform transform = null, Quaternion rotation = default)
    {
        for (int i = 0; i < count; i++)
        {
            ItemObject existingItem = null;

            foreach (ItemObject itemObject in listItemObject)
            {
                if (itemObject != null && scriptableObjectSO == itemObject.scriptableObjectSO)
                {

                    existingItem = itemObject;
                    break; 
                }
            }

            if (existingItem != null && !existingItem.gameObject.activeInHierarchy)
            {
                for (int j = 0; j < count; j++)
                {
                    if (transform != null)
                    {
                        existingItem.Activate(transform);
                    }
                    else
                    {
                        existingItem.Activate();
                    }
                    listItemObject.Remove(existingItem); 
                }
            }
            else
            {
                bool isFirstInstanceCreated = false;

                for (int j = 0; j < count; j++)
                {
                    // Создаем экземпляр только один раз
                    if (!isFirstInstanceCreated)
                    {
                        ItemObject newItem = Instantiate(scriptableObjectSO.prefab.GetComponent<ItemObject>());
                        /*ItemObject newItem = new ItemObject();*/

                        if (transform != null)
                        {

                            if (rotation != null)
                            {

                                newItem.Activate(transform, rotation);
                            }
                            else
                            {
                                newItem.Activate(transform);
                            }
                        }
                        else
                        {
                            newItem.Activate();
                        }
                        ItemObjectAddList(newItem);
                        listItemObject.Remove(newItem);

                        isFirstInstanceCreated = true;
                    }
                }
            }
        }
    }
}
