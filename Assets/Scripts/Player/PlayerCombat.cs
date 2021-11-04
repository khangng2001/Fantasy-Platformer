using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private float attackRange = 0.2f;
    private float attackRate = 2f;
    private float nextAttackTime = 0f;
    private PlayerAnimation playerAnimation;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private LayerMask enemyLayer;
    private void Start()
    {
        playerAnimation = GetComponent<PlayerAnimation>();
    }
    private void FixedUpdate()
    {
        HandleAttack();
    }
    private void HandleAttack()
    {
        if (Time.time > nextAttackTime)
        {
            if (Input.GetKey(KeyCode.J))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }
    private void Attack()
    {
        playerAnimation.AttackAnimation();
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
        foreach (Collider2D enemy in hitEnemies)
        {
            
        }

    }
}
