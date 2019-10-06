using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public int wood;
    public int coin;
    public int days;
    public Text woodCount;
    public Text coinCount;
    public Text daysRemain;

    public static bool isPaused = false;
    public GameObject pauseMenuUI;

    public Animator locationAni;
    public Text locationTxt;

    public Animator adventureLogAni;



    void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        woodCount.text = wood.ToString();
        coinCount.text = coin.ToString();
        daysRemain.text = days.ToString() + " Days Remain";

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
        locationTxt.text = "Arrived in Location"; 
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

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }

}
