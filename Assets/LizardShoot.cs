using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LizardShoot : MonoBehaviour
{
    public GameObject character;
    public Animator animator;
    public SpriteRenderer sprite;
    void Start()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
