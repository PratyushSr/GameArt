using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class TitleScreen : MonoBehaviour
{
    public void LoadGame()
    {
        Debug.Log("Loading Game...");
        Time.timeScale = 1f;
        SceneManager.LoadScene("IsoJack_OverWorld");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}
