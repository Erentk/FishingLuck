using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public int scoreValue;  // Balýðýn puan deðeri
    public Sprite fishSprite; // Balýðýn görseli

    public int GetScoreValue()
    {
        return scoreValue;
    }

    public Sprite GetFishSprite()
    {
        return fishSprite;
    }
}
