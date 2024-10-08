using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    public GameObject playerPos;
    public AudioSource audioSource;

    void Start()
    {
        Instance = this;
    }

    public void PlaySound(AudioClip audioClip, Vector3 position = default, float volume = 1f)
    {
        if (position == null)
        {
            position = Camera.main.transform.position;
        }
        audioSource.clip = audioClip; // Устанавливаем AudioClip
        audioSource.Play();
        audioSource.volume = volume;

    }

    public void FadeSound(AudioClip audioClip, Vector3 position = default, float volume = 1f)
    {
        StartCoroutine(FadeOut(audioClip, volume));
    }

    private IEnumerator FadeOut(AudioClip audioClip, float volume = 1f)
    {

        while (audioSource.volume > 0)
        {
            audioSource.volume -= volume * Time.deltaTime;
            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = volume;
    }
}
