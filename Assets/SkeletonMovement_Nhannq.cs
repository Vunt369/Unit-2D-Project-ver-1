using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class SkeletonMovement_Nhannq : MonoBehaviour
{
    public GameObject character;
    public float moveSpeed = 2f;
    public float distance = 14f;
    public Animator animator;
    public SpriteRenderer sprite;

    private Rigidbody2D rb;
    private float initPosition;
    private float endPosition;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        initPosition = rb.position.x;
        endPosition = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        
        rb.position.Set(-2.91f, -0.22f);
        var currentPosition = rb.position.x;
        if (currentPosition < endPosition && currentPosition > initPosition)
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else if (currentPosition > endPosition)
        {
            rb.velocity = new Vector2(moveSpeed * -1, rb.velocity.y);
            sprite.flipX = true;
        }
        else if (currentPosition < initPosition)
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            sprite.flipX = true;
        }
    }
}
