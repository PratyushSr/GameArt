using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialougeView : MonoBehaviour
{
    public Button triggerChoices;
    public Image npcPhoto;
    public Image playerPhoto;
    public Image dialougeBox;
    public Text npcLabel;
    public Text dialouge;

    public Canvas choices;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void showDialougeChoices()
    {
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
        
        npcLabel.text = "Tavern Maid";
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
    }

    public void choicePressed(string choiceNum)
    {
        dialouge.text = "You pressed dialogue choice " + choiceNum + ".";
        moveBack();
    }
}