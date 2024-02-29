using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 3f;
    private Rigidbody2D rb;
   
    [SerializeField]
    private GameObject greenParticles;
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        Vector2 playerDirection = transform.parent.localScale.x > 0 ? transform.right : transform.right;;
        if (playerDirection != null)
        {
            rb.velocity = playerDirection * speed;
        }
        else
        {
            rb.velocity = transform.right * speed;
        }
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if(enemy != null)
        {
            enemy.TakeDamage(20);
          
        }
       // Destroy(gameObject);
    }
}
