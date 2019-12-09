﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private GameObject[] invSlot = new GameObject[5];
    private int[] amountInSlot = new int[5];
    [Tooltip("Set Size to 3 and add all three axe images")]
    public List<Sprite> Slot1Sprite;
    [Tooltip("The image to display in Slot 2 when you get food")]
    public Sprite Slot2Sprite;
    [Tooltip("The image to display in Slot 3 when you get raw meet")]
    public Sprite Slot3Sprite;
    [Tooltip("The image to display in Slot 4 when you get bones")]
    public Sprite Slot4Sprite;
    [Tooltip("The image to display in Slot 5 when you get quest item")]
    public Sprite Slot5Sprite;

    void Start()
    {
        for(int i = 0; i < 5; i++)
        {
            invSlot[i] = this.gameObject.transform.Find("Slot" + (i+1).ToString()).gameObject;
            amountInSlot[i] = 0;
        }
        Debug.Log(invSlot[0]);
    }

    public void AddItem(int slot, int amount)
    {
        //Never input an amount other than one for slot 1
        amountInSlot[slot - 1]+=amount;
        if (slot == 1)
            invSlot[0].GetComponent<UnityEngine.UI.Image>().sprite = Slot1Sprite[amountInSlot[0] - 1];
        else if (slot == 2)
            invSlot[1].GetComponent<UnityEngine.UI.Image>().sprite = Slot2Sprite;
        else if (slot == 3)
            invSlot[2].GetComponent<UnityEngine.UI.Image>().sprite = Slot3Sprite;
        else if (slot == 4)
            invSlot[3].GetComponent<UnityEngine.UI.Image>().sprite = Slot4Sprite;
        else if (slot == 5)
            invSlot[4].GetComponent<UnityEngine.UI.Image>().sprite = Slot5Sprite;

        UpdateCountInSlot(slot);
    }
    public bool RemoveItem(int slot, int amount)
    {
        //Never use Slot 1
        if (amountInSlot[slot - 1] < amount)
            return false;

        amountInSlot[slot - 1]-=amount;

        if (slot == 1)
            Debug.Log("Do not remove items in slot 1");
        else if (amountInSlot[slot-1] == 0)
            invSlot[slot-1].GetComponent<UnityEngine.UI.Image>().sprite = null;
        UpdateCountInSlot(slot);

        return true;
    }
    
    public int GetSlotCount(int slot)
    {
        return amountInSlot[slot - 1];
    }

    private void UpdateCountInSlot(int slot)
    {
        string textToDisplay = "";
        if (amountInSlot[slot-1] > 0)
        {
            textToDisplay = amountInSlot[slot - 1].ToString();
        }
        if (slot >= 2 && slot <= 4)
        {
            invSlot[slot - 1].transform.Find("AmountDisplay").gameObject.GetComponent<UnityEngine.UI.Text>().text = textToDisplay;
        }
    }
}
