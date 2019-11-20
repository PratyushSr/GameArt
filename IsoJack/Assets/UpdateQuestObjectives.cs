using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateQuestObjectives : MonoBehaviour
{
    public GameObject AdventureLog;
    public int QuestID;
    //1 - max quests (Check Adventurog.cs for more details)
    public List<string> subQuestText;
    // Start is called before the first frame update
    void Start()
    {
        var Q = AdventureLog.GetComponent<Adventureog>().Quest[QuestID - 1];
        Q.maxSubQuest = subQuestText.Count;
        for (var i = 0; i < subQuestText.Count; i++)
        {
            Q.questInfo[i] = subQuestText[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
