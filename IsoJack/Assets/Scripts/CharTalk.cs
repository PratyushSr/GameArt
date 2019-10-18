using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharTalk : MonoBehaviour
{
    public GameObject DialogueBox;
    public Text diotext;
    public string npcName;
    public Text npcLabel;
    public string dialogue;
    public bool dialogueActive;
    public bool talked;
    public Image npcPortrait;
    public Sprite portrait;

    public GameObject inventoryBar;
    public GameObject hp;
    public GameObject dialougeView;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(talked);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)&&dialogueActive)
        {
            if (DialogueBox.activeInHierarchy)
            {
                DialogueBox.SetActive(false);
                exitDialougeView();
            }
            else
            {
                enterDialougeView();
                DialogueBox.SetActive(true);
                npcLabel.text = npcName;
                diotext.text = dialogue;
                npcPortrait.sprite = portrait;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            dialogueActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            dialogueActive = false;
        }
    }


    public void enterDialougeView()
    {
        dialougeView.SetActive(true);
        inventoryBar.SetActive(false);
        hp.SetActive(false);
    }

    public void exitDialougeView()
    {
        dialougeView.SetActive(false);

        inventoryBar.SetActive(true);
        hp.SetActive(true);
    }
}

