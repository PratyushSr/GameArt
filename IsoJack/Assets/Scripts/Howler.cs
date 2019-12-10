using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Howler : MonoBehaviour
{

    
    private Transform target;
    public CharTalk talk;


    //combat stuff
    private float attackCd = 0;
    public float attackTimer;
    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float damage;
    public float projectilRange;
    public GameObject projectile;


    public float respawnTime;
    private float maxHealth;

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
        transform.position = new Vector3(-10, 41, 0);

    }

    void Update()
    {

        if (this.GetComponent<Enemy>().health <= 0)
        {
            StartCoroutine("Respawn");

        }

        if (target != null && target.position.x > transform.position.x)
        {
            mySpriteRenderer.flipX = true;

        }

        else mySpriteRenderer.flipX = false;


        
        //attack
        if (attackCd <= 0)
        {
            if(Vector2.Distance(transform.position, target.position) < projectilRange)
            {
                anim.SetTrigger("attack");
                Instantiate(projectile, attackPos);
                attackCd = attackTimer;
            }
                
         
        }

        else
        {
            attackCd -= Time.deltaTime;
        }
        

    }
    

    void OnDrawGizmosSelected()
    {
        
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(attackPos.position, projectilRange);
    }




}
