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

    public List<quest> Quest = new List<quest>();
    public int totalQuests;

    // Start is called before the first frame update
    void Start()
    {
        totalQuests = 6;
        Quest.Add(new quest("Protector of the People"));
        Quest.Add(new quest("Battle of Beserk"));
        Quest.Add(new quest("Wild Smith"));
        Quest.Add(new quest("Tavern Queen's Bounty"));
        Quest.Add(new quest("Sawmill Helper"));
        Quest.Add(new quest("Hat for a Hero"));




        if (advLogInstance == null) advLogInstance = this;
        else if (advLogInstance != this) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        AdventureLogCanvas = GameObject.Find("AdventureLogPanel/AdventureLogBox");
        advLogPos = AdventureLogCanvas.transform.position;

        Quest[0].qButton = GameObject.Find("AdventureLogPanel/AdventureLogBox/QuestOne");
        Quest[1].qButton = GameObject.Find("AdventureLogPanel/AdventureLogBox/QuestTwo");
        Quest[2].qButton = GameObject.Find("AdventureLogPanel/AdventureLogBox/QuestThree");
        Quest[3].qButton = GameObject.Find("AdventureLogPanel/AdventureLogBox/QuestFour");
        Quest[4].qButton = GameObject.Find("AdventureLogPanel/AdventureLogBox/QuestFive");
        Quest[5].qButton = GameObject.Find("AdventureLogPanel/AdventureLogBox/QuestSix");

        Quest[0].qButton.SetActive(false);
        Quest[1].qButton.SetActive(false);
        Quest[2].qButton.SetActive(false);
        Quest[3].qButton.SetActive(false);
        Quest[4].qButton.SetActive(false);
        Quest[5].qButton.SetActive(false);

    }

    void Update()
    {
            
    }

    bool checkAnyButtonActive()
    {
        for (var i = 0; i < totalQuests; i++)
            if (Quest[i].qButton.activeInHierarchy == true)
                return true;
        return false;
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
        for (var i = 0; i < totalQuests; i++)
            Quest[i].qButton.GetComponent<Button>().image.sprite = unpressed;
    }

    public void updateQuestText(int num)
    {
        if (num > 0 && num <= totalQuests) {
            QuestTitle.text = Quest[num - 1].questTitle;
            QuestText.text = Quest[num - 1].questInfo;
            Quest[num - 1].qButton.GetComponent<Button>().image.sprite = pressed;
        }
        else {
            Debug.Log("Error setting questText!!");
        }
    }
}
