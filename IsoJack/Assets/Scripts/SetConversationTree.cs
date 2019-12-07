using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


///*
public class SetConversationTree : MonoBehaviour
{
    [Tooltip("Use \"Conversation View\" Gameobject")]
    public GameObject ConversationView;
    [Tooltip("0 = Normal\n" +
    "1 = 4 - way Choice\n" +
    "2 = Exit on next click\n" +
    "3 = Instantly Warp based on what quest is active.")]
    public List<int> dialogueType;
    [Tooltip("Sprite to display on left\n(Optional) Leave Null if not changed")]
    public List<Sprite> NPCSprite;
    [Tooltip("Sprite to display on the right\n(Optional) Leave Null if not changed")]
    public List<Sprite> PlayerSprite;
    [Tooltip("The name of the current character talking\n(Optional) Leave Null if not changed")]
    public List<string> NPCName;
    [Tooltip("Format: The text to display;Choice 1 Text;Choice 2 Text; Choice 3 Text; Choice 4 Text")]
    public List<string> dialogueText;
    [Tooltip("If DialogueType == 1 (Choices): Warp1;Warp2;Warp3;Warp4 (The conversation element to warp to)\n"+
    "If DialogueType == 3, it will test for a quest and sub-quest and then warp accordingly:\n"+
    "QuestID,SubQuestNumber,WarpToPoint;QuestID2,SubQuestNumber2,WarpToPoint2;...\n"+
    "QuestID and Sub Quest can be set to -1 (;-1,-1,WarpToPoint;) to signify default value")]
    public List<string> ChoiceWarps; 
    [Tooltip("Adds one progression to the given quest when the text loads.")]
    public List<int> AdvanceQuestOnTextLoad;

    private int tp; //Text Position
    private GameObject DialogueTextObject;
    private GameObject NPCPortrait;
    private GameObject PlayerPortrait;
    private GameObject NPCNameObject;
    private GameObject ChoicesCanvas;
    private GameObject Dia1;
    private GameObject Dia2;
    private GameObject Dia3;
    private GameObject Dia4;
    private GameObject AdvLog;

    private GameObject hp;
    private GameObject inventory;

    private GameObject PlayerObject;

    private bool dialogueActive;
    // Start is called before the first frame update
    void Start()
    {
        //bool ConvIsInactive = ConversationView.activeSelf;
        //if (ConvIsInactive) ConversationView.SetActive(true);
        DialogueTextObject = ConversationView.transform.Find("DialogueText").gameObject;
        NPCPortrait = ConversationView.transform.Find("npcPortrait").gameObject;
        PlayerPortrait = ConversationView.transform.Find("playerPortrait").gameObject;
        NPCNameObject = ConversationView.transform.Find("NPCNameTag").gameObject;
        ChoicesCanvas = ConversationView.transform.Find("choicesCanvas").gameObject;
        Dia1 = ConversationView.transform.Find("choicesCanvas/DialogueOptionOne").gameObject;
        Dia2 = ConversationView.transform.Find("choicesCanvas/DialogueOptionTwo").gameObject;
        Dia3 = ConversationView.transform.Find("choicesCanvas/DialogueOptionThree").gameObject;
        Dia4 = ConversationView.transform.Find("choicesCanvas/DialogueOptionFour").gameObject;
        AdvLog = GameObject.Find("AdventureLogPanel/AdventureLogBox");
        //if (ConvIsInactive) ConversationView.SetActive(false);
        hp = GameObject.Find("HUDCanvas/HPIndicator");
        inventory = GameObject.Find("HUDCanvas/Inventory");
        PlayerObject = GameObject.Find("Player_Jack");
    }

    void OnEnable()
    {
        
    }

    public void StartConversation()
    {
        Debug.Log("Started Conversation");
        GameManager.instance.inConversation = true;
        hp.SetActive(false);
        inventory.SetActive(false);
        ConversationView.SetActive(true);
        if (Adventureog.advLogInstance.isOpen == true)
            Adventureog.advLogInstance.closeLog();
        tp = 0;
        loadDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        dialogueActive = Math.Sqrt(Math.Pow(transform.position.x - PlayerObject.transform.position.x, 2) +
                Math.Pow(transform.position.y - PlayerObject.transform.position.y, 2)) <= 1;
        if (dialogueActive)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (ConversationView.activeInHierarchy == false)
                    StartConversation();
                else
                {
                    if (dialogueType[tp] == 0)
                    {
                        tp += 1;
                        loadDialogue();
                    }
                    else if ((dialogueType[tp] == 2 || tp + 1 >= dialogueText.Count))
                    {
                        Debug.Log("Ended Conversation");
                        ConversationView.SetActive(false);
                        GameManager.instance.inConversation = false;
                        hp.SetActive(true);
                        inventory.SetActive(true);
                        ChoicesCanvas.SetActive(true);
                        Dia1.SetActive(true);
                        Dia2.SetActive(true);
                        Dia3.SetActive(true);
                        Dia4.SetActive(true);


                        /*if (NPCSprite[tp + 1] != null)
                        {
                            Debug.Log("Augmenting tp!");
                            tp++;
                        }
                        else
                            Debug.Log("Did not augment tp!");
                        */                    
                        //CharTalk.charInstance.exitDialougeView();
                    }
                }
            }
            if (dialogueType[tp] == 1)
            {
                int choice = DialougeView.converstationInstance.getChoicePressed();
                if (choice != 0)
                {
                    tp = int.Parse(GetSection(ChoiceWarps[tp], choice - 1));
                    loadDialogue();
                }
            }
            if (dialogueType[tp] == 3)
            {
                Debug.Log("Attempting warp to new slot");
                //Adventureog.advLogInstance.Quest[0]
                string QuestID, SubQuest, WarpTo;
                bool questFound = false;
                List<string> Sections = new List<string>();
                for (int i = 0; i < CountSections(ChoiceWarps[tp]); i++)
                {
                    Sections.Add(GetSection(ChoiceWarps[tp], i).Replace(',', ';'));
                }

                //CHECK EXACT QUEST = QUEST, SUB = SUB
                for (int i = 0; i < Sections.Count; i++)
                {
                    QuestID = GetSection(Sections[i], 0);
                    int QID = int.Parse(QuestID);
                    SubQuest = GetSection(Sections[i], 1);
                    WarpTo = GetSection(Sections[i], 2);

                    if (QID != -1 && (Adventureog.advLogInstance.Quest[QID - 1].Active || Adventureog.advLogInstance.Quest[QID - 1].AllowDialogueActivation) && Adventureog.advLogInstance.Quest[QID - 1].subQuest == int.Parse(SubQuest))
                    {
                        tp = int.Parse(WarpTo);
                        loadDialogue();
                        questFound = true;
                        Debug.Log("Slot Found: QuestID " + QuestID + ", SubQuest " + SubQuest + ", Warp To " + WarpTo);
                        if (!Adventureog.advLogInstance.Quest[QID - 1].Active)
                        {
                            Adventureog.advLogInstance.Quest[QID - 1].activate();
                        }
                        break;
                    }
                }

                //CHECK QUEST, QUEST = QUEST, SUB = Default (-1)
                if (!questFound)
                {
                    for (int i = 0; i < Sections.Count; i++)
                    {
                        QuestID = GetSection(Sections[i], 0);
                        int QID = int.Parse(QuestID);
                        SubQuest = GetSection(Sections[i], 1);
                        WarpTo = GetSection(Sections[i], 2);

                        if (QID != -1 && Adventureog.advLogInstance.Quest[QID - 1].Active && SubQuest == "-1")
                        {
                            tp = int.Parse(WarpTo);
                            loadDialogue();
                            questFound = true;
                            Debug.Log("Slot Found: QuestID " + QuestID + ", SubQuest " + SubQuest + ", Warp To " + WarpTo);
                            break;
                        }
                    }
                }

                //CHECK DEFAULT, QUEST = Default (-1), SUB = Default (-1)
                if (!questFound)
                {
                    for (int i = 0; i < Sections.Count; i++)
                    {
                        QuestID = GetSection(Sections[i], 0);
                        SubQuest = GetSection(Sections[i], 1);
                        WarpTo = GetSection(Sections[i], 2);

                        if (QuestID == "-1" && SubQuest == "-1")
                        {
                            tp = int.Parse(WarpTo);
                            loadDialogue();
                            questFound = true;
                            Debug.Log("Slot Found: QuestID " + QuestID + ", SubQuest " + SubQuest + ", Warp To " + WarpTo);
                            break;
                        }
                    }
                }

                if (!questFound)
                {
                    Debug.Log("Failed to warp to new slot. Check Slot " + tp.ToString() + "'s \"Warp To\" section for errors");
                }
            }
        }
    }

    void loadDialogue()
    {
        
        Debug.Log("Conversation Section: " + tp.ToString());

        string textToDisplay = dialogueText[tp];

        //Replce Text with appropriate calculations
        textToDisplay = textToDisplay.Replace("<chanceOfWinningWar>", getChanceOfWinning().ToString());

        if (AdvanceQuestOnTextLoad[tp] != 0)
        {
            Adventureog.advLogInstance.addProgress(AdvanceQuestOnTextLoad[tp], 1);
            if (!Adventureog.advLogInstance.Quest[AdvanceQuestOnTextLoad[tp] - 1].Active)
            {
                Adventureog.advLogInstance.Quest[AdvanceQuestOnTextLoad[tp] - 1].activate();
            }
        }
        if (dialogueType[tp] == 0 || dialogueType[tp] == 2)
        { 
            ChoicesCanvas.SetActive(false);
            DialogueTextObject.GetComponent<UnityEngine.UI.Text>().text = textToDisplay;
        }
        else if (dialogueType[tp] == 1)
        {
            ChoicesCanvas.SetActive(true);
            DialogueTextObject.GetComponent<UnityEngine.UI.Text>().text = GetSection(textToDisplay, 0);
            DialougeView.converstationInstance.showDialougeChoices();
            ChoicesCanvas.SetActive(true);
            int c = CountSections(textToDisplay);
            Dia1.SetActive(false);
            Dia2.SetActive(false);
            Dia3.SetActive(false);
            Dia4.SetActive(false);

            if (c > 1)
            {
                Dia1.SetActive(true);
                Dia1.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text = GetSection(textToDisplay, 1);
            }
            if (c > 2)
            {
                Dia2.SetActive(true);
                Dia2.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text = GetSection(textToDisplay, 2);
            }
            if (c > 3)
            {
                Dia3.SetActive(true);
                Dia3.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text = GetSection(textToDisplay, 3);
            }
            if (c > 4)
            {
                Dia4.SetActive(true);
                Dia4.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text = GetSection(textToDisplay, 4);
            }
        }
        //Update Name
        if (NPCName[tp] != "") NPCNameObject.GetComponent<UnityEngine.UI.Text>().text = NPCName[tp];
        //Update NPC Sprite
        if (NPCSprite[tp] != null) NPCPortrait.GetComponent<UnityEngine.UI.Image>().sprite = NPCSprite[tp];
        //Update Player Sprite
        if (PlayerSprite[tp] != null) PlayerPortrait.GetComponent<UnityEngine.UI.Image>().sprite = PlayerSprite[tp];
    }

    string GetSection(string text, int section)
    {
        //Section starts at 0. Section is defined as a string of text seperated by ';'

        if (CountSections(text) <= section || section < 0) return "";

        return text.Split(';')[section];
    }

    int CountSections(string text)
    {
        if (text == "") return 0;
        int count = 1;
        foreach (char c in text)
        {
            if (c == ';') count++;
        }
        return count;
    }

    private int getChanceOfWinning()
    {
        return 0;
    }

}
//*/