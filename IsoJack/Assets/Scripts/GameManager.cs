using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;
    public int wood;
    public int coin;
    public int days;
    public int hp;
    public Text woodCount;
    public Text coinCount;
    public Text daysRemain;
    public Text locationTxt;
    public Text hpText;
    public GameObject pauseMenuUI;
    public Animator locationAni;
    public Animator adventureLogAni;
    public Sprite[] timeOfDay;
    public Image timeIndicator;
    public bool isDay;
    public bool inConversation;
    public static bool isPaused = false;

    public GameObject[] hpBarArray;
    public Sprite[] hpIndicatorSprites;


    void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        woodCount.text = wood.ToString();
        coinCount.text = coin.ToString();
        daysRemain.text = days.ToString() + " Days Remain";
        timeIndicator.sprite = timeOfDay[0];
        isDay = true;
        hp = 100;
        hpText.text = hp.ToString();
        locationTxt.text = "Iso Village";


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }

        if (Input.GetKeyDown(KeyCode.L))
            locationPopIn();
        if (Input.GetKeyDown(KeyCode.C))
            changeIndicator();
        if(inConversation == true)
        {
            Time.timeScale = 0f;
            isPaused = true;
        }
        else
        {
            Time.timeScale = 1f;
            isPaused = false;
        }

    }

    public void updateCount(Text txt, ref int counter,  int amount)
    {
        counter += amount;
        Debug.Log("Amount is now " + counter.ToString());
        txt.text = counter.ToString();
    }

    public void updateDays()
    {
        days--;
        daysRemain.text = days.ToString() + " Days Remain";
    }

    public void locationPopIn()
    {
        locationAni.SetTrigger("Active");
    }

    public void locationPopIn(string location)
    {
        locationTxt.text = location;
        locationAni.SetTrigger("Active");
    }


    public void adventureLogPopIn()
    {
        adventureLogAni.SetBool("isOpen", true);
        adventureLogAni.StopPlayback();
        //adventureLogAni.SetTrigger("Active");
    }


    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void LoadSettings()
    {
        //Time.timeScale = 1f;
        SceneManager.LoadScene("Settings");
    }

    public void LoadMap()
    {
        //Time.timeScale = 1f;
        SceneManager.LoadScene("Map");
    }

    public void changeIndicator() // 0 is day and 1 is night
    {
        if(isDay)
        {
            timeIndicator.sprite = timeOfDay[1];
            isDay = false;
        }
        else
        {
            timeIndicator.sprite = timeOfDay[0];
            isDay = true;
        }
    }

    public void updateHP(int amount) //If the player is taking damage, amount should be negative!!
    {
        hp += amount;
        if (hp <= 0)
            hp = 0;
        else if (hp >= 100)
            hp = 100;
        hpText.text = hp.ToString();
        if (amount < 0)
            depleateBar(hp);
        else if (amount > 0)
            incrementeBar(hp);
    }



    private void depleateBar( int amount)
    {
        int i = 100;
        while (i >= amount)
        {
            if (amount < 10)
            {
                if (amount < 5)
                    hpBarArray[0].SetActive(false);
                else
                    hpBarArray[0].GetComponent<Image>().sprite = hpIndicatorSprites[1];
            }
            if (amount < 20)
                decrementeImage(1, amount, 15);
            if (amount < 30)
                decrementeImage(2, amount, 25);
            if (amount < 40)
                decrementeImage(3, amount, 35);
            if (amount < 50)
                decrementeImage(4, amount, 45);
            if (amount < 60)
                decrementeImage(5, amount, 55);
            if (amount < 70)
                decrementeImage(6, amount, 65);
            if (amount < 80)
                decrementeImage(7, amount, 75);
            if (amount < 90)
                decrementeImage(8, amount, 85);
            if (amount < 100)
                decrementeImage(9, amount, 95);
            i -= 10;
        }
       
    }

    private void incrementeBar(int amount)
    {
        for(int i = 0; i < 10; i++)
        {
            if(i == 0)
            {
                hpBarArray[0].SetActive(true);
                if (amount < 10)
                    hpBarArray[0].GetComponent<Image>().sprite = hpIndicatorSprites[1];
                else
                    hpBarArray[0].GetComponent<Image>().sprite = hpIndicatorSprites[0];
            }
            else
                if((i*10) < amount)
                    incrementeImage(i, amount, ((i * 10) + 10));
        }
    }


    private void decrementeImage(int index, int amount, int condi)
    {
        
        GameObject left = hpBarArray[index].transform.GetChild(0).gameObject;
        GameObject right = hpBarArray[index].transform.GetChild(1).gameObject;

        left.GetComponent<Image>().sprite = hpIndicatorSprites[2];
        right.GetComponent<Image>().sprite = hpIndicatorSprites[2];

        if (amount < condi)
            hpBarArray[index].SetActive(false);
        else
        {
            left.GetComponent<Image>().sprite = hpIndicatorSprites[1];
            right.GetComponent<Image>().sprite = hpIndicatorSprites[1];
        }
    }


    private void incrementeImage(int index, int amount, int condi)
    {
        hpBarArray[index].SetActive(true);
        GameObject left = hpBarArray[index].transform.GetChild(0).gameObject;
        GameObject right = hpBarArray[index].transform.GetChild(1).gameObject;
        left.GetComponent<Image>().sprite = hpIndicatorSprites[0];
        right.GetComponent<Image>().sprite = hpIndicatorSprites[0];
        if (amount < condi)
        {
            left.GetComponent<Image>().sprite = hpIndicatorSprites[1];
            right.GetComponent<Image>().sprite = hpIndicatorSprites[1];
        }

    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        locationPopIn();
    }
}
