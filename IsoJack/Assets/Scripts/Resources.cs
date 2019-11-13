using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Resources : MonoBehaviour
{
    public enum  Supplies{Wood, Coin }//supply type
    //public enum Input { Detect2D}
    public static int coins;
    public static int wood;

    public Camera endtarget;

    [Header("UI Reference")]
    public Transform target;

    [Space(5)]
    public RectTransform WoodImage;
    public TextMeshProUGUI WoodCount;

    [Space(5)]
    public RectTransform CoinImage;
    public TextMeshProUGUI CoinCount;

    private void Update()
    {
        detectInput();
    }

    public void detectInput()
    {
        if(InputDetected())
        {
            
        }
    }

    private bool InputDetected()
    {
        return Input.GetButtonDown("interact");
    }

    private void CollectResource(TradingSystem resources)
    {
        switch(resources.resourceType)
        {
            case Supplies.Coin:
                break;
            case Supplies.Wood:
                break;
        }
    }

    private void Pickup(TradingSystem resources, GameObject animatedPrefab, GameObject EndPrefab, RectTransform resourveIcon)
    {

    }

    

         
}
