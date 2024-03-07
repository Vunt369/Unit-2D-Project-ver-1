using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class CharacterController2D : MonoBehaviour
{
    public float speed = 2f;
    public bool canJump;

    private Rigidbody2D rb;
    public Animator animator;
    private float h_move;
    private bool isFacingRight = true;
    private bool isDoubleKeyPress = false;

    //Jump 2
    [Header("Jump System")]
    [SerializeField] float jumpTime;
    [SerializeField] float jumpPower;
    [SerializeField] float fallCounter;
    [SerializeField] float jumpMultiplier;

    float jumpCounter;
    bool isJumping;
    Vector2 veGravity;
    //

    void Start()
    {
        veGravity = new Vector2(0, -Physics2D.gravity.y);
        rb = GetComponent<Rigidbody2D>();
    }

     void Update()
    {
        h_move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(h_move * speed, rb.velocity.y);


        Flip();
        slide();
        jump();
        shoot();
        animator.SetFloat("move", Mathf.Abs(h_move));
    }

    void shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetBool("isShooting", true);
        }
        else
        {
            animator.SetBool("isShooting", false);
        }
    }
    void Flip()
    {
        if (isFacingRight && h_move < 0)
        {
            Rotate(180f);
            isFacingRight = false;
        }
        else if (!isFacingRight && h_move > 0)
        {
            Rotate(0f);
            isFacingRight = true;
        }
    }
    IEnumerator CheckDoublePress()
    {
        yield return new WaitForSeconds(0.5f);
        isDoubleKeyPress = false;
    }
    IEnumerator StopSlide()
    {
        yield return new WaitForSeconds(0.5f);
        isDoubleKeyPress = false;
        animator.Play("idle");
        animator.SetBool("slide", false);
    }
    private void OnTriggerEnter2D(Collider2D hitboxkhac)
    {
        if(hitboxkhac.gameObject.tag == "Ground")
        {
            canJump = true;
            animator.SetBool("jump", false);
        }

    }
    private void OnTriggerExit2D(Collider2D hitboxkhac)
    {
        if (hitboxkhac.gameObject.tag == "Ground")
        {
            canJump = false;
            animator.SetBool("jump", true);
        }
    }

    void jump()
    {

        if (Input.GetKeyDown(KeyCode.W) && canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            isJumping = true;
            jumpCounter = 0;
        }

        if (Input.GetKey(KeyCode.W) && isJumping)
        {
            if (rb.velocity.y > 0 && jumpCounter < jumpTime)
            {

                float t = jumpCounter / jumpTime;
                float currentJump = Mathf.Lerp(jumpPower, jumpPower * jumpMultiplier, t);
                rb.velocity = new Vector2(rb.velocity.x, currentJump);
                jumpCounter += Time.deltaTime;
            }
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            isJumping = false;
            jumpCounter = 0;
        }
    }
    void flip()
    {
        if(isFacingRight && h_move < 0 || !isFacingRight && h_move > 0)
        {
            isFacingRight = !isFacingRight;
            Vector3 kich_thuoc = transform.localScale;
            kich_thuoc.x = kich_thuoc.x * (-1);
            transform.localScale = kich_thuoc;
        }
    }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           
    void slide()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            if (!isDoubleKeyPress)
            {
                isDoubleKeyPress = true;
                StartCoroutine(CheckDoublePress());
            }
            else
            {
                animator.SetBool("slide", true);
                StartCoroutine("StopSlide");
            }
        }
    }
    private void Rotate(float angle)
    {
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
    }
}
