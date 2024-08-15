using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClipRefsSo audioClipRefsSo;

    void OnEnable()
    {
        Quest.OnAudioClipSource += Quest_Complete;
    }

    void OnDisable()
    {
        Quest.OnAudioClipSource -= Quest_Complete;
    }

    void Quest_Complete(Quest questWindowPos)
    {
        PlaySound(audioClipRefsSo.questComplete, Camera.main.transform.position);
    }

    private void PlaySound(AudioClip audioClip, Vector3 position, float volume = 1f)
    {
        AudioSource.PlayClipAtPoint(audioClip, position, volume);
        /*AudioSource.PlayClipAtPoint(audioClip, position, volume);*/
    }
}
