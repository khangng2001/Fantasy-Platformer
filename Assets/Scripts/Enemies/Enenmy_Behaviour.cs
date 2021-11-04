using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enenmy_Behaviour : MonoBehaviour
{
    #region Public Variables
    /* public Transform raycast;
     public LayerMask raycastMask;
     public float raycastLength;*/
    public float attackDistance; //Minimum distance for attack
    public float moveSpeed;
    public float timer; //Timer for cooldown between attacks
    public Transform leftBoundary;
    public Transform rightBoundary;
    [HideInInspector] public Transform target;
    [HideInInspector] public bool inRange; // Check if player is in range for enemy to attack
    public GameObject hotZone;
    public GameObject triggerArea;
    #endregion

    #region Private Variables
    /*private RaycastHit2D raycastHit;*/
    private Animator anim;
    private float distance; //Distance between enemy and player
    private bool attackMode;
    private bool cooling; //check if enemy attack is cooling
    private float initTimer;
    #endregion

    private void Awake()
    {
        SelectTarget();
        initTimer = timer; //Store inital value for timer;
        anim = GetComponent<Animator>();

    }
    void Update()
    {
        if (!attackMode)
        {
            Move();
        }
        if (!InsideOfBoundary() && !inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            SelectTarget();
        }
        //When Player is detected (detect but not in distanceattack)
        if (inRange) //inRange == false check later
        {
            EnemyLogic();
        }
    }


    private void EnemyLogic()
    {
       
        distance = Vector2.Distance(target.position, transform.position);
        if (distance > attackDistance)
        {
            StopAttack();
        }else if (distance <= attackDistance && cooling==false)
        {
            Attack();
        }
        if (cooling)
        {
            CoolDown();
            anim.SetBool("Attack", false);
        }
    }

    private void Attack()
    {
        timer = initTimer; //Reset Timer when Player enter Attack Range
        attackMode = true; // check if enemy can attack
        anim.SetBool("canWalk", false);
        anim.SetBool("Attack", true);  
    }

    private void StopAttack()
    {
        cooling = false;
        attackMode = false;
        anim.SetBool("Attack", false);
    }

    private void Move()
    {

        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            Vector2 tempPosition = new Vector2(target.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, tempPosition,moveSpeed*Time.deltaTime);
            anim.SetBool("canWalk", true);
        }
    }

    private void CoolDown()
    {
        timer -= Time.deltaTime;
        if(timer <=0 && cooling && attackMode==true)
        {
            timer = initTimer;
            cooling = false;
        }
    }

   
    public void TriggerCooling()
    {
        cooling = true;
    }
    private bool InsideOfBoundary()
    {
        return transform.position.x > leftBoundary.position.x && transform.position.x < rightBoundary.position.x;
    }
    public void SelectTarget()
    {
        float distanceToLeft = Vector2.Distance(transform.position, leftBoundary.position);
        float distanceToRight = Vector2.Distance(transform.position, rightBoundary.position);

        if (distanceToLeft>distanceToRight)
        {
            target = leftBoundary;
        }
        else if(distanceToLeft < distanceToRight)
        {
            target = rightBoundary;
        }
        Flip();
    }

    public void Flip()
    {
        Vector3 rotation = transform.eulerAngles;
        if (transform.position.x > target.position.x)
        {
            rotation.y = 180f;
        }
        else
        {
            rotation.y = 0f;
        }
        transform.eulerAngles = rotation;
    }
}
