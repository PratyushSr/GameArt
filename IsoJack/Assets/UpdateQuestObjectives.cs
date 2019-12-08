using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateQuestObjectives : MonoBehaviour
{
    [Tooltip("1 - max quests (Check Adventurog.cs for more details)")]
    public int QuestID;
    [Tooltip("Make it start activated")]
    public bool ActivateIfDisabled;
    [Tooltip("If enabled, will automatically turn on the quest if a setConversationTree script calls the quest ID")]
    public bool AllowTextActivation;
    [Tooltip("Registers all the sub-quests and places text for them. The max listed here is the max sub-quests that it will register")]
    public List<string> subQuestText;

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
            Q.AllowDialogueActivation = AllowTextActivation;
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
