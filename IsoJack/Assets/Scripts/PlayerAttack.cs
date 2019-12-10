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
    public GameObject blackoutScreen;
    public AudioSource beyblade;

    //public float health;
    private int maxHealth;

    

    private void Start()
    {
        maxHealth = GameManager.instance.hp;
        transform.position = new Vector3(-94, 30, 0);
        

    }

    void Update()
    {

        if (attackCd <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {

                beyblade.Play();
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
        if (GameManager.instance.hp <= 0)
        {
            GameManager.instance.updateHP(maxHealth);
            //transform.position = new Vector3(-94, 30, 0);
            StartCoroutine(move());

        }

    }

    IEnumerator move()
    {
        if (blackoutScreen == null)
        {
            //donothing
        }
        blackoutScreen.SetActive(true);
        yield return new WaitForSeconds(1f);
        transform.position = new Vector3(-94, 30, 0);
        GameManager.instance.updateDays();
        yield return new WaitForSeconds(3f);
        blackoutScreen.SetActive(false);
        GameManager.instance.locationPopIn("Jack's House");
    }



    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);

    }


    public void TakeDamage(float damage)
    {
        int dam = (int)damage * -1;
        GameManager.instance.updateHP(dam);
        //health -= damage;
        Debug.Log("Player takes damage!!! HP is now " + GameManager.instance.hp.ToString());


    }

}
