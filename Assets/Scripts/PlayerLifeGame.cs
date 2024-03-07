using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLifeGame : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacles"))
        {
            PlayerDie();
        }
    }
    private void PlayerDie()
    {
        rb.bodyType = RigidbodyType2D.Static;
        animator.SetTrigger("death");
    }

    private void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
