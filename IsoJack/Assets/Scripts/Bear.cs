using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : MonoBehaviour
{
   
    

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

    public float respawnTime;
    private float maxHealth;

    private float dazedTime;

    private SpriteRenderer mySpriteRenderer;


    private Animator anim;


    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        maxHealth = this.GetComponent<Enemy>().health;
    }


    IEnumerator Respawn()
    {

        yield return new WaitForSeconds(respawnTime);
        this.GetComponent<Enemy>().health = maxHealth;
        transform.position = new Vector3(9, 33, 0);

    }

    void Update()
    {
        if (target != null)
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


                //melee
                if (Vector2.Distance(transform.position, target.position) < 3)
                    anim.SetTrigger("attack");
                {
                    Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                    for (int i = 0; i < enemiesToDamage.Length; i++)
                    {
                        
                        enemiesToDamage[i].GetComponent<PlayerAttack>().TakeDamage(damage);
                        attackCd = attackTimer;
                    }


                }


            }

            else
            {
                attackCd -= Time.deltaTime;
            }


        }
        if (this.GetComponent<Enemy>().health <= 0)
        {
            StartCoroutine("Respawn");

        }
    }




    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    
}
