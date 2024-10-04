using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    public float minX = 1f; // Balýðýn minimum hareket aralýðý
    public float maxX = 3f; // Balýðýn maksimum hareket aralýðý
    public float speed = 2f; // Balýðýn hareket hýzý

    private Vector3 startPosition;
    private float direction = 1f; // 1: saða, -1: sola
    private float movementRange; // Hareket aralýðý
    private float moveDistance = 0f; // Þu ana kadar gidilen mesafe

    void Start()
    {
        startPosition = transform.position;
        movementRange = maxX - minX;
    }

    void Update()
    {
        // X ekseninde hareket et
        moveDistance += Time.deltaTime * speed * direction;
        if (Mathf.Abs(moveDistance) >= movementRange)
        {
            // Hareket aralýðýný aþtýðýnda yön deðiþtir ve dönüþ yap
            direction *= -1f;
            moveDistance = Mathf.Clamp(moveDistance, -movementRange, movementRange);
            RotateFish();
        }

        // Yön deðiþtirdiðinde yeni pozisyonu hesapla
        transform.position = startPosition + new Vector3(moveDistance, 0f, 0f);
    }

    void RotateFish()
    {
        // Balýðý Y ekseninde 180 derece döndür
        transform.Rotate(0f, 180f, 0f);
    }
}
