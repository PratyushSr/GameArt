using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;

  

    public float moveSpeed;
    public float stopDistance;
    private Transform target;
    public CharTalk talk;


    //combat stuff
    
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

    


    public void EnemyTakeDamage(float damage)
    {
        
        Debug.Log("Enemy takes damage!!!");

 
        
            health -= damage;

        //knockback
        Vector2 difference = transform.position - target.transform.position;
        transform.position = new Vector2(transform.position.x + difference.x, transform.position.y + difference.y);
        dazedTime = 0;

    }


}
