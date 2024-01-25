using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anmi;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 7f;

    private enum MovementSate { idle, running, jumping, falling }
    private MovementSate state = MovementSate.idle;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anmi = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);


        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimationState();

    }

    private void UpdateAnimationState()
    {
        MovementSate state;

        if (dirX > 0f)
        {
            state = MovementSate.running;
            sprite.flipX = false;
        }

        else if (dirX < 0f)
        {
            state = MovementSate.running;
            sprite.flipX = true;
        }

        else
        {
            state = MovementSate.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementSate.jumping;
        }

        else if (rb.velocity.y < -.1f)
        {
            state = MovementSate.falling;
        }

        anmi.SetInteger("state", (int)state);
    }
}
