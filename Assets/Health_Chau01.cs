using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Chau01 : MonoBehaviour
{
    [SerializeField] private float startHealth;
    public float currentHeath { get; private set; }
    private Animator anim;



    private Rigidbody2D rb;

    private void Awake()
    {
        currentHeath = startHealth;
    }

    public void TakeDamage(float _damage)
    {
        currentHeath = Mathf.Clamp(currentHeath - _damage, 0, startHealth);
        /* if (currentHeath > 0)
         {
             //player hurt

         }
         else
         {
             //player die 

         }*/



    }

}
