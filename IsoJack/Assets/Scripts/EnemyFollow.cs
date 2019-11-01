using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{

    
 

    public float moveSpeed;
    public float stopDistance;
    public bool IsWalking=false;
    private Transform target;
    public CharTalk talk;

   


    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
     
        if (Vector2.Distance(transform.position, target.position) < 5&&Vector2.Distance(transform.position,target.position)>1)
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        if (Vector2.Distance(transform.position, target.position) < 5 && Vector2.Distance(transform.position, target.position) > 1)
            IsWalking = true;
    }
       
}
