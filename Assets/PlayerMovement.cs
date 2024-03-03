using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anmi;
    private float timer = 0;
    private bool attacking = false;
    private float timeToAttack = 0.2f;
    private CapsuleCollider2D capsuleCollider;

    public Transform shootingPoint;
    public GameObject bulletPrefab;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 7f;

    private enum MovementSate { idle, running, jumping, falling }
    private MovementSate state = MovementSate.idle;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        anmi = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);


        //if (Input.GetButtonDown("Jump") && IsGrounded())
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        /*if(Keyboard.current.spaceKey.wasPressedThisFrame)
        {

        }*/

        ShootAnimation();
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

    void ShootAnimation()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            anmi.SetBool("IsShoot", true);
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
                anmi.SetBool("IsShoot", false);
            }
        }
    }

    /*private void HurtAnimation()
    {
        if (capsuleCollider.IsTouchingLayers(LayerMask.GetMask("Enemies")))
        {
            anmi.SetBool("IsHurt", true);
            rb.velocity = new Vector2(-27f, 5f);
        }

    }*/

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 7f, Vector2.down, .1f, jumpableGround);
    }
}
