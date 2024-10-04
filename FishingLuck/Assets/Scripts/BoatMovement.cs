using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{
    public float amplitude = 0.5f; // Dalgalanma y�ksekli�i
    public float frequency = 1f;   // Dalgalanma h�z�

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Sin dalgas� ile yumu�ak dalgalanma hareketi
        float newY = startPosition.y + Mathf.Sin(Time.time * frequency) * amplitude;
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }
}
