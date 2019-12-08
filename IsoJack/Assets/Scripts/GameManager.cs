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
    public static bool isPaused = false;
    public GameObject pauseMenuUI;
    public Animator locationAni;
    public Animator adventureLogAni;
    public Sprite[] timeOfDay;
    public Image timeIndicator;
    public bool isDay;
    public bool inConversation;


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
        locationTxt.text = "Iso Village"; 
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

    public void LoadMain()
    {
        Debug.Log("Loading Main Menu...");
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadGame()
    {
        Debug.Log("Loading Game...");
        Time.timeScale = 1f;
        SceneManager.LoadScene("IsoJack_OverWorld");
    }
}
