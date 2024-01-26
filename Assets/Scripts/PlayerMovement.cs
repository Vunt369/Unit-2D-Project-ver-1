using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    //int wwholeNumber = 16;
    //float decimalNumber = 5.54f;
    //string texxt = "viet";
    //bool boolean = false;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        //Tha ra no se dung chuyen dong ngay lap tuc
        //Danh cho joystick
        rb.velocity = new Vector2(dirX * 7f, rb.velocity.y);

        
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x,5);
        }

        if (dirX > 0f)
        {
            animator.SetBool("running", true);
        }
        else if (dirX < 0f)
        {
            animator.SetBool("running", true);

        }
        else
        {
            animator.SetBool("running", false);

        }
    }
}
