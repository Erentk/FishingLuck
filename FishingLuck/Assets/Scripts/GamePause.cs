using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePause : MonoBehaviour
{
    private bool isPaused = false; // Oyunun durup durmadýðýný kontrol eden bayrak
    private AudioSource[] allAudioSources; // Tüm ses kaynaklarýný tutacak dizi
    public GameObject pauseMenuUI; // Pause menüsünü gösterecek UI paneli

    void Start()
    {
        // Oyunda bulunan tüm AudioSource bileþenlerini bul
        allAudioSources = FindObjectsOfType<AudioSource>();
    }

    void Update()
    {
        // P tuþuna basýldýðýnda oyunu durdur/baþlat
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                ResumeGame(); // Eðer oyun durdurulmuþsa, devam ettir
            }
            else
            {
                PauseGame(); // Eðer oyun çalýþýyorsa, durdur
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        isPaused = true;
        pauseMenuUI.SetActive(true); // Pause menüsünü göster

        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.Pause();
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
        pauseMenuUI.SetActive(false); // Pause menüsünü gizle

        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.UnPause();
        }
    }
}