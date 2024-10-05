using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Sahne yönetimi için gerekli kütüphane

public class GamePause : MonoBehaviour
{
    private bool isPaused = false; // Oyunun durup durmadýðýný kontrol eden bayrak
    private AudioSource[] allAudioSources; // Tüm ses kaynaklarýný tutacak dizi
    public GameObject pauseMenuUI; // Pause menüsünü gösterecek UI paneli
    public GameObject endGameUI; // Oyun sonu paneli
    public GameObject restartButton; // Restart butonu

    void Start()
    {
        // Oyunda bulunan tüm AudioSource bileþenlerini bul
        allAudioSources = FindObjectsOfType<AudioSource>();
        endGameUI.SetActive(false); // Oyun sonu UI baþlangýçta gizli
        restartButton.SetActive(false); // Restart butonu baþlangýçta gizli
    }

    void Update()
    {
        // P tuþuna veya Space tuþuna basýldýðýnda oyunu durdur/baþlat
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Space))
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
        pauseMenuUI.SetActive(false); // Pause menüsünü gizle
        restartButton.SetActive(false); // Restart butonunu gizle

        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.UnPause();
        }
    }

    // Oyunun sonu geldiðinde oyun sonu UI'sini gösterir
    public void EndGame()
    {
        Time.timeScale = 0f; // Oyunu durdur
        endGameUI.SetActive(true); // Oyun sonu panelini aç
        Canvas.ForceUpdateCanvases(); // UI'nýn güncellenmesini zorla
        Debug.Log("EndGame called!"); // Oyunun sonlandýðýný kontrol et
                                      // Tüm sesleri durdur
        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.Stop(); // Sesleri tamamen durdur
        }
    }

    // Restart butonuna basýldýðýnda oyunu yeniden baþlatýr
    public void RestartGame()
    {
        Time.timeScale = 1f; // Zaman ölçeðini normal yap
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Mevcut sahneyi yeniden yükle
    }

    // Exit butonuna basýldýðýnda oyundan çýkar
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
