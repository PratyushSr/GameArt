using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{
    public bool inventory;//wheter or not the object can be put in inventory
    public char collect; //for resources
    private int lotto;
    private int scoins;

    public void DoInteraction()
    {
        lotto = Random.Range(0, 2);
        scoins = Random.Range(0, 10);
        gameObject.SetActive(false);
        if(collect=='w')
        {
            GameManager.instance.updateCount(GameManager.instance.woodCount, ref GameManager.instance.wood, 20);
        }
        else if(collect=='c')
        {
            GameManager.instance.updateCount(GameManager.instance.coinCount, ref GameManager.instance.coin, 10);
        }
        else { }

        if(lotto==1)
        {
            Debug.Log("Lottery won! You get " + scoins + " coins!");
            GameManager.instance.updateCount(GameManager.instance.coinCount, ref GameManager.instance.coin, scoins);
        }
    }

}
