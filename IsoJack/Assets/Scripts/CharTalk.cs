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
<<<<<<< HEAD
=======
    public bool hehere;
    public string dio2;
>>>>>>> sammy

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
<<<<<<< HEAD
=======
        else if(Input.GetKeyDown(KeyCode.Space)&&dialogueActive&&hehere)
        {
            if (DialogueBox.activeInHierarchy)
            {
                DialogueBox.SetActive(false);
            }
            else
            {
                DialogueBox.SetActive(true);
                diotext.text = dio2;
            }
        }
>>>>>>> sammy
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            dialogueActive = true;
        }
<<<<<<< HEAD
=======
        if(other.CompareTag("Mikhael"))
        {
            hehere = true;
        }
>>>>>>> sammy
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            dialogueActive = false;
        }
    }
}

