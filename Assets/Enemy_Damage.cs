using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Damage : MonoBehaviour
{
    public GameObject redPartcles;
    public float health = 40;
    public Animator animator;

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            //Die();
            animator.SetBool("isDead", true);
            //redPartcles.SetActive(false);
        }
    }
    void Die()
    {
        Instantiate(redPartcles, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
