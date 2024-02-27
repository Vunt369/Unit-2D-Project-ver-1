using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement_Nhannq : MonoBehaviour
{
    public GameObject character;
    public float moveSpeed = 4f;
    public float jumpSpeed = 10f;
    public Animator animator;
    public SpriteRenderer sprite;
    private CapsuleCollider2D capsuleCollider;

    private Rigidbody2D rb;
    private Vector2 playerInput;
    private bool canJump = true;
    private bool attacking = false;
    private float timeToAttack = 0.2f;
    private float timer = 0;
    private float climbSpeed = 3f;
    private Vector2 moveInput;
    private float gravityScaleAtStart;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        gravityScaleAtStart = rb.gravityScale;
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
    // Update is called once per frame
    void Update()
    {
        float dirX = Input.GetAxis("Horizontal");
        RunAnimation(dirX);
        SlideAnimation();
        JumpAnimation(jumpSpeed);
        ShootAnimation();
        ClimbLadder();
        HurtAnimation();

    }

    private void HurtAnimation()
    {
        //if (!capsuleCollider.IsTouchingLayers(LayerMask.GetMask("Enemies")))
        //{
        //    animator.SetBool("IsHurt", false);
        //    return;
        //}
        if (capsuleCollider.IsTouchingLayers(LayerMask.GetMask("Enemies")))
        {
            animator.SetBool("IsHurt", true);
            rb.velocity = new Vector2(-27f, 5f);
        }

        
        //rb.velocity = new Vector2(0f, -10f);

    }

    private void ClimbLadder()
    {
        if (!capsuleCollider.IsTouchingLayers(LayerMask.GetMask("Climb")))
        {
            animator.SetBool("IsClimb", false);
            rb.gravityScale = gravityScaleAtStart;
            return;
        }
        else 
        {
            if (Input.GetKeyDown("w") || Input.GetKeyDown("s"))
            {
                animator.SetBool("IsClimb", true);
                Vector2 climbVelocity = new Vector2(rb.velocity.x, moveInput.y * climbSpeed);
                rb.velocity = climbVelocity;
                rb.gravityScale = 0f;
            }
            
        }
        
    }

    void ShootAnimation()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetBool("IsShot", true);
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            attacking = true;

        }
        if (attacking)
        {
            timer += Time.deltaTime;
            if (timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                animator.SetBool("IsShot", false);
            }
        }
    }

    void JumpAnimation(float jumpSpeed)
    {
        if (Input.GetKeyDown("w") && canJump && !capsuleCollider.IsTouchingLayers(LayerMask.GetMask("Climb")))
        {
            rb.velocity = new Vector2(rb.velocity.x, 6.3f);
            canJump = false;
            animator.SetBool("CanJump", true);
        }
    }

    private void SlideAnimation()
    {
        if (Input.GetKeyDown("s") || Input.GetKeyDown("down"))
        {
            animator.SetBool("IsSlide", true);
        }
        else if (Input.GetKeyUp("s") || Input.GetKeyUp("down"))
        {
            animator.SetBool("IsSlide", false);
        }
    }

    private void RunAnimation(float dirX)
    {
        rb.velocity = new Vector2(dirX * 4f, rb.velocity.y);
        if (dirX > 0)
        {
            animator.SetFloat("Speed", Mathf.Abs(dirX * 4f));
            sprite.flipX = false;
        }
        else if (dirX < 0)
        {
            animator.SetFloat("Speed", Mathf.Abs(dirX * 4f));
            sprite.flipX = true;
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Surface")) {
            canJump = true;
            animator.SetBool("CanJump", false);
            animator.SetBool("IsSlide", false);
            animator.SetBool("IsClimb", false);
        }
    }
}
