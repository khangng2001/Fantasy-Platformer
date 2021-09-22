using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerBody;
    private float moveSpeed = 5f,jumpForce=4f;
    private BoxCollider2D boxCollider2D;
    [SerializeField] private LayerMask groundLayer;
    private PlayerAnimation playerAnimation;
    private Vector3 temPos;
    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        playerAnimation = GetComponent<PlayerAnimation>();
    }

    private void Update() {
        HandleMovement();
        HandleAnimation();
    }
    
    private void FixedUpdate() {
        HandleJumping();
    }
    private void HandleMovement(){
         temPos = transform.position;
        if(Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.LeftArrow))
        {
            temPos.x -= moveSpeed * Time.deltaTime;
            playerAnimation.RunningAnimation(true);
            playerBody.transform.localScale = new Vector3(-1f, 1f, 1f);
        }else if(Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.RightArrow))
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
    private bool IsGround(){
        return Physics2D.BoxCast(transform.position, boxCollider2D.bounds.size, 0f, Vector2.down,0.1f,groundLayer);
    }
    private void HandleAnimation(){
        playerAnimation.JumpingAnimation(!IsGround());
    }

}
