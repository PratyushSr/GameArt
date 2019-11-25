using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateQuestObjectives : MonoBehaviour
{
    public int QuestID;
    public bool ActivateIfDisabled;
    //1 - max quests (Check Adventurog.cs for more details)
    public List<string> subQuestText;
    // Start is called before the first frame update

    private int waitAFrame = 0; //Forced the script to wait one frame before activating
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (waitAFrame == 1)
        {
            var Q = GameObject.Find("AdventureLogPanel").GetComponent<Adventureog>().Quest[QuestID - 1];
            Q.maxSubQuest = subQuestText.Count;
            Q.questInfo = new List<string>();
            for (var i = 0; i < subQuestText.Count; i++)
            {
                Q.questInfo.Add(subQuestText[i]);
            }
            if (ActivateIfDisabled && !Q.Active)
            {
                Q.activate();
            }
        }
        if (waitAFrame < 2)
            waitAFrame++;
    }
}
