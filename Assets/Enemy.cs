using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject redPartcles;
    public float health = 100;
    public Animator animator;
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
            animator.SetBool("isDead", true);
            Debug.Log("Da die");
        }
    }
    void Start()
    {
    }
    void Die()
    {
        Instantiate(redPartcles, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    
}
