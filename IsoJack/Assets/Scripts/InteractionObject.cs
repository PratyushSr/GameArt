using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{
    public bool inventory;//wheter or not the object can be put in inventory

    public void DoInteraction()
    {
        gameObject.SetActive(false);
    }

}
