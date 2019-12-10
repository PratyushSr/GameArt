using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boar : MonoBehaviour
{
 
    
    public float moveSpeed;
    // public float stopDistance;
    private Transform target;

    
    //combat stuff
    private float attackCd = -1;
    public float attackTimer;
    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public float damage;
    public float chargeRange;
    public float respawnTime;
     
   // private float dazedTime;

    private SpriteRenderer mySpriteRenderer;

    private float maxHealth;
    private Animator anim;


    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim = GetComponent<Animator>();
        //dazedTime = 2;
        mySpriteRenderer = GetComponent<SpriteRenderer>();

        maxHealth = this.GetComponent<Enemy>().health;
    }

    IEnumerator Respawn()
    {
       
        yield return new WaitForSeconds(respawnTime);
        this.GetComponent<Enemy>().health = maxHealth;
        transform.position = new Vector3(-58, 20, 0);

    }




    IEnumerator Wait()
     {
        anim.SetTrigger("attack");
        moveSpeed = 5;
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        yield return new WaitForSeconds(2.5f);
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<PlayerAttack>().TakeDamage(damage);
            attackCd = attackTimer;
        }
            attackCd = attackTimer;
    }

    void Charge()
    {
        
    }

    void Update()
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
                if (Vector2.Distance(transform.position, target.position) < chargeRange)
                {
                     

                     //Invoke("Charge", 2);
                
                     StartCoroutine("Wait");
                     

            }
                
            }
            else
            {
                attackCd -= Time.deltaTime;
                anim.SetTrigger("idle");
                moveSpeed = 0;
            }
        
        if(this.GetComponent<Enemy>().health <= 0 )
        {
            StartCoroutine("Respawn");

        }
    }




    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(attackPos.position, chargeRange);
    }




}
