using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife_Chau : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private Health_Chau01 health;
    // private Vector3 startPosition;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        health = GetComponent<Health_Chau01>();

        //  startPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bat"))
        {
            //  transform.position = startPosition;
            health.TakeDamage(1);

            if (health.currentHeath <= 0)
            {
                Die();
            }
            else
            {
                Hurt();
            }
        }
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("Death");
        gameObject.SetActive(false); // Disable the gameObject
    }
    private void Hurt()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        anim.SetTrigger("hurt");
    }
}
