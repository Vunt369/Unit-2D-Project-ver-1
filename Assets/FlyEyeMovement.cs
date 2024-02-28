using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEyeMovement : MonoBehaviour
{
    public float amplitude = 1f; // Biên độ của chuyển động
    public float frequency = 1f; // Tần số của chuyển động
    public float speed = 2f;
    void Start()
    {
        startPosition = transform.position;
    }

    private Vector3 startPosition;
    // Update is called once per frame
    void Update()
    {
        float yOffset = amplitude * Mathf.Sin(frequency * Time.time);

        // Áp dụng chuyển động lên xuống vào vị trí Y
        transform.position = startPosition + new Vector3(0f, yOffset, 0f) * speed;
    }
}
