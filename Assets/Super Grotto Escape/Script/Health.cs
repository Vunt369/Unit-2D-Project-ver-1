using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator animator;
    private bool dead;

    [Header("iFrames")]
    [SerializeField] private float iFrameDuration;
    [SerializeField] private int flashedTime;
    private SpriteRenderer spriteRenderer;

    [Header("Components")]
    [SerializeField] private Behaviour[] components;

    private void Awake()
    {
        currentHealth = startingHealth;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);
        if(currentHealth > 0)
        {
            animator.SetTrigger("hurt");
            StartCoroutine(IsVunnerable());
        }
        else
        {
            if(!dead)
            animator.SetTrigger("die");           
            foreach (Behaviour component in components)
                component.enabled = false;


            dead = true;
        }
    }
    private IEnumerator IsVunnerable()
    {
        Physics2D.IgnoreLayerCollision(9,10, true);
        for(int i = 0; i < flashedTime; i++)
        {
            spriteRenderer.color = new Color(0.6529752f, 1, 0, 0.1960784f);
            yield return new WaitForSeconds(iFrameDuration / (flashedTime * 2));
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(iFrameDuration / (flashedTime * 2));
        }
        Physics2D.IgnoreLayerCollision(9, 10, false);
    }
    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    public void Respawn2()
    {
        dead = false;
        AddHealth(startingHealth);
        animator.ResetTrigger("die");
        animator.Play("idle");
        StartCoroutine(IsVunnerable());

        foreach (Behaviour component in components)
            component.enabled = true;
    }
}
