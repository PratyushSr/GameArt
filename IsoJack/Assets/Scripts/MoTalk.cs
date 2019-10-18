using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoTalk : MonoBehaviour
{
    public GameObject DialogueBox;
    public Text diotext;
    public string dialogue;
    public bool dialogueActive;
    public bool complete = false;
    public bool started = false;
    public string dialogue2;
    public int cost;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && dialogueActive)
        {
            if (DialogueBox.activeInHierarchy)
            {
                DialogueBox.SetActive(false);
            }
            else
            {
                if(started==false)
                {
                    DialogueBox.SetActive(true);
                    diotext.text = "Hey! I need some wood. Can you get some for me? I need 30";
                    started = true;
                }
                else if(started==true&&complete==false)
                {
                    if(GameManager.instance.wood>=30)
                    {
                        DialogueBox.SetActive(true);
                        diotext.text = "Thank you! Take some gold!";
                        GameManager.instance.updateCount(GameManager.instance.woodCount, ref GameManager.instance.wood, (-30));
                        GameManager.instance.updateCount(GameManager.instance.coinCount, ref GameManager.instance.coin, (1927));
                        complete = true;
                    }
                    else
                    {
                        DialogueBox.SetActive(true);
                        diotext.text = "Not enough! Please go get more!";
                    }
                }
                else if(complete==true)
                {
                    DialogueBox.SetActive(true);
                    diotext.text = "I don't have anything else to ask. Go check in with Professor Donatelli. See if he is still lost";
                 
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            dialogueActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            dialogueActive = false;
        }
    }
}

