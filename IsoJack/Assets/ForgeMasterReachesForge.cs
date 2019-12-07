using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ForgeMasterReachesForge : MonoBehaviour
{
    private GameObject forgeBuilding;
    private bool reached;
    
    // Start is called before the first frame update
    void Start()
    {
        forgeBuilding = GameObject.Find("IsoJack_Overworld/Buildings/Forge");
        reached = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!reached && Vector2.Distance(transform.position, forgeBuilding.transform.position) < 5)
        {
            reached = true;
            GetComponent<EnemyFollow>().enabled = false;
            transform.position = new Vector3(-21.7f, 8.7f, 0);
        }
    }
}
