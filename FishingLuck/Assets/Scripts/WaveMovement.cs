using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMovement : MonoBehaviour
{
    public float scrollSpeed = 0.5f; // Hýzý artýrabilirsiniz
    public float width = 5f; // Arka planýn geniþliði
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, width);
        transform.position = startPosition + Vector3.left * newPosition;
    }
}
