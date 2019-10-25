using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialougeView : MonoBehaviour
{
    public static DialougeView converstationInstance = null;
    public Button triggerChoices;
    public Image npcPhoto;
    public Image playerPhoto;
    public Image dialougeBox;
    public Text npcLabel;
    public Text dialouge;

    private GameObject choices;
    private GameObject optionOne;
    private GameObject optionTwo;
    private GameObject optionThree;
    private GameObject optionFour;


    private int choiceSelected;

    // Start is called before the first frame update
    void Start()
    {
        if (converstationInstance == null) converstationInstance = this;
        else if (converstationInstance != this) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        choices = GameObject.Find("ConversationView/choicesCanvas");
        optionOne = GameObject.Find("ConversationView/choicesCanvas/DialogueOptionOne");
        optionTwo = GameObject.Find("ConversationView/choicesCanvas/DialogueOptionTwo");
        optionThree = GameObject.Find("ConversationView/choicesCanvas/DialogueOptionThree");
        optionFour = GameObject.Find("ConversationView/choicesCanvas/DialogueOptionFour");
        Debug.Log("Started Conversation");
        choices.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void showDialougeChoices()
    {
        if (choices.activeInHierarchy == false)
            choices.SetActive(true);
        Vector3 playerPhotoPos = playerPhoto.transform.position;
        Vector3 npcPhotoPos = npcPhoto.transform.position;
        Vector3 boxPos = dialougeBox.transform.position;
        Vector3 namePos = npcLabel.transform.position;
        Vector3 dialougePos = dialouge.transform.position;

        playerPhoto.transform.position = new Vector3(playerPhotoPos.x, playerPhotoPos.y + 200, playerPhotoPos.z);
        npcPhoto.transform.position = new Vector3(npcPhotoPos.x, npcPhotoPos.y + 200, npcPhotoPos.z);
        dialougeBox.transform.position = new Vector3(boxPos.x, boxPos.y + 200, boxPos.z);
        npcLabel.transform.position = new Vector3(namePos.x, namePos.y + 200, namePos.z);
        dialouge.transform.position = new Vector3(dialougePos.x, dialougePos.y + 200, dialougePos.z);
        //dialouge.text = "Please select a dialogue choice.";
        //}
    }
        

    public void moveBack()
    {
        Vector3 playerPhotoPos = playerPhoto.transform.position;
        Vector3 npcPhotoPos = npcPhoto.transform.position;
        Vector3 boxPos = dialougeBox.transform.position;
        Vector3 namePos = npcLabel.transform.position;
        Vector3 dialougePos = dialouge.transform.position;

        playerPhoto.transform.position = new Vector3(playerPhotoPos.x, playerPhotoPos.y - 200, playerPhotoPos.z);
        npcPhoto.transform.position = new Vector3(npcPhotoPos.x, npcPhotoPos.y - 200, npcPhotoPos.z);
        dialougeBox.transform.position = new Vector3(boxPos.x, boxPos.y - 200, boxPos.z);
        npcLabel.transform.position = new Vector3(namePos.x, namePos.y - 200, namePos.z);
        dialouge.transform.position = new Vector3(dialougePos.x, dialougePos.y - 200, dialougePos.z);
        choices.SetActive(false);
    }

    public void questChoice()
    {
        showDialougeChoices();
        optionThree.SetActive(false);
        optionFour.SetActive(false);
    }

    public void numOfChoices(int number)
    {
        if(number >= 1)
        {
            optionOne.SetActive(true);
            if(number >= 2)
            {
                optionTwo.SetActive(true);
                if(number >= 3)
                {
                    optionThree.SetActive(true);
                    if (number >= 4)
                        optionFour.SetActive(true);
                }
            }
        }
    }

    public void choicePressed(string choiceNum)
    {
        //dialouge.text = "You pressed dialogue choice " + choiceNum + ".";
        if (choiceNum == "one")
            choiceSelected = 1;
        else if (choiceNum == "two")
            choiceSelected = 2;
        else if (choiceNum == "three")
            choiceSelected = 3;
        else if (choiceNum == "four")
            choiceSelected = 4;
        moveBack();
    }

    public int getChoicePressed()
    {
        //Returns an integer (0-4) if a choice has been pressed. This will reset the choice back to 0 upon activation
        int returnVal = choiceSelected;
        choiceSelected = 0;
        return returnVal;
    }
}