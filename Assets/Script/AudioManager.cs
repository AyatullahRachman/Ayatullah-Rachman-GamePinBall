using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource AudioBGM;
    public GameObject AudioSFX;

    private void Start()
    {
        if (AudioBGM != null)
        {
            AudioBGM.Play();
        }
    }

    private void PlayBGM()
    {
        AudioBGM.Play();
    }

    public void PlaySFX(Vector3 spawnPosition)
    {
        if (AudioSFX != null)
        {
            Instantiate(AudioSFX, spawnPosition, Quaternion.identity);
        }
    }
}
