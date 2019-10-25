using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetConversationTree : MonoBehaviour
{
    public int textPosition = 0;
    public List<int> dialogType;
    public List<string> dialogueText;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Started Text");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && dialogType[textPosition] == 0)
        {
            textPosition += 1;
        }
        GameObject.Find("ConversationView/DialogueText").GetComponent<UnityEngine.UI.Text>().text = dialogueText[textPosition];
    }
}
