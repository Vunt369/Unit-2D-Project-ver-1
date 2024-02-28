using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class CharacterController2D : MonoBehaviour
{
    public float speed = 2f;
    public float jumpForce = 5f;
    public bool canJump;

    private Rigidbody2D rb;
    public Animator animator;
    private float h_move;
    private bool isFacingRight = true;
    private bool isDoubleKeyPress = false;

     void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

     void Update()
    {
        h_move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(h_move * speed, rb.velocity.y);

        if(Input.GetKeyDown(KeyCode.W) && canJump)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            
        }
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
        
        flip();
        animator.SetFloat("move", Mathf.Abs(h_move));
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
}
