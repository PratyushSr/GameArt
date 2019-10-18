using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharTalk : MonoBehaviour
{
    public GameObject DialogueBox;
    public Text diotext;
    public string dialogue;
    public bool dialogueActive;
    public bool talked;
    public string dialogue2;
    public int cost;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(talked);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)&&dialogueActive&&GameManager.instance.coin>=cost)
        {
            if (DialogueBox.activeInHierarchy)
            {
                DialogueBox.SetActive(false);
            }
            else
            {
                DialogueBox.SetActive(true);
                if (cost != 0)
                {
                    GameManager.instance.updateCount(GameManager.instance.coinCount, ref GameManager.instance.coin, (cost * -1));
                    GameManager.instance.updateDays();
                }
                diotext.text = dialogue;
            }
        }
        else if(Input.GetKeyDown(KeyCode.Space)&&dialogueActive&&GameManager.instance.coin<cost&&dialogue2!="")
        {
            if (DialogueBox.activeInHierarchy)
            {
                DialogueBox.SetActive(false);
            }
            else
            {
                DialogueBox.SetActive(true);
                diotext.text = dialogue2;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            dialogueActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            dialogueActive = false;
        }
    }
}

