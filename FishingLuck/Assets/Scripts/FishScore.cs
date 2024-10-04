using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishScore : MonoBehaviour
{
    public int pointValue; // Balýðýn puan deðeri
    public int GetScore()
    {
        return pointValue; // Puan deðerini döndür
    }
    void Start()
    {
        // Her balýða manuel olarak puan deðeri atanabilir
        // pointValue = 10; // Örnek: Bu balýk 10 puan deðeri verir
    }
}
