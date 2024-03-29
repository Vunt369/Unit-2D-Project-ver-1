﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    [SerializeField] private float speed;
    private bool hit;
    private float direction;
    private BoxCollider2D boxCollider2D;
    private Animator animator;
    private float lifetime;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        if (hit) return;
        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);

        lifetime += Time.deltaTime;
        if (lifetime > 5) gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {

        if (!hit)
        {
            hit = true;
            boxCollider2D.enabled = false;
            if (animator != null) animator.SetTrigger("explode");

            if (collider2D.tag == "Enemy")
            {
                collider2D.GetComponent<EnemyHealth>().TakeDamage(1);
                // Destroy(gameObject);
            }
        }
    }
    public void SetDirection(float _direction)
    {
        lifetime = 0;
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        boxCollider2D.enabled = true;

        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != _direction) //Fireball miss direction 
            localScaleX = -localScaleX;

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }
    public void Deactive()
    {
        gameObject.SetActive(false);
    }
}
