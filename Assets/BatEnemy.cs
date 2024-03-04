using UnityEngine;

public class BatEnemy : MonoBehaviour
{
    public float health = 40;
    private Animator anim;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("die");
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Die();
        }
    }
}
