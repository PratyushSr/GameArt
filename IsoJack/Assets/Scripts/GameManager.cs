using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;
    public GameObject Player;
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

    public Text hpText;
    public GameObject[] hpBarArray;
    public Sprite[] hpIndicatorSprites;
    public GameObject HPFullText;
    public AudioSource pokerChips;

    private GameObject finalBoss;

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
        hpText.text = hp.ToString();

        //GameObject.Find("HUDCanvas").transform.Find("Inventory").gameObject.GetComponent<Inventory>().AddItem(2, 1);
        //GameObject.Find("HUDCanvas").transform.Find("Inventory").gameObject.GetComponent<Inventory>().AddItem(3, 1);


        GuardTowers = GameObject.Find("IsoJack_Overworld/Buildings/AllGuardTowers");
        Barricades = GameObject.Find("IsoJack_Overworld/Buildings/Wall_Barricade");
        GuardTowers.SetActive(false);
        Barricades.SetActive(false);
        GuardTowerUpgrade = 0;
        BarricadesUpgrade = 0;

        DogToyOut = false;
        finalBoss = GameObject.Find("IsoJack_Overworld/NPCs/FinalBoss");


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

        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            if (hp < 100 && GameObject.Find("HUDCanvas").transform.Find("Inventory").gameObject.GetComponent<Inventory>().GetSlotCount(2) > 0) //+50 HP
            {
                GameObject.Find("HUDCanvas").transform.Find("Inventory").gameObject.GetComponent<Inventory>().RemoveItem(2, 1);
                updateHP(50);
            }
            else
                StartCoroutine(triggerHPText());
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))//+20 HP
        {
            if (hp < 100 && GameObject.Find("HUDCanvas").transform.Find("Inventory").gameObject.GetComponent<Inventory>().GetSlotCount(3) > 0) //+50 HP
            {
                GameObject.Find("HUDCanvas").transform.Find("Inventory").gameObject.GetComponent<Inventory>().RemoveItem(3, 1);
                updateHP(20);
            }
            else
                StartCoroutine(triggerHPText());

        }

        IEnumerator triggerHPText()
        {
            
            HPFullText.SetActive(true);
            yield return new WaitForSeconds(2f);
            HPFullText.SetActive(false);
        }

        //TEMP INV TESTING CODE

        /*if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("ADDED AXE");
            GameObject.Find("HUDCanvas").transform.Find("Inventory").gameObject.GetComponent<Inventory>().AddItem(1, 1);
            Debug.Log("Item =" + GameObject.Find("HUDCanvas").transform.Find("Inventory").gameObject.GetComponent<Inventory>().GetSlotCount(1));
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("ADDED FOODFOOD");
            GameObject.Find("HUDCanvas").transform.Find("Inventory").gameObject.GetComponent<Inventory>().AddItem(2, 1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("ADDED BEER");
            GameObject.Find("HUDCanvas").transform.Find("Inventory").gameObject.GetComponent<Inventory>().AddItem(3, 1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Debug.Log("ADDED RAW MEET");
            GameObject.Find("HUDCanvas").transform.Find("Inventory").gameObject.GetComponent<Inventory>().AddItem(4, 1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Debug.Log("ADDED BONES");
            GameObject.Find("HUDCanvas").transform.Find("Inventory").gameObject.GetComponent<Inventory>().AddItem(5, 1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            Debug.Log("ADDED QUEST ITEM");
            GameObject.Find("HUDCanvas").transform.Find("Inventory").gameObject.GetComponent<Inventory>().AddItem(6, 1);
        }
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
            Debug.Log("REMOVED BEER");
            GameObject.Find("HUDCanvas").transform.Find("Inventory").gameObject.GetComponent<Inventory>().RemoveItem(3, 1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Debug.Log("REMOVED RAW MEET");
            GameObject.Find("HUDCanvas").transform.Find("Inventory").gameObject.GetComponent<Inventory>().RemoveItem(4, 1);
        }
        if (Input.GetKeyDown(KeyCode.Minus))
        {
            Debug.Log("REMOVED BONES");
            GameObject.Find("HUDCanvas").transform.Find("Inventory").gameObject.GetComponent<Inventory>().RemoveItem(5, 1);
        }*/
        if (Input.GetKeyDown(KeyCode.Equals))
        {
            Debug.Log("REMOVED QUEST ITEM");
            GameObject.Find("HUDCanvas").transform.Find("Inventory").gameObject.GetComponent<Inventory>().RemoveItem(6, 1);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            pokerChips.Play();
            if (GameObject.Find("HUDCanvas").transform.Find("Inventory").gameObject.GetComponent<Inventory>().GetSlotCount(6) >= 1)
            {
                DogToyOut = !DogToyOut;
                Debug.Log("Toggled Dog Toy");
                pokerChips.Play();
            }
        }


        if(days <= 0)
        {
            Debug.Log("Baby your time is up, trigger endcutscene here");
            finalBoss.SetActive(true);
            StartCoroutine(TeleportFinalBoss());
        }

    }

    IEnumerator TeleportFinalBoss()
    {
        
        Player.transform.position = new Vector2((float)26.07, (float)5.06);
        yield return new WaitForSeconds(0.5f);
        GameManager.instance.locationPopIn("Outskirts");
        yield return new WaitForSeconds(1f);


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

   
    public void locationPopIn(string location)
    {
        locationTxt.text = location;
        //locationAni.SetTrigger("Active");
        locationAni.Play("locationPopIn", -1, 0f);
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



    private void depleateBar(int amount)
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
        for (int i = 0; i < 10; i++)
        {
            if (i == 0)
            {
                hpBarArray[0].SetActive(true);
                if (amount < 10)
                    hpBarArray[0].GetComponent<Image>().sprite = hpIndicatorSprites[1];
                else
                    hpBarArray[0].GetComponent<Image>().sprite = hpIndicatorSprites[0];
            }
            else
                if ((i * 10) < amount)
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
        locationPopIn("Jack's House");
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
