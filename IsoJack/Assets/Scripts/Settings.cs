using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    public AudioMixer audioMixer;
    //public float brightness = 0.5f;
    public Light brightness;

    public void SetMainVol(Slider slider)
    {
        Debug.Log("Master volume set to: " + slider.value);
        audioMixer.SetFloat("MasterVolume", slider.value);
    }

    public void SetMusicVol(Slider slider)
    {
        Debug.Log("Music volume set to: " + slider.value);
        audioMixer.SetFloat("MusicVolume", slider.value);
    }

    public void SetSFXVol(Slider slider)
    {
        Debug.Log("SFX volume set to: " + slider.value);
        audioMixer.SetFloat("SFXVolume", slider.value);
    }

    public void SetBrightness(Slider slider)
    {
        Debug.Log("Brightness set to: " + slider.value);
        //RenderSettings.ambientLight = new Color(slider.value, slider.value, slider.value, 1);
        brightness.intensity = slider.value;
    }
}
