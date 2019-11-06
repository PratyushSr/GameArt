using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float attackCd = 0;
    public float attackTimer;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public float damage;

    public float health;


    void Update()
    {

        if (attackCd <= 0)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("f is pressed");
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().EnemyTakeDamage(damage);
                  


                }
                   
            }
            attackCd = attackTimer;

        }

        else
        {
            attackCd -= Time.deltaTime;
        }

        if (health <= 0)
        {
            Destroy(gameObject);

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
