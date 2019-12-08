using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ForgeMasterReachesForge : MonoBehaviour
{
    private GameObject forgeBuilding;
    private bool reached;
    private bool questActive;
    
    // Start is called before the first frame update
    void Start()
    {
        forgeBuilding = GameObject.Find("IsoJack_Overworld/Buildings/Forge");
        reached = false;
        questActive = false;
        transform.position += transform.right * 1000;
    }

    // Update is called once per frame
    void Update()
    {
        if (questActive)
        {
            if (!reached && Vector2.Distance(transform.position, forgeBuilding.transform.position) < 5)
            {
                reached = true;
                GetComponent<EnemyFollow>().enabled = false;
                transform.position = new Vector3(-21.7f, 8.7f, 0);
                while(Adventureog.advLogInstance.Quest[3].subQuest < 3)
                {
                    Adventureog.advLogInstance.addProgress(4, 1);
                }
            }
        }
        else
        {
            if (Adventureog.advLogInstance.Quest[3].subQuest == 1)
            {
                questActive = true;
                transform.position += transform.right * -1000;
            }
        }
    }
}
