using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCycle : MonoBehaviour
{
    // Start is called before the first frame update

    public float timer = 720;
    public float INTIMERDONTCHANGE;
    public GameObject SleepImg;
    private bool teleported;
    public GameObject sleepQuestion;
    public GameObject[] trees;

    void Start()
    {
        INTIMERDONTCHANGE = timer;
        trees = GameObject.FindGameObjectsWithTag("interObject");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(INTIMERDONTCHANGE.ToString());
        if(INTIMERDONTCHANGE>=480&&INTIMERDONTCHANGE<=720)
        {

            GameManager.instance.timeIndicator.sprite = GameManager.instance.timeOfDay[0];
        }
        else if(INTIMERDONTCHANGE>=360&&INTIMERDONTCHANGE<=480)
        {

            GameManager.instance.timeIndicator.sprite = GameManager.instance.timeOfDay[1];
        }
        else
        {
            //GameManager.instance.timeIndicator.sprite = GameManager.instance.timeOfDay[3];
            //GameManager.instance.timeOfDay.Length is equal to 2, meaning timeOfDay[3] is out of range. Fix that first.
        }

        if (INTIMERDONTCHANGE>=0)
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
            sleepQuestion.SetActive(true);
        }
    }

    public void goToSleep()
    {
        StartCoroutine(Sleep());
    }

    IEnumerator Sleep()
    {

        if (SleepImg == null)
        {

        }
        SleepImg.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        foreach(GameObject utree in trees)
        {
            if(!utree.activeInHierarchy)
            {
                utree.SetActive(true);
            }
        }
        GameManager.instance.updateDays();
        INTIMERDONTCHANGE = timer;
        SleepImg.SetActive(false);
    }
}
