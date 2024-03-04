using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatMovement_Chau : MonoBehaviour
{
    private Rigidbody2D rb;
    float distance = 3f;
    float speed = 1.5f;
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
        transform.position = startPosition + Vector3.right * distanceMoved;
        flip(distanceMoved, spriteRenderer);
    }
    void flip(float distanceMove, SpriteRenderer renderer)
    {
        if (distanceMove < 0.5f)
        {
            renderer.flipX = true;
        }
        else if (distanceMove > 2.5f)
        {
            renderer.flipX = false;
        }
    }
}
