using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCycle : MonoBehaviour
{
    // Start is called before the first frame update

    public float timer = 720;
    public float INTIMERDONTCHANGE;
    void Start()
    {
        INTIMERDONTCHANGE = timer;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(INTIMERDONTCHANGE.ToString());
        if(INTIMERDONTCHANGE>=480&&INTIMERDONTCHANGE<=720)
        {
            //icon.SetActive(true);
            //duskcon.SetActive(false);
            //nightcon.SetActive(false);
            GameManager.instance.timeIndicator.sprite = GameManager.instance.timeOfDay[0];
        }
        else if(INTIMERDONTCHANGE>=360&&INTIMERDONTCHANGE<=480)
        {
            //icon.SetActive(false);
            //duskcon.SetActive(true);
            //nightcon.SetActive(false);
            GameManager.instance.timeIndicator.sprite = GameManager.instance.timeOfDay[1];
        }
        else
        {
            //icon.SetActive(false);
            //duskcon.SetActive(false);
            //nightcon.SetActive(true);
            GameManager.instance.timeIndicator.sprite = GameManager.instance.timeOfDay[3];
        }

        if(INTIMERDONTCHANGE>=0)
        {
            INTIMERDONTCHANGE -= Time.deltaTime;
        }
        else
        {
            INTIMERDONTCHANGE = timer;
            GameManager.instance.updateDays();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            GameManager.instance.updateDays();
            INTIMERDONTCHANGE = timer;
        }
    }
}
