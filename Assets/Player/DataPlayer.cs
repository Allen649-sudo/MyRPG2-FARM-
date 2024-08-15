using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPlayer : MonoBehaviour
{
    private bool haveQuest;

    public int levelPlayer = 1;
    int experience;

    public bool HaveQuest
    {
        get { return haveQuest; }
        set { haveQuest = value; }
    }
}
