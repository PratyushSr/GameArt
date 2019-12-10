using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoggoFollow : MonoBehaviour
{
    [Tooltip("You better put the doggos owner here! Doggo Demands it!")]
    public GameObject GiveMeMyOwner;

    private bool whereMaLooking;
    private bool dogToy____OHBOYOHBOYOHBOY;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<EnemyFollow>().enabled = false;
        dogToy____OHBOYOHBOYOHBOY = false;
        whereMaLooking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (dogToy____OHBOYOHBOYOHBOY && !GameManager.instance.DogToyOut)
        {
            dogToy____OHBOYOHBOYOHBOY = false;
            GetComponent<EnemyFollow>().enabled = false;
        }
        else if (!dogToy____OHBOYOHBOYOHBOY && GameManager.instance.DogToyOut)
        {
            dogToy____OHBOYOHBOYOHBOY = true;
            GetComponent<EnemyFollow>().enabled = true;
        }

        if (!GetComponent<Animator>().GetBool("IsWalking") && GetComponent<EnemyFollow>().IsWalking)
        {
            GetComponent<Animator>().SetBool("IsWalking", true);
        }
        else if (GetComponent<Animator>().GetBool("IsWalking") && !GetComponent<EnemyFollow>().IsWalking)
        {
            GetComponent<Animator>().SetBool("IsWalking", false);
        }

        if (dogToy____OHBOYOHBOYOHBOY && Vector2.Distance(transform.position, GiveMeMyOwner.transform.position) < 2)
        {
            GetComponent<EnemyFollow>().target = GiveMeMyOwner.transform;
            if (Adventureog.advLogInstance.Quest[6].subQuest < 4)
            {
                Adventureog.advLogInstance.addProgress(7, 1);
            }
        }

        if (GetComponent<EnemyFollow>().IsWalking)
        {
            if (!whereMaLooking && GetComponent<EnemyFollow>().target.position.x > transform.position.x)
            {
                whereMaLooking = true;
                GetComponent<SpriteRenderer>().flipX = true;
            }else if (whereMaLooking && GetComponent<EnemyFollow>().target.position.x < transform.position.x)
            {
                whereMaLooking = false;
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }
    }
}
