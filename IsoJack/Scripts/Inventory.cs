using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject[] inventory = new GameObject[10];
    // Start is called before the first frame update

    public void AddItem(GameObject item)
    {
        bool itemAdded = false;

        //find the first open slot in the inventory
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)
            {
                inventory[i] = item;
                Debug.Log(item.name + "was added");
                itemAdded = true;
                item.SendMessage("DoInteraction");
                break;
            }
        }
        //inventory full
        if (!itemAdded)
        {
            Debug.Log("Inventory Full - Item Not Added");
        }
    }
}
