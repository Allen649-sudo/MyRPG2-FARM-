using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GettingWoundAndDeath : MonoBehaviour
{
    DataCreatures dataCreatures;
    HealthBarCreatures healthBarCreatures;
    ParticleSystem bloodParticleSystem;
    PlayerDetectionAndCauseDamage playerDetectionAndCauseDamage;

    public SpriteRenderer spriteRenderer;
    public Color damagedColor = new Color(1.0f, 0.0f, 0.0f, 1.0f);

    private float combustionInterval = 2f;
    private int burningDamage = 2;

    void OnEnable()
    {
        ComingNight.OnCombustionCreatures += Combustion;
    }

    void OnDisable()
    {
        ComingNight.OnCombustionCreatures -= Combustion;
    }

    void Start()
    {
        dataCreatures = GetComponent<DataCreatures>();
        playerDetectionAndCauseDamage = GetComponent<PlayerDetectionAndCauseDamage>();
        healthBarCreatures = GetComponent<HealthBarCreatures>();

        bloodParticleSystem = dataCreatures.bloodParticleSystem;
    }

    public void GetInjury(Vector3 posSpawnBlood, int amountDamageDealt, GameObject playerObj = null)
    {
        healthBarCreatures.ShowHealthBar(amountDamageDealt);
        
        bloodParticleSystem.Play();
        bloodParticleSystem.transform.position = posSpawnBlood;
        if (playerObj != null)
        {
            playerDetectionAndCauseDamage.TryPlayerTransform(playerObj);
        }
        if (dataCreatures.creaturesSO.hitSound != null)
        {
            AudioManager.Instance.PlaySound(dataCreatures.creaturesSO.hitSound, default, 0.8f);
        }
    }

    public void GettingWound()
    {
        StartCoroutine(Damage());
    }

    IEnumerator Damage()
    {
        spriteRenderer.color = damagedColor;

        yield return new WaitForSeconds(0.2f);

        spriteRenderer.color = Color.white;
    }

    public void DeathCreatures()
    {
        StartCoroutine(HandleDeath());
    }

    private IEnumerator HandleDeath()
    {
        dataCreatures.deathParticleSystem.Play();
        yield return new WaitForSeconds(dataCreatures.deathParticleSystem.main.duration - 0.1f);
        dataCreatures.Deactive();
    }

    public void Combustion()
    {
        if (dataCreatures.creaturesSO.tryBurnWhenDay)
        {
            dataCreatures.Combustion();
            StartCoroutine(StartCombustion());
        }
    }

    IEnumerator StartCombustion()
    {
        GetInjury(transform.position, burningDamage);

        yield return new WaitForSeconds(combustionInterval);

        StartCoroutine(StartCombustion());
    }
}
