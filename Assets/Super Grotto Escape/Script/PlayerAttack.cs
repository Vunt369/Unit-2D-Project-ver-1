using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    private float cooldownTime = 999999999;
    private Animator animator;
    private PlayerMove PlayerMove;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        PlayerMove = GetComponent<PlayerMove>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && cooldownTime > attackCooldown && PlayerMove.canAttack()) {
            Attack();

            cooldownTime += Time.deltaTime;
        }
    }

    private void Attack()
    {
        animator.SetTrigger("attack");
        cooldownTime = 0;
    }

}
