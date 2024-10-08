using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GettingWoundPlayer : MonoBehaviour
{
    DataPlayer dataPlayer;
    ParticleSystem bloodParticleSystem;

    public SpriteRenderer spriteRenderer;
    public Color damagedColor = new Color(1.0f, 0.0f, 0.0f, 1.0f);

    void Start()
    {
        dataPlayer = GetComponent<DataPlayer>();
        audioSource = gameObject.AddComponent<AudioSource>();

        bloodParticleSystem = dataPlayer.bloodParticleSystem;
        bloodParticleSystem.Stop();
    }
    private AudioSource audioSource;

    public void GetInjury()
    {
        bloodParticleSystem.Play();
        bloodParticleSystem.transform.position = gameObject.transform.position;
        if (dataPlayer.hitSound != null)
        {
            audioSource.clip = dataPlayer.hitSound;
            audioSource.Play();
        }

        StartCoroutine(Damage());
    }

    IEnumerator Damage()
    {
        spriteRenderer.color = damagedColor;

        yield return new WaitForSeconds(0.2f);

        spriteRenderer.color = Color.white;
    }
}
