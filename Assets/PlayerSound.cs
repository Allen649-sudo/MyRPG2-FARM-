using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    DataPlayer dataPlayer;

    void Start()
    {
        dataPlayer = GetComponent<DataPlayer>();
    }

    public void SoundFootSteps()
    {
        if (dataPlayer.soundFootsteps != null)
        {
            AudioManager.Instance.PlaySound(dataPlayer.soundFootsteps, transform.position, 0.4f);
        }
    }
}
