using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Health;
    public float maxhealth=10;
    private Rigidbody2D playerBody;
    public float moveSpeed = 5f,jumpForce=4f;
    private BoxCollider2D boxCollider2D;
    [SerializeField] private LayerMask groundLayer;
    private PlayerAnimation playerAnimation;
    private Vector3 temPos;
    private bool DodgeRoll;
    [SerializeField] private float DodgeSpeed;
    [SerializeField] private float DodgeTime;
    public float dir;
    void Start()
    {
        Health = maxhealth;
        playerBody = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        playerAnimation = GetComponent<PlayerAnimation>();
    }

    private void FixedUpdate() {
        HandleJumping();
        HandleMovement();        
        HandleAnimation();
        HandleDodging();
    }
    private void HandleMovement(){
         temPos = transform.position;
         if(moveSpeed!=0)
        {
         
        if(Input.GetKey(KeyCode.A) ||Input.GetKey(KeyCode.LeftArrow))
        {
            temPos.x -= moveSpeed * Time.deltaTime;
            playerAnimation.RunningAnimation(true);
            playerBody.transform.localScale = new Vector3(-1f, 1f, 1f);
            dir =1;
        }else if(Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.RightArrow) )
        {
            temPos.x += moveSpeed * Time.deltaTime;
            playerBody.transform.localScale = Vector3.one;
            playerAnimation.RunningAnimation(true);
            dir = 0;
        }
        else {
             playerAnimation.RunningAnimation(false);
        }
        }
        else {
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

    private void HandleDodging()
    {
        if(DodgeRoll)
        {
            if(dir == 1)
            {
                playerBody.AddForce(-transform.position * DodgeSpeed);
            }
            if(dir ==0)
            {
                playerBody.AddForce(transform.position * DodgeSpeed);
            }
        }
        if(Input.GetKeyDown(KeyCode.C) && !IsRollin.isrolling && RollingBar.instance.Stamina >=5)
        {
            RollingBar.instance.useStamina(5);
            playerAnimation.DodgingAnimation();
            StartCoroutine(IsDodge());
        }
    }
    IEnumerator IsDodge()
    {
        DodgeRoll = true;
        yield return new WaitForSeconds(DodgeTime);
        DodgeRoll =false;
    }
}