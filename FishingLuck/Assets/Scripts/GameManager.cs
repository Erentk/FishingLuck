using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<Fish> fishList; // Balýklarýn listesi
    public Image caughtFishImage; // UI'da gösterilecek balýk görseli
    public TextMeshProUGUI fishScoreText; // UI'da gösterilecek puan text'i

    void Start()
    {
        caughtFishImage.gameObject.SetActive(false); // Baþlangýçta balýk görselini gizle
    }

    public void CatchFish(Fish fish)
    {
        // Yakalanan balýðýn görselini ve puanýný UI'ya aktar
        caughtFishImage.sprite = fish.GetFishSprite();
        fishScoreText.text = "Caught: " + fish.GetScoreValue().ToString();

        // Balýk görselini göster
        caughtFishImage.gameObject.SetActive(true);
    }

    public void HideFish()
    {
        // Balýk görselini gizle
        caughtFishImage.gameObject.SetActive(false);
    }

    public Fish GetRandomFish()
    {
        int randomIndex = Random.Range(0, fishList.Count); // Rastgele bir balýk seç
        Fish caughtFish = fishList[randomIndex];
        return caughtFish; // Yakalanan balýðý döndür
    }
}
