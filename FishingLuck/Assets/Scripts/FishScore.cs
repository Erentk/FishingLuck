using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishScore : MonoBehaviour
{
    public int pointValue; // Bal���n puan de�eri
    public int GetScore()
    {
        return pointValue; // Puan de�erini d�nd�r
    }
    void Start()
    {
        // Her bal��a manuel olarak puan de�eri atanabilir
        // pointValue = 10; // �rnek: Bu bal�k 10 puan de�eri verir
    }
}
