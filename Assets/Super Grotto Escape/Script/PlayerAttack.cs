using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private GameObject[] bullet;
    private float cooldownTime = Mathf.Infinity;
    private Animator animator;
    private PlayerMove PlayerMove;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        PlayerMove = GetComponent<PlayerMove>();
    }

    private void Update()
    {
        //if (Input.GetMouseButtonDown(0) && cooldownTime > attackCooldown && PlayerMove.CanAttack()) 
        //{
        //    Attack();
        //    cooldownTime += Time.deltaTime;
        //}        
        
        if (Input.GetMouseButtonDown(0) && PlayerMove.CanAttack()) 
        {
            Attack();
            cooldownTime += Time.deltaTime;
        }
    }

    private void Attack()
    {
        animator.SetTrigger("attack");
        cooldownTime = 0;

        bullet[Findbullet()].transform.position = attackPoint.position;
        bullet[Findbullet()].GetComponent<ShootingController>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    private int Findbullet()
    {
        for (int i = 0; i < bullet.Length; i++)
        {
            if (!bullet[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}
