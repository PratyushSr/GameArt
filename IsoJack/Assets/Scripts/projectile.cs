using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class projectile : MonoBehaviour
{

    public float damage;
    public float speed;
    public float lifetime;
    public float distance;
    public LayerMask whatIsSolid;
    private Transform target;

    private Vector3 normalizeDirection;

    void Start()
    {
        Invoke("DestroyProjectile", lifetime);
        Debug.Log("projectile created");
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            target = null;
            normalizeDirection = new Vector3(0, 0, 0);
        }
        else
        {
            target = player.GetComponent<Transform>();
            normalizeDirection = (target.position - transform.position).normalized;
        }
        //transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }


    void Update()
    {
        if (target != null)
        {
            Vector3 temp = new Vector3(target.position.x, target.position.y, target.position.z);
        }



        transform.position += normalizeDirection * speed * 10 * Time.deltaTime;

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Player"))
            {

                Debug.Log("Hit player");
                hitInfo.collider.GetComponent<PlayerAttack>().TakeDamage(damage);

            }

            DestroyProjectile();
        }


    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
        Debug.Log("destroyed");
    }
}
