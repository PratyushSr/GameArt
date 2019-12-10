using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    public AudioSource Click;
    public AudioSource BearGrowl;
    public AudioSource Boar;
    public AudioSource PigOink;
    public AudioSource SpinSound;
    public AudioSource WolfGrowl;
    public AudioSource WolfHowl;
    public AudioSource WoodCut;

    public void PlayClick()
    {
        Click.Play();
    }

    public void PlayBear()
    {
        BearGrowl.Play();
    }

    public void PlayBoar()
    {
        Boar.Play();
    }

    public void PlayPig()
    {
        PigOink.Play();
    }

    public void PlaySpin()
    {
        SpinSound.Play();
    }

    public void PlayWolfGrowl()
    {
        WolfGrowl.Play();
    }

    public void PlayWolfHowl()
    {
        WolfHowl.Play();
    }

    public void PlayWoodCut()
    {
        WoodCut.Play();
    }

}
