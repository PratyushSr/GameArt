using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationTriggers : MonoBehaviour
{

    bool onTrigger;
    bool playedAnimation = false;
    public string popOn;
    public string dontPopOn;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (onTrigger && !playedAnimation)
        {
            string currentLoc = GameManager.instance.locationTxt.text;
            if (currentLoc == popOn)
            {
                //GameManager.instance.locationTxt.text = dontPopOn;
                GameManager.instance.locationPopIn(dontPopOn);
            }
            else if (currentLoc == dontPopOn)
            {
                //GameManager.instance.locationTxt.text = popOn;
                GameManager.instance.locationPopIn(popOn);
            }
            playedAnimation = true;
            Debug.Log(GameManager.instance.locationTxt.text);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            onTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            onTrigger = false;
            playedAnimation = false;
        }
    }
}
