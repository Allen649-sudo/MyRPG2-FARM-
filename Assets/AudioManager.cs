using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    public GameObject playerPos;

    private List<AudioSource> audioSources = new List<AudioSource>();
    private const int MaxAudioSources = 10;

    void Start()
    {
        Instance = this;
    }

    public void PlaySound(AudioClip audioClip, Vector3 position = default, float volume = 1f, bool isBackground = false)
    {
        if (position == default)
        {
            position = Camera.main.transform.position;
        }

        AudioSource source = GetAvailableAudioSource();
        if (source != null)
        {
            source.clip = audioClip;
            source.volume = volume;
            source.transform.position = position;
            source.loop = isBackground;
            source.Play();
        }
    }

    private AudioSource GetAvailableAudioSource()
    {
        foreach (var source in audioSources)
        {
            if (!source.isPlaying)
            {
                return source;
            }
        }

        if (audioSources.Count < MaxAudioSources)
        {
            AudioSource newSource = gameObject.AddComponent<AudioSource>();
            audioSources.Add(newSource);
            return newSource;
        }

        return null;
    }

    public void FadeSound(AudioClip audioClip, Vector3 position = default, float volume = 1f)
    {
        StartCoroutine(FadeOut(audioClip, volume));
    }

    private IEnumerator FadeOut(AudioClip audioClip, float volume = 1f)
    {
        foreach (var source in audioSources)
        {
            if (source.clip == audioClip && source.isPlaying)
            {
                while (source.volume > 0)
                {
                    source.volume -= volume * Time.deltaTime;
                    yield return null;
                }

                source.Stop();
                source.volume = volume; // Сброс объёма после угасания
            }
        }
    }
}
