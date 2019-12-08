using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;

    public bool aggressive = false;

    public float moveSpeed;
    public float stopDistance;
    private Transform target;
    public CharTalk talk;


    //combat stuff
    private float attackCd = 0;
    public float attackTimer;
    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public float damage;
    public float projectilRange;
    public GameObject projectile;


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

        if (aggressive == true && target != null)
        {
            // follow
            if (Vector2.Distance(transform.position, target.position) < 3 && Vector2.Distance(transform.position, target.position) > 1)
            {

                transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                anim.SetTrigger("walk");
            }
            else
            {
                anim.SetTrigger("idle");

            }


            if (target.position.x > transform.position.x)
            {
                mySpriteRenderer.flipX = true;

            }

            else mySpriteRenderer.flipX = false;

            //attack
            if (attackCd <= 0)
            {


                //range
                if (Vector2.Distance(transform.position, target.position) < 10 && Vector2.Distance(transform.position, target.position) > 5)
                {
                    // Collider2D[] enemiesToShoot = Physics2D.OverlapCircleAll(attackPos.position, projectilRange, whatIsEnemies);

                    //RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, whatIsEnemies);
                    anim.SetTrigger("attack");
                    Instantiate(projectile, attackPos);
                    attackCd = attackTimer;
                }
                

                //melee
                if (Vector2.Distance(transform.position, target.position) < 5)
                {
                    Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                    for (int i = 0; i < enemiesToDamage.Length; i++)
                    {
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

        if (dazedTime <= 1.5)
        {

            moveSpeed = 0;
            dazedTime += Time.deltaTime;
        }

        else
        {
            moveSpeed = 1;
        }
        

        if (health <= 0)
        {

            moveSpeed = 0;
            anim.SetTrigger("dead");


            Destroy(gameObject, 5);

        }
    }




    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(attackPos.position, projectilRange);
    }



    public void EnemyTakeDamage(float damage)
    {
        
        Debug.Log("Enemy takes damage!!!");

        aggressive = true;
        
            health -= damage;

        //knockback
        Vector2 difference = transform.position - target.transform.position;
        transform.position = new Vector2(transform.position.x + difference.x, transform.position.y + difference.y);
        dazedTime = 0;

    }


}
