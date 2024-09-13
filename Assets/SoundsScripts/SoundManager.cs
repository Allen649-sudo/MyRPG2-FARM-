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
    }
}
