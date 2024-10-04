using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePause : MonoBehaviour
{
    private bool isPaused = false; // Oyunun durup durmad���n� kontrol eden bayrak
    private AudioSource[] allAudioSources; // T�m ses kaynaklar�n� tutacak dizi
    public GameObject pauseMenuUI; // Pause men�s�n� g�sterecek UI paneli

    void Start()
    {
        // Oyunda bulunan t�m AudioSource bile�enlerini bul
        allAudioSources = FindObjectsOfType<AudioSource>();
    }

    void Update()
    {
        // P tu�una bas�ld���nda oyunu durdur/ba�lat
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                ResumeGame(); // E�er oyun durdurulmu�sa, devam ettir
            }
            else
            {
                PauseGame(); // E�er oyun �al���yorsa, durdur
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        isPaused = true;
        pauseMenuUI.SetActive(true); // Pause men�s�n� g�ster

        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.Pause();
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
        pauseMenuUI.SetActive(false); // Pause men�s�n� gizle

        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.UnPause();
        }
    }
}