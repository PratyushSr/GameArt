using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;
    public int wood ;
    public int coin;
    public int days;
    public int hp;
    public int bones;
    public int food;
    public int meat;
    public Text woodCount;
    public Text coinCount;
    public Text foodCount;
    public Text boneCount;
    public Text meatCount;
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
    public GameObject GuardTowers;
    public GameObject Barricades;
    public int GuardTowerUpgrade;
    public int BarricadesUpgrade;
    public bool DogToyOut;


    void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
        //DontDestroyOnLoad(gameObject);

        woodCount.text = wood.ToString();
        coinCount.text = coin.ToString();
        //boneCount.text = bones.ToString();
        //meatCount.text = meat.ToString();
        //foodCount.text = food.ToString();
        daysRemain.text = days.ToString() + " Days Remain";
        timeIndicator.sprite = timeOfDay[0];
        isDay = true;
        hp = 100;

        GuardTowers = GameObject.Find("IsoJack_Overworld/Buildings/AllGuardTowers");
        Barricades = GameObject.Find("IsoJack_Overworld/Buildings/Wall_Barricade");
        GuardTowers.SetActive(false);
        Barricades.SetActive(false);
        GuardTowerUpgrade = 0;
        BarricadesUpgrade = 0;

        DogToyOut = false;


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

        //TEMP INV TESTING CODE
        /*
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("ADDED AXE");
            GameObject.Find("HUDCanvas").transform.Find("Inventory").gameObject.GetComponent<Inventory>().AddItem(1, 1);
        }
        */if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("ADDED FOOD");
            GameObject.Find("HUDCanvas").transform.Find("Inventory").gameObject.GetComponent<Inventory>().AddItem(2, 1);
        }/*
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("ADDED RAW MEET");
            GameObject.Find("HUDCanvas").transform.Find("Inventory").gameObject.GetComponent<Inventory>().AddItem(3, 1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Debug.Log("ADDED BONES");
            GameObject.Find("HUDCanvas").transform.Find("Inventory").gameObject.GetComponent<Inventory>().AddItem(4, 1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Debug.Log("ADDED QUEST ITEM");
            GameObject.Find("HUDCanvas").transform.Find("Inventory").gameObject.GetComponent<Inventory>().AddItem(5, 1);
        }*/
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("ADDED BEER");
            GameObject.Find("HUDCanvas").transform.Find("Inventory").gameObject.GetComponent<Inventory>().AddItem(3, 1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Debug.Log("ADDED POUCH");
            GameObject.Find("HUDCanvas").transform.Find("Inventory").gameObject.GetComponent<Inventory>().AddItem(6, 1);
        }/*
        //TEMP INV TESTING CODE
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            Debug.Log("REMOVED AXE");
            GameObject.Find("HUDCanvas").transform.Find("Inventory").gameObject.GetComponent<Inventory>().RemoveItem(1, 1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            Debug.Log("REMOVED FOOD");
            GameObject.Find("HUDCanvas").transform.Find("Inventory").gameObject.GetComponent<Inventory>().RemoveItem(2, 1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            Debug.Log("REMOVED RAW MEET");
            GameObject.Find("HUDCanvas").transform.Find("Inventory").gameObject.GetComponent<Inventory>().RemoveItem(3, 1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Debug.Log("REMOVED BONES");
            GameObject.Find("HUDCanvas").transform.Find("Inventory").gameObject.GetComponent<Inventory>().RemoveItem(4, 1);
        }
        if (Input.GetKeyDown(KeyCode.Minus))
        {
            Debug.Log("REMOVED QUEST ITEM");
            GameObject.Find("HUDCanvas").transform.Find("Inventory").gameObject.GetComponent<Inventory>().RemoveItem(5, 1);
        }*/
        if (Input.GetKeyDown(KeyCode.Equals))
        {
            Debug.Log("REMOVED BEER");
            GameObject.Find("HUDCanvas").transform.Find("Inventory").gameObject.GetComponent<Inventory>().RemoveItem(6, 1);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            if (GameObject.Find("HUDCanvas").transform.Find("Inventory").gameObject.GetComponent<Inventory>().GetSlotCount(6) >= 1)
            {
                DogToyOut = !DogToyOut;
                Debug.Log("Toggled Dog Toy");
            }
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
