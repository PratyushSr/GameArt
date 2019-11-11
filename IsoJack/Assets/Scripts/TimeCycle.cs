using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCycle : MonoBehaviour
{
    // Start is called before the first frame update

    public float timer;
    public GameObject icon;
    public float INTIMERDONTCHANGE;
    void Start()
    {
        INTIMERDONTCHANGE = timer;
    }

    // Update is called once per frame
    void Update()
    {
        if(INTIMERDONTCHANGE<=timer/2)
        {
            icon.SetActive(false);
        }
        else
        {
            icon.SetActive(true);
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
