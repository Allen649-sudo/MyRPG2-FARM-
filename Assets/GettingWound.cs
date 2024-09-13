using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GettingWound : MonoBehaviour
{
    public ParticleSystem bloodParticleSystem;

    public SpriteRenderer spriteRenderer;
    public Color damagedColor = new Color(1.0f, 0.0f, 0.0f, 1.0f);

    void Start()
    {
        bloodParticleSystem.Stop();
    }

    public void GetInjury(Vector3 posSpawnBlood)
    {
        bloodParticleSystem.Play();
        bloodParticleSystem.transform.position = posSpawnBlood;
        StartCoroutine(Damage());
    }

    IEnumerator Damage()
    {
        spriteRenderer.color = damagedColor;

        yield return new WaitForSeconds(0.2f);

        spriteRenderer.color = Color.white;
    }
}
