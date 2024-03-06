using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_NhanNQ : MonoBehaviour
{
    public float speed = 8f;
    public Rigidbody2D rb;
    public GameObject impactEffect;

    void Start()
    {
        rb.velocity = transform.right * speed;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy_Damage enemy = collision.GetComponent<Enemy_Damage>();
        if (enemy != null)
        {
            enemy.TakeDamage(20);
            Debug.Log("Hurt");
        }
        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
