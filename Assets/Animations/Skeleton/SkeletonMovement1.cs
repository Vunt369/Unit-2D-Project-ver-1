using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMovement1 : MonoBehaviour
{
    public float speed = 0.5f;
    public float distanceMoved;
    private Rigidbody2D rb;
    public float distance = 2f;
    private Vector3 startPosition;
    SpriteRenderer spriteRenderer;
    void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        distanceMoved = Mathf.PingPong(Time.time * speed, distance);

        // Di chuyển theo trục X
        transform.position = startPosition + Vector3.left * distanceMoved;
        flip(distanceMoved, spriteRenderer);
    }
    void flip(float distanceMove, SpriteRenderer renderer)
    {
        if (distanceMove < 0.05f)
        {
            renderer.flipX = false;
        }
        else if (distanceMove > 1.95f)
        {
            renderer.flipX = true;
        }
    }
}
