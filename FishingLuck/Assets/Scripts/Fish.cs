using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public int scoreValue;  // Bal���n puan de�eri
    public Sprite fishSprite; // Bal���n g�rseli

    public int GetScoreValue()
    {
        return scoreValue;
    }

    public Sprite GetFishSprite()
    {
        return fishSprite;
    }
}
