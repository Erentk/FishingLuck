using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Sahne y�netimi i�in gerekli k�t�phane

public class GamePause : MonoBehaviour
{
    private bool isPaused = false; // Oyunun durup durmad���n� kontrol eden bayrak
    private AudioSource[] allAudioSources; // T�m ses kaynaklar�n� tutacak dizi
    public GameObject pauseMenuUI; // Pause men�s�n� g�sterecek UI paneli
    public GameObject endGameUI; // Oyun sonu paneli
    public GameObject restartButton; // Restart butonu

    void Start()
    {
        // Oyunda bulunan t�m AudioSource bile�enlerini bul
        allAudioSources = FindObjectsOfType<AudioSource>();
        endGameUI.SetActive(false); // Oyun sonu UI ba�lang��ta gizli
        restartButton.SetActive(false); // Restart butonu ba�lang��ta gizli
    }

    void Update()
    {
        // P tu�una veya Space tu�una bas�ld���nda oyunu durdur/ba�lat
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Space))
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
        restartButton.SetActive(true); // Restart butonunu aktif yap
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
        restartButton.SetActive(false); // Restart butonunu gizle

        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.UnPause();
        }
    }

    // Oyunun sonu geldi�inde oyun sonu UI'sini g�sterir
    public void EndGame()
    {
        Time.timeScale = 0f; // Oyunu durdur
        endGameUI.SetActive(true); // Oyun sonu panelini a�
        Canvas.ForceUpdateCanvases(); // UI'n�n g�ncellenmesini zorla
        Debug.Log("EndGame called!"); // Oyunun sonland���n� kontrol et
                                      // T�m sesleri durdur
        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.Stop(); // Sesleri tamamen durdur
        }
    }

    // Restart butonuna bas�ld���nda oyunu yeniden ba�lat�r
    public void RestartGame()
    {
        Time.timeScale = 1f; // Zaman �l�e�ini normal yap
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Mevcut sahneyi yeniden y�kle
    }

    // Exit butonuna bas�ld���nda oyundan ��kar
    public void ExitGame()
    {
        Debug.Log("Exiting Game...");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
