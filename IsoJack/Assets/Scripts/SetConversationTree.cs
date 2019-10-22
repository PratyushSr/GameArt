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
    public List<string> dialogueText;
    public List<string> NPCName;

    private int tp; //Text Position
    private GameObject choicesCanvas;
    private GameObject Dia1;
    private GameObject Dia2;
    private GameObject Dia3;
    private GameObject Dia4;

    // Start is called before the first frame update
    void Start()
    {
        choicesCanvas = GameObject.Find("ConversationView/choicesCanvas");
        Dia1 = GameObject.Find("ConversationView/choicesCanvas/DialogueOptionOne");
        Dia2 = GameObject.Find("ConversationView/choicesCanvas/DialogueOptionTwo");
        Dia3 = GameObject.Find("ConversationView/choicesCanvas/DialogueOptionThree");
        Dia4 = GameObject.Find("ConversationView/choicesCanvas/DialogueOptionFour");
        choicesCanvas.SetActive(false);
    }

    void OnEnable()
    {
        Debug.Log("Started Conversation");
        tp = textPosition;
        GameObject.Find("ConversationView/DialogueText").GetComponent<UnityEngine.UI.Text>().text = dialogueText[tp];
        GameObject.Find("ConversationView/NPCNameTag").GetComponent<UnityEngine.UI.Text>().text = NPCName[tp];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && dialogueType[tp] == 0)
        {
            tp += 1;
            if (tp >= dialogueText.Count || dialogueType[tp] == 2)
            {
                Debug.Log("Ended Conversation");
                gameObject.GetComponent<SetConversationTree>().enabled = false;
                choicesCanvas.SetActive(true);
                Dia1.SetActive(true);
                Dia2.SetActive(true);
                Dia3.SetActive(true);
                Dia4.SetActive(true);
                GameObject.Find("ConversationView").SetActive(false);
            }
            else
            {
                if (dialogueType[tp] == 0)
                {
                    choicesCanvas.SetActive(false);
                    GameObject.Find("ConversationView/DialogueText").GetComponent<UnityEngine.UI.Text>().text = dialogueText[tp];
                }
                else if (dialogueType[tp] == 1)
                {
                    GameObject.Find("ConversationView/DialogueText").GetComponent<UnityEngine.UI.Text>().text = GetSection(dialogueText[tp], 0);
                    GameObject.Find("ConversationView").GetComponent<DialougeView>().showDialougeChoices();
                    choicesCanvas.SetActive(true);
                    int c = CountSections(dialogueText[tp]);
                    Debug.Log(c);
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
                if (NPCName[tp] != "") GameObject.Find("ConversationView/NPCNameTag").GetComponent<UnityEngine.UI.Text>().text = NPCName[tp];
            }
        }
        //GameObject.Find("ConversationView/DialogueText").GetComponent<UnityEngine.UI.Text>().text = dialogueText[textPosition];
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
