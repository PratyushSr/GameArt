using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpIndicator : MonoBehaviour
{
    public Image[] hpBar;
    public Text hpText;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < hpBar.Length; i++)
        {
            hpBar[i].enabled = true;
        }

    }

    public void augmentHealth(int amount)
    {
        GameManager.instance.hp += amount;
        hpText.text = GameManager.instance.hp.ToString();
        //GameManager.instance.hp -= 10;
        int numofBlocks = 0;

        for(int i = 0; i < hpBar.Length; i++)
        {
            if((hpBar[i].enabled == false && amount < 0) || hpBar[i].enabled == true && amount > 0)
                numofBlocks++;
            else
            {
                if(amount < 0)
                {
                    hpBar[i].enabled = false;
                    hpBar[(hpBar.Length - numofBlocks) - 1].enabled = false;
                }
                if (amount > 0)
                {
                    hpBar[i].enabled = true;
                    hpBar[(hpBar.Length - numofBlocks) - 1].enabled = true;
                }
                break;

            }
        }
        if (GameManager.instance.hp == 0)
            Debug.Log("No more HP! Game Over.");

    }


}
