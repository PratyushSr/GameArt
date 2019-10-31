using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTests : MonoBehaviour
{
    public Button oneWood;
    public Button tenWood;
    public Button hundredWood;

    public Button oneCoin;
    public Button tenCoin;
    public Button hundredCoin;

    public Button subtractDays;

    public Button locationPopin;

    // Start is called before the first frame update
    void Start()
    { 
        oneWood.onClick.AddListener(() => GameManager.instance.updateCount(GameManager.instance.woodCount, ref GameManager.instance.wood, 1));
        tenWood.onClick.AddListener(() => GameManager.instance.updateCount(GameManager.instance.woodCount, ref GameManager.instance.wood, 10));
        hundredWood.onClick.AddListener(() => GameManager.instance.updateCount(GameManager.instance.woodCount, ref GameManager.instance.wood, 100));

        oneCoin.onClick.AddListener(() => GameManager.instance.updateCount(GameManager.instance.coinCount, ref GameManager.instance.coin, 1));
        tenCoin.onClick.AddListener(() => GameManager.instance.updateCount(GameManager.instance.coinCount, ref GameManager.instance.coin, 10));
        hundredCoin.onClick.AddListener(() => GameManager.instance.updateCount(GameManager.instance.coinCount, ref GameManager.instance.coin, 100));

        subtractDays.onClick.AddListener(() => GameManager.instance.updateDays());
        //locationPopin.onClick.AddListener(() => GameManager.instance.locationPopIn());


    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
