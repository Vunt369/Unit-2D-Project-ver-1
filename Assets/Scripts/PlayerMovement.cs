using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator animator;

    [SerializeField] private LayerMask jumpableGround;

    //int wwholeNumber = 16;
    //float decimalNumber = 5.54f;
    //string texxt = "viet";
    //bool boolean = false;
    private float dirX = 0f;
    public float fallMultiplier = 3.0f;
    public float lowJumpMultiplier = 3.0f;
    //Danh cho sliding
    private bool aButtonPressed = false;
    private float doubleClickTime = 0.2f;
    private float lastClickTime = 0f;
    private bool isSliding = false;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 8;

    private enum MovementSate { idle, running, jumping, falling, sliding, ducking }


    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
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

        if (Input.GetButtonDown("Jump") && isGrounded())
        {

            rb.velocity = new Vector2(rb.velocity.x - 1, 7.5f);
        }
        

        //Nhan cac anmation
        ApplyFall();
        UpdateAnimation();
        PlayerSliding();

    }

    public void ApplyFall()
    {
        if (rb.velocity.y < -.1f)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > -.1f && Input.GetButtonDown("Jump"))
        {
            rb.velocity -= Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

    }
    //Danh cho sliding
    private void PlayerSliding()
    {
        

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            
            if ((Time.time - lastClickTime) < doubleClickTime)
            {

                Debug.Log("Double click");
                isSliding = true;
                
            }
            else
            {
                lastClickTime = Time.time;
                
            }
        };
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
        else if (isSliding)
        {
            state = MovementSate.sliding;
            
        }else if(Input.GetKeyDown(KeyCode.S) && dirX == 0f){
            state = MovementSate.ducking;
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




        animator.SetInteger("state", (int)state);
    }
    
    

    //Ground check
    private bool isGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

}
