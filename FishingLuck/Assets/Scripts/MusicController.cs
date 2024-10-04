using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.Play(); // M�zik �almaya ba�lar
        }
    }

    public void SetVolume(float volume)
    {
        if (audioSource != null)
        {
            audioSource.volume = volume; // M�zi�in sesini ayarlama
        }
    }

    public void ToggleMusic(bool play)
    {
        if (audioSource != null)
        {
            if (play)
            {
                audioSource.Play(); // M�zik �almaya ba�lar
            }
            else
            {
                audioSource.Stop(); // M�zik durur
            }
        }
    }
}
