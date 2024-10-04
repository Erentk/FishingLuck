using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<Fish> fishList; // Bal�klar�n listesi
    public Image caughtFishImage; // UI'da g�sterilecek bal�k g�rseli
    public TextMeshProUGUI fishScoreText; // UI'da g�sterilecek puan text'i

    void Start()
    {
        caughtFishImage.gameObject.SetActive(false); // Ba�lang��ta bal�k g�rselini gizle
    }

    public void CatchFish(Fish fish)
    {
        // Yakalanan bal���n g�rselini ve puan�n� UI'ya aktar
        caughtFishImage.sprite = fish.GetFishSprite();
        fishScoreText.text = "Caught: " + fish.GetScoreValue().ToString();

        // Bal�k g�rselini g�ster
        caughtFishImage.gameObject.SetActive(true);
    }

    public void HideFish()
    {
        // Bal�k g�rselini gizle
        caughtFishImage.gameObject.SetActive(false);
    }

    public Fish GetRandomFish()
    {
        int randomIndex = Random.Range(0, fishList.Count); // Rastgele bir bal�k se�
        Fish caughtFish = fishList[randomIndex];
        return caughtFish; // Yakalanan bal��� d�nd�r
    }
}
