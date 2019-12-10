using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;


///*
public class FinalBossConversation : MonoBehaviour
{
    [Tooltip("Use \"Conversation View\" Gameobject")]
    public GameObject ConversationView;
    [Tooltip("0 = Normal\n" +
    "1 = 4 - way Choice\n" +
    "2 = Exit on next click\n" +
    "3 = Instantly Warp based on what quest is active.\n" +
    "4 = Shop Script")]
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
    "QuestID and Sub Quest can be set to -1 (;-1,-1,WarpToPoint;) to signify default value\n" +
    "if DialogueType == 4 (Shop), Use the following format\n" +
    "TradeType1,WarpIfSuccessful,warpIfFailed;TradeType2,WarpIfSuccessful,warpIfFailed..." +
    "For a No Trade warp, do: -1,warpToPoint,-1")]
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
    private GameObject finalBoss;

    private bool finallisActive;
    private bool dialogueActive;

    public GameObject blackout;

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
        AdvLog = GameObject.Find("AdventureLogPanel/AdventureLogBox");
        //if (ConvIsInactive) ConversationView.SetActive(false);
        hp = GameObject.Find("HUDCanvas/HPIndicator");
        inventory = GameObject.Find("HUDCanvas/Inventory");
        PlayerObject = GameObject.Find("Player_Jack");
        finalBoss = GameObject.Find("IsoJack_Overworld/NPCs/FinalBoss");
        finallisActive = false;


    }

    void OnEnable()
    {
        
    }

    public void StartConversation()
    {
        Debug.Log("Started Conversation");
        //GameManager.instance.inConversation = true;
        hp.SetActive(false);
        inventory.SetActive(false);
        ConversationView.SetActive(true);
        if (Adventureog.advLogInstance.isOpen == true)
            Adventureog.advLogInstance.closeLog();
        tp = 1;
        loadDialogue();
    }

    // Update is called once per frame
    void Update()
    {

        if(finalBoss.activeInHierarchy == true && finallisActive == false)
        {
            finallisActive = true;
            StartConversation();
        }

        if(tp == 4)
        {
            blackout.SetActive(true);
            if ((GameManager.instance.GuardTowerUpgrade + GameManager.instance.BarricadesUpgrade) == 3)
            {
                //do nothing
            }
            else
                tp = 10;
        }
        if (tp == 9)
            tp = 11;

       // dialogueActive = PlayerObject != null && Math.Sqrt(Math.Pow(transform.position.x - PlayerObject.transform.position.x, 2) +
                //Math.Pow(transform.position.y - PlayerObject.transform.position.y, 2)) <= 1;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (dialogueType[tp] == 0)
            {
                if (ChoiceWarps.Count > tp && ChoiceWarps[tp] != "")
                    tp = int.Parse(ChoiceWarps[tp]);
                else
                    tp++;
                loadDialogue();
            }

        }
        if(tp == 12)
            SceneManager.LoadScene("EndingCredits");

    }

    void loadDialogue()
    {
        
        Debug.Log("Conversation Section: " + tp.ToString());

        string textToDisplay = dialogueText[tp];

        //Replce Text with appropriate calculations
        
        if (dialogueType[tp] == 0 || dialogueType[tp] == 2)
        { 
            ChoicesCanvas.SetActive(false);
            DialogueTextObject.GetComponent<UnityEngine.UI.Text>().text = textToDisplay;
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