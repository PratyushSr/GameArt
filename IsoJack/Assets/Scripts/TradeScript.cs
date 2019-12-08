using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradeScript : MonoBehaviour
{
    public char itemgive; //Character handler for what item you will give
    public char itemget; //Character handler for what item you will get
    public float wantgive; //HOW MUCH you need to give
    public float wantget;  //HOW MUCH you will get from the transaction

    /*This is the handler for giving/getting items. The character handling will allow for the dev/designer to put in what items will need to be traded, and what can be given
     * They are as follows
     * w -> Wood
     * m  -> Meat
     * c -> Coins
     * b -> bones
     * f -> food
     * 
     * Enter these in the want and not want items in order to determine what would be traded*/

    //Wantgive and wantget are the items.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (itemgive == 'c' && GameManager.instance.coin > itemgive)
        {
            GameManager.instance.updateCount(GameManager.instance.coinCount, ref GameManager.instance.coin, (itemgive*(-1)));
            TradeIt();
        }else if(itemgive=='w'&&GameManager.instance.wood>itemgive)
        {
            GameManager.instance.updateCount(GameManager.instance.woodCount, ref GameManager.instance.wood, (itemgive * (-1)));
            TradeIt();
        }
        else if(itemgive=='m'&&GameManager.instance.meat>itemgive)
        {
            GameManager.instance.updateCount(GameManager.instance.meatCount, ref GameManager.instance.meat, (itemgive * (-1)));
            TradeIt();
        }
        else if(itemgive=='b'&&GameManager.instance.bones>itemgive)
        {
            GameManager.instance.updateCount(GameManager.instance.boneCount, ref GameManager.instance.bones, (itemgive * (-1)));
            TradeIt();
        }
        else if(itemgive=='f'&&GameManager.instance.food>itemgive)
        {
            GameManager.instance.updateCount(GameManager.instance.foodCount, ref GameManager.instance.food, (itemgive * (-1)));
            TradeIt();
        }
        else
        {
            //Nothing to see here, move along.
        }
    }

    void TradeIt()
    {
        if (itemgive == 'c')
        {
            GameManager.instance.updateCount(GameManager.instance.coinCount, ref GameManager.instance.coin, itemget);
        }
        else if (itemgive == 'w')
        {
            GameManager.instance.updateCount(GameManager.instance.woodCount, ref GameManager.instance.wood, itemget);
        }
        else if (itemgive == 'm')
        {
            GameManager.instance.updateCount(GameManager.instance.meatCount, ref GameManager.instance.meat, itemget);
        }
        else if (itemgive == 'b')
        {
            GameManager.instance.updateCount(GameManager.instance.boneCount, ref GameManager.instance.bones, itemget);
        }
        else if (itemgive == 'f')
        {
            GameManager.instance.updateCount(GameManager.instance.foodCount, ref GameManager.instance.food, itemget);
        }
        else
        {
            //Nothing to see here, move along.
        }
    }
}
