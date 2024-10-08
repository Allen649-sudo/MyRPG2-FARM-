using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBarCreatures : MonoBehaviour
{
    DataCreatures dataCreatures;

    public Slider healthBar;
    GettingWoundAndDeath gettingWoundAndDeath;

    void Start()
    {
        dataCreatures = GetComponent<DataCreatures>();

        gettingWoundAndDeath = GetComponent<GettingWoundAndDeath>();
        healthBar.maxValue = dataCreatures.creaturesSO.health;
        healthBar.value = 100f;
    }

    public void RestartHelth()
    {
        healthBar.value = 100f;
    }

    public void ShowHealthBar(int amountDamageDealt)
    {
        healthBar.gameObject.SetActive(true);
        healthBar.value -= amountDamageDealt;
        if (healthBar.value > 0)
        {
            gettingWoundAndDeath.GettingWound();
        }
        else 
        {
            gettingWoundAndDeath.DeathCreatures();
        }

    }
}
