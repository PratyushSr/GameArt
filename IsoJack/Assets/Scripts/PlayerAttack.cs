using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float attackCd = -1;
    public float attackTimer;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public float damage;

    public float health;
    private float maxHealth;

    

    private void Start()
    {
        maxHealth = health;
        transform.position = new Vector3(-94, 30, 0);
        

    }

    void Update()
    {

        if (attackCd <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
               
                
                Debug.Log("q is pressed");
                attackCd = attackTimer;
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().EnemyTakeDamage(damage);
                }

            }
            

        }
        else
        {
            attackCd -= Time.deltaTime;
        }
        if (health <= 0)
        {
            health = maxHealth;
            transform.position = new Vector3(-94, 30, 0);

        }

    }




    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);

    }


    public void TakeDamage(float damage)
    {

        health -= damage;
        Debug.Log("Player takes damage!!!");

    }

}
