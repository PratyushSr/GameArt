using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharTalk : MonoBehaviour
{
    private GameObject DialogueBox;
    private GameObject diotext;
    private GameObject npcLabel;
    private GameObject npcPortrait;

    public string npcName;
    public string dialogue;
    public Sprite portrait;
    private bool dialogueActive;
    private bool talked;
    public int numofChoices;
    public bool hasChoices;
    public bool hasQuest;
    private bool acceptedQuest;

    private GameObject inventoryBar;
    private GameObject hp;
    private GameObject dialougeView;

    private bool deniedQuest;
    private bool checkforQuest = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(talked);
        DialogueBox = GameObject.Find("ConversationView/DialougeBoxImage");
        diotext = GameObject.Find("ConversationView/DialogueText");
        npcLabel = GameObject.Find("ConversationView/NPCNameTag");
        npcPortrait = GameObject.Find("ConverstationView/npcPortrait");
        inventoryBar = GameObject.Find("HUDCanvas/Inventory");
        hp = GameObject.Find("HUDCanvas/HPIndicator");
        dialougeView = GameObject.Find("HUDCanvas/ConversationView");


    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)&&dialogueActive)
        {
            if (dialougeView.activeInHierarchy)
            {
                
                if (deniedQuest == true)
                {
                    deniedQuest = false;
                    exitDialougeView();
                }

                if (hasChoices == true)
                {
                    DialougeView.converstationInstance.showDialougeChoices();
                    DialougeView.converstationInstance.numOfChoices(numofChoices);
                    hasChoices = !hasChoices;
                }
                else if (hasQuest == true && acceptedQuest == false)
                {
                    DialougeView.converstationInstance.questChoice();
                    checkforQuest = true;
                }
                else
                    exitDialougeView();
            }
            else
            {
                enterDialougeView();
                npcLabel.GetComponent<UnityEngine.UI.Text>().text = npcName;
                diotext.GetComponent<UnityEngine.UI.Text>().text = dialogue;
                npcPortrait.GetComponent<UnityEngine.UI.Image>().sprite = portrait;
            }
        }
        
        if(checkforQuest)
        {
            checkforQuest = false;
            int selected = DialougeView.converstationInstance.getChoicePressed();
            if (selected == 1 && hasQuest == true)
            {
                acceptedQuest = true;
                hasQuest = false;
                diotext.GetComponent<UnityEngine.UI.Text>().text = "Great you accpted the quest!";
            }
            else if (selected == 2 && hasQuest == true)
            {
                diotext.GetComponent<UnityEngine.UI.Text>().text = "Oh. OK then.";
                deniedQuest = true;
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


    public void enterDialougeView()
    {
        GameManager.instance.inConversation = true;
        if (DialougeView.converstationInstance.choices.activeSelf)
            DialougeView.converstationInstance.moveBack();
        dialougeView.SetActive(true);
        inventoryBar.SetActive(false);
        hp.SetActive(false);
    }

    public void exitDialougeView()
    {
        GameManager.instance.inConversation = false;
        dialougeView.SetActive(false);
        inventoryBar.SetActive(true);
        hp.SetActive(true);
    }
}

