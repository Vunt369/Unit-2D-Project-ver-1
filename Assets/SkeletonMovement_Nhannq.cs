using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class SkeletonMovement_Nhannq : MonoBehaviour
{
    public float speed = 0.5f;
    public float distanceMoved;
    private Rigidbody2D rb;
    public float distance;
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
        transform.position = startPosition + Vector3.right * distanceMoved;
        flip(distanceMoved, spriteRenderer, distance);
    }
    void flip(float distanceMove, SpriteRenderer renderer, float distance)
    {
        if (distanceMove < 0.01f)
        {
            renderer.flipX = false;
        }
        else if (distanceMove > distance - 0.1f)
        {
            renderer.flipX = true;
        }
    }
}
