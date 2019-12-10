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
    [Tooltip("This is what it drops.... woo")]
    public int DropType;


    //combat stuff
    
    public float damage;
   


    private float dazedTime;

    private SpriteRenderer mySpriteRenderer;


    private Animator anim;
    private bool isDead = false;

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
            Debug.Log("I AM DEAD! Not big souprise");
            moveSpeed = 0;
            anim.SetTrigger("dead");

            if (!isDead)
            {
                isDead = true;

                switch (DropType)
                {
                    case 1: //sabear = 3 raw meat and 1 bone
                        GameObject.Find("HUDCanvas").transform.Find("Inventory").gameObject.GetComponent<Inventory>().AddItem(4, 3);
                        GameObject.Find("HUDCanvas").transform.Find("Inventory").gameObject.GetComponent<Inventory>().AddItem(5, 1);
                        break;
                    case 2: //boar = 1 raw meat and 1 bone
                        GameObject.Find("HUDCanvas").transform.Find("Inventory").gameObject.GetComponent<Inventory>().AddItem(4, 1);
                        GameObject.Find("HUDCanvas").transform.Find("Inventory").gameObject.GetComponent<Inventory>().AddItem(5, 1);
                        break;
                    case 3: //howler = 2 raw meat and 1 bone
                        GameObject.Find("HUDCanvas").transform.Find("Inventory").gameObject.GetComponent<Inventory>().AddItem(4, 2);
                        GameObject.Find("HUDCanvas").transform.Find("Inventory").gameObject.GetComponent<Inventory>().AddItem(5, 1);
                        break;
                }
            }

           // Destroy(gameObject, 5);

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
