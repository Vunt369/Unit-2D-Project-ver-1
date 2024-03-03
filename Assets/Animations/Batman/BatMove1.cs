using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatMove1 : MonoBehaviour
{
    private Rigidbody2D rb;
    float distance = 5f;
    float speed = 2f;
    private SpriteRenderer spriteRenderer;
    private Vector3 startPosition;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        spriteRenderer = rb.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceMoved = Mathf.PingPong(Time.time * speed, distance);
        transform.position = startPosition + Vector3.left * distanceMoved;
        flip(distanceMoved, spriteRenderer);
    }
    void flip(float distanceMove, SpriteRenderer renderer)
    {
        if (distanceMove < 0.05f)
        {
            renderer.flipX = false;
        }
        else if (distanceMove > 4.95f)
        {
            renderer.flipX = true;
        }
    }
}
