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
            audioSource.Play(); // Müzik çalmaya baþlar
        }
    }

    public void SetVolume(float volume)
    {
        if (audioSource != null)
        {
            audioSource.volume = volume; // Müziðin sesini ayarlama
        }
    }

    public void ToggleMusic(bool play)
    {
        if (audioSource != null)
        {
            if (play)
            {
                audioSource.Play(); // Müzik çalmaya baþlar
            }
            else
            {
                audioSource.Stop(); // Müzik durur
            }
        }
    }
}
