using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetConversationTree : MonoBehaviour
{
    public int textPosition = 0;
    public List<int> dialogueType;
    /* 0 = Normal
     * 1 = 4 - way Choice
     * 2 = Exit
     */
    public List<string> NPCName;
    public List<string> dialogueText;
    public List<string> ChoiceWarps; //Only for Dialogue Options Warp1;Warp2;Warp3;Warp4

    private int tp; //Text Position
    private GameObject ConversationView;
    private GameObject DialogueTextObject;
    private GameObject NPCNameObject;
    private GameObject ChoicesCanvas;
    private GameObject Dia1;
    private GameObject Dia2;
    private GameObject Dia3;
    private GameObject Dia4;

    private bool loadDialogue;

    // Start is called before the first frame update
    void Start()
    {
    }

    void OnEnable()
    {
        ConversationView = GameObject.Find("ConversationView");
        DialogueTextObject = GameObject.Find("ConversationView/DialogueText");
        NPCNameObject = GameObject.Find("ConversationView/NPCNameTag");
        ChoicesCanvas = GameObject.Find("ConversationView/choicesCanvas");
        Dia1 = GameObject.Find("ConversationView/choicesCanvas/DialogueOptionOne");
        Dia2 = GameObject.Find("ConversationView/choicesCanvas/DialogueOptionTwo");
        Dia3 = GameObject.Find("ConversationView/choicesCanvas/DialogueOptionThree");
        Dia4 = GameObject.Find("ConversationView/choicesCanvas/DialogueOptionFour");
        Debug.Log("Started Conversation");
        tp = textPosition;
        loadDialogue = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0) && dialogueType[tp] == 0)
        {
            tp += 1;
            loadDialogue = true;
        }
        
        if (loadDialogue)
        {
            Debug.Log(tp);
            loadDialogue = false;      
            if (tp >= dialogueText.Count || dialogueType[tp] == 2)
            {
                Debug.Log("Ended Conversation");
                gameObject.GetComponent<SetConversationTree>().enabled = false;
                ChoicesCanvas.SetActive(true);
                Dia1.SetActive(true);
                Dia2.SetActive(true);
                Dia3.SetActive(true);
                Dia4.SetActive(true);
                ConversationView.SetActive(false);
            }
            else
            {
          
                if (dialogueType[tp] == 0)
                {
                    ChoicesCanvas.SetActive(false);
                    DialogueTextObject.GetComponent<UnityEngine.UI.Text>().text = dialogueText[tp];
                }
                else if (dialogueType[tp] == 1)
                {
                    DialogueTextObject.GetComponent<UnityEngine.UI.Text>().text = GetSection(dialogueText[tp], 0);
                    ConversationView.GetComponent<DialougeView>().showDialougeChoices();
                    ChoicesCanvas.SetActive(true);
                    int c = CountSections(dialogueText[tp]);
                    Dia1.SetActive(false);
                    Dia2.SetActive(false);
                    Dia3.SetActive(false);
                    Dia4.SetActive(false);
                    
                    if (c > 1)
                    {
                        Dia1.SetActive(true);
                        Dia1.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text = GetSection(dialogueText[tp], 1);
                    }
                    if (c > 2)
                    {
                        Dia2.SetActive(true);
                        Dia2.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text = GetSection(dialogueText[tp], 2);
                    }
                    if (c > 3)
                    {
                        Dia3.SetActive(true);
                        Dia3.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text = GetSection(dialogueText[tp], 3);
                    }
                    if (c > 4)
                    {
                        Dia4.SetActive(true);
                        Dia4.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text = GetSection(dialogueText[tp], 4);
                    }
                }
                if (NPCName[tp] != "") NPCNameObject.GetComponent<UnityEngine.UI.Text>().text = NPCName[tp];
            }
        }
        if (dialogueType[tp] == 1)
        {
            int choice = ConversationView.GetComponent<DialougeView>().getChoicePressed();
            if (choice != 0)
            {
                tp = int.Parse(GetSection(ChoiceWarps[tp], choice - 1));
                loadDialogue = true;
            }
        }
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
}
