using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject redPartcles;
    public float health = 100;
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
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
