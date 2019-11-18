using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class quest
{

    public string questTitle;
    public string questInfo;
    public GameObject qButton;

    public quest(string title)
    {
        questTitle = title;
        questInfo = " ";
        qButton = null;
    }
}

public class Adventureog : MonoBehaviour
{
    public static Adventureog advLogInstance = null;
    private GameObject AdventureLogCanvas;
    public Text QuestText;
    public Text QuestTitle;
    public Sprite unpressed;
    public Sprite pressed;
    private Vector3 advLogPos;
    public bool isOpen;

    public quest questOne = new quest("Protector of the People");
    public quest questTwo = new quest("Battle of Beserk");
    public quest questThree = new quest("Wild Smith");
    public quest questFour = new quest("Tavern Queen's Bounty");
    public quest questFive = new quest("Sawmill Helper");
    public quest questSix = new quest("Hat for a Hero");


    // Start is called before the first frame update
    void Start()
    {
        if (advLogInstance == null) advLogInstance = this;
        else if (advLogInstance != this) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        AdventureLogCanvas = GameObject.Find("AdventureLogPanel/AdventureLogBox");
        advLogPos = AdventureLogCanvas.transform.position;

        questOne.qButton = GameObject.Find("AdventureLogPanel/AdventureLogBox/QuestOne");
        questTwo.qButton = GameObject.Find("AdventureLogPanel/AdventureLogBox/QuestTwo");
        questThree.qButton = GameObject.Find("AdventureLogPanel/AdventureLogBox/QuestThree");
        questFour.qButton = GameObject.Find("AdventureLogPanel/AdventureLogBox/QuestFour");
        questFive.qButton = GameObject.Find("AdventureLogPanel/AdventureLogBox/QuestFive");
        questSix.qButton = GameObject.Find("AdventureLogPanel/AdventureLogBox/QuestSix");

        questOne.qButton.SetActive(false);
        questTwo.qButton.SetActive(false);
        questThree.qButton.SetActive(false);
        questFour.qButton.SetActive(false);
        questFive.qButton.SetActive(false);
        questSix.qButton.SetActive(false);

    }

    void Update()
    {
            
    }

    bool checkAnyButtonActive()
    {
        if (questOne.qButton.activeInHierarchy == false && questTwo.qButton.activeInHierarchy == false && questThree.qButton.activeInHierarchy == false
            && questFour.qButton.activeInHierarchy == false && questFive.qButton.activeInHierarchy == false && questSix.qButton.activeInHierarchy == false)
            return false;
        else
            return true;
    }

    public void openLog()
    {
        AdventureLogCanvas.transform.position = new Vector3(960f, 540f, 0f);
        GameManager.instance.inConversation = true;
        QuestTitle.text = " ";
        QuestText.text = " ";
        if (checkAnyButtonActive() == false)
            QuestText.text = "Adventure Log is currently empty.";
        isOpen = true;
    }

    public void closeLog()
    {
        AdventureLogCanvas.transform.position = advLogPos;
        GameManager.instance.inConversation = false;
        resetButtons();
        isOpen = false;
    }

    void resetButtons()
    {
        questOne.qButton.GetComponent<Button>().image.sprite = unpressed;
        questTwo.qButton.GetComponent<Button>().image.sprite = unpressed;
        questThree.qButton.GetComponent<Button>().image.sprite = unpressed;
        questFour.qButton.GetComponent<Button>().image.sprite = unpressed;
        questFive.qButton.GetComponent<Button>().image.sprite = unpressed;
        questSix.qButton.GetComponent<Button>().image.sprite = unpressed;
    }

    public void updateQuestText(int num)
    {
        switch(num)
        {
            case 1:
                QuestTitle.text = questOne.questTitle;
                QuestText.text = questOne.questInfo;
                questOne.qButton.GetComponent<Button>().image.sprite = pressed;
                break;
            case 2:
                QuestTitle.text = questTwo.questTitle;
                QuestText.text = questTwo.questInfo;
                questTwo.qButton.GetComponent<Button>().image.sprite = pressed;
                break;
            case 3:
                QuestTitle.text = questThree.questTitle;
                QuestText.text = questThree.questInfo;
                questThree.qButton.GetComponent<Button>().image.sprite = pressed;
                break;
            case 4:
                QuestTitle.text = questFour.questTitle;
                QuestText.text = questFour.questInfo;
                questFour.qButton.GetComponent<Button>().image.sprite = pressed;
                break;
            case 5:
                QuestTitle.text = questFive.questTitle;
                QuestText.text = questFive.questInfo;
                questFive.qButton.GetComponent<Button>().image.sprite = pressed;
                break;
            case 6:
                QuestTitle.text = questSix.questTitle;
                QuestText.text = questSix.questInfo;
                questSix.qButton.GetComponent<Button>().image.sprite = pressed;
                break;
            default:
                Debug.Log("Error setting questText!!");
                break;
        }
    }
}
