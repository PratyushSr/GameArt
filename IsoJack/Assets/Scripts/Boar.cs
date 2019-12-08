using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boar : MonoBehaviour
{
 
    
    public float moveSpeed;
    // public float stopDistance;
    private Transform target;

    
    //combat stuff
    private float attackCd = 0;
    public float attackTimer;
    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public float damage;



    private float dazedTime;

    private SpriteRenderer mySpriteRenderer;


    private Animator anim;


    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim = GetComponent<Animator>();
        dazedTime = 2;
        mySpriteRenderer = GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        if (target != null)
        {
            if (target.position.x > transform.position.x)
            {
                mySpriteRenderer.flipX = true;

            }

            else mySpriteRenderer.flipX = false;

            //attack
            if (attackCd <= 0)
            {

                //melee
                if (Vector2.Distance(transform.position, target.position) < 10)
                {
                    moveSpeed = 5;
                    transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);


                    Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                    for (int i = 0; i < enemiesToDamage.Length; i++)
                    {
                        moveSpeed = 1;
                        enemiesToDamage[i].GetComponent<PlayerAttack>().TakeDamage(damage);
                        anim.SetTrigger("attack");
                        attackCd = attackTimer;
                    }
                }


            }

        else
        {
            attackCd -= Time.deltaTime;
        }
        
    }




    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }




}
