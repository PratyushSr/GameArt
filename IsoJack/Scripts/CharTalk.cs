using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharTalk : MonoBehaviour
{
    public GameObject DialogueBox;
    public Text diotext;
    public string dialogue;
    public bool dialogueActive;
    public bool talked;

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
            }
            else
            {
                DialogueBox.SetActive(true);
                diotext.text = dialogue;
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
}

