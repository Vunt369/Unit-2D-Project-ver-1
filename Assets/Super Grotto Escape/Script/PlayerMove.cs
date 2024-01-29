using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private LayerMask groundLayer;
    private Rigidbody2D body;
    private Animator animator;
    private bool grounded;
    private BoxCollider2D boxCollider2D;
    private float HorizontalInput;
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        HorizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(HorizontalInput * speed, body.velocity.y);

        //flip player
        if (HorizontalInput > 0.01f)
            transform.localScale = new Vector3(4, 4, 4);
        else if (HorizontalInput < -0.01f)
            transform.localScale = new Vector3(-4, 4, 4);


        if (Input.GetKey(KeyCode.W) && grounded)
            Jump();

        //Set animation parameters
        animator.SetBool("run", HorizontalInput != 0);
        animator.SetBool("grounded", grounded);
    }
    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        animator.SetTrigger("jump");
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;
    }
    private bool isGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit2D.collider != null;
    }
    public bool canAttack()
    {
        return HorizontalInput == 0 && isGrounded();
    }
}