﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Health;
    public float maxhealth=10;
    public PlayerHealthBar healthBar;
    private Rigidbody2D playerBody;
    private float moveSpeed = 5f,jumpForce=4f;
    private BoxCollider2D boxCollider2D;
    [SerializeField] private LayerMask groundLayer,enemyLayer;
    private PlayerAnimation playerAnimation;
    private Vector3 temPos;
    [SerializeField] private Transform attackPoint;
    private float attackRange=0.2f;
    void Start()
    {
        Health = maxhealth;
        healthBar.setHealth(Health, maxhealth);
        playerBody = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        playerAnimation = GetComponent<PlayerAnimation>();
    }  
    private void FixedUpdate() {
        HandleJumping();
        HandleMovement();
        HandleAttack();
        HandleAnimation();
    }
    private void HandleMovement(){
         temPos = transform.position;
        if(Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.LeftArrow))
        {
            temPos.x -= moveSpeed * Time.deltaTime;
            playerAnimation.RunningAnimation(true);
            playerBody.transform.localScale = new Vector3(-1f, 1f, 1f);
        }else if(Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.RightArrow) )
        {
            temPos.x += moveSpeed * Time.deltaTime;
            playerBody.transform.localScale = Vector3.one;
            playerAnimation.RunningAnimation(true);
        }
        else{
             playerAnimation.RunningAnimation(false);
        }
        transform.position = temPos;
    }
    private void HandleJumping(){
        if(Input.GetKey(KeyCode.Space)){
            if (IsGround()){
                playerBody.velocity = new Vector2(playerBody.velocity.x, jumpForce);
            }
        }
    }
     private void HandleAttack(){
        if(Input.GetKey(KeyCode.J)){
            Attack();
        }
    }
    private void Attack(){
        playerAnimation.AttackAnimation();
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange,enemyLayer);
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("Attack: " + enemy.name);
        }
       
    }
    private bool IsGround(){
        return Physics2D.BoxCast(transform.position, boxCollider2D.bounds.size, 0f, Vector2.down,0.1f,groundLayer);
    }
    private void HandleAnimation(){
        playerAnimation.JumpingAnimation(!IsGround());
    }
    
}
