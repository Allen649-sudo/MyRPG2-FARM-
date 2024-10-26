using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataCreatures : MonoBehaviour
{
    public CreaturesSO creaturesSO;

    HealthBarCreatures healthBarCreatures;

    public ParticleSystem bloodParticleSystem;
    public ParticleSystem spawnParticleSystem;
    public ParticleSystem deathParticleSystem;
    public ParticleSystem combustionParticleSystem;

    void Start()
    {
        healthBarCreatures = GetComponent<HealthBarCreatures>();

        bloodParticleSystem.Stop();
        deathParticleSystem.Stop();
        combustionParticleSystem.Stop();
        combustionParticleSystem.gameObject.SetActive(false);
    }

    public void Active(Vector3 newPosition)
    {
        gameObject.SetActive(true);
        transform.position = newPosition;
        healthBarCreatures.RestartHelth();
        DeactiveCombustion();
        spawnParticleSystem.Play();
    }

    public void Deactive()
    {
        gameObject.SetActive(false);
    }

    private void DeactiveCombustion()
    {
        combustionParticleSystem.gameObject.SetActive(false);
        combustionParticleSystem.Stop();
    }

    public void Combustion()
    {
        combustionParticleSystem.gameObject.SetActive(true);
        combustionParticleSystem.Play();
    }
}
