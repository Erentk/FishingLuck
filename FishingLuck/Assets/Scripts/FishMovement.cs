using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    public float minX = 1f; // Bal���n minimum hareket aral���
    public float maxX = 3f; // Bal���n maksimum hareket aral���
    public float speed = 2f; // Bal���n hareket h�z�

    private Vector3 startPosition;
    private float direction = 1f; // 1: sa�a, -1: sola
    private float movementRange; // Hareket aral���
    private float moveDistance = 0f; // �u ana kadar gidilen mesafe

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
            // Hareket aral���n� a�t���nda y�n de�i�tir ve d�n�� yap
            direction *= -1f;
            moveDistance = Mathf.Clamp(moveDistance, -movementRange, movementRange);
            RotateFish();
        }

        // Y�n de�i�tirdi�inde yeni pozisyonu hesapla
        transform.position = startPosition + new Vector3(moveDistance, 0f, 0f);
    }

    void RotateFish()
    {
        // Bal��� Y ekseninde 180 derece d�nd�r
        transform.Rotate(0f, 180f, 0f);
    }
}
