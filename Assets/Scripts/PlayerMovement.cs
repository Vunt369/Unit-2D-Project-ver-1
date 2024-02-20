using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator animator;
    //int wwholeNumber = 16;
    //float decimalNumber = 5.54f;
    //string texxt = "viet";
    //bool boolean = false;
    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 8;

    private enum MovementSate { idle, running, jumping, falling}
    

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        //Tha ra no se dung chuyen dong ngay lap tuc
        //Danh cho joystick
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        //Xu ly nhay nhieu lan
        
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, 8);
        }
        //Nhan cac anmation
        UpdateAnimation();
        
        
    }

    private void UpdateAnimation()
    {
        MovementSate state;
        //Animaion chay
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
        if(rb.velocity.y > .1f)
        {
            state = MovementSate.jumping;
        }else if(rb.velocity.y < -.1f)
        {
            state = MovementSate.falling;
        }

        animator.SetInteger("state", (int)state);
    }

}
