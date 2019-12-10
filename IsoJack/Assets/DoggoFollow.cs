using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoggoFollow : MonoBehaviour
{
    [Tooltip("You better put the doggos owner here! Doggo Demands it!")]
    public GameObject GiveMeMyOwner;

    private bool dogToy____OHBOYOHBOYOHBOY;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<EnemyFollow>().enabled = false;
        dogToy____OHBOYOHBOYOHBOY = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (dogToy____OHBOYOHBOYOHBOY && !GameManager.instance.DogToyOut)
        {
            dogToy____OHBOYOHBOYOHBOY = false;
            GetComponent<EnemyFollow>().enabled = false;
        }else if (!dogToy____OHBOYOHBOYOHBOY && GameManager.instance.DogToyOut)
        {
            dogToy____OHBOYOHBOYOHBOY = true;
            GetComponent<EnemyFollow>().enabled = true;
        }

        if (dogToy____OHBOYOHBOYOHBOY && Vector2.Distance(transform.position, GiveMeMyOwner.transform.position) < 2)
        {
            GetComponent<EnemyFollow>().target = GiveMeMyOwner.transform;
            if (Adventureog.advLogInstance.Quest[6].subQuest < 4)
            {
                Adventureog.advLogInstance.addProgress(7, 1);
            }
        }
    }
}
