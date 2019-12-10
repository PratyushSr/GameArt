using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
    public GameObject currentInterObj = null;
    // Start is called before the first frame update
    public InteractionObject currentInterObjScript = null;
    public Inventory inventory;
    public float tree;
    public Text treeamount;

    void Update()
    {
        if (Input.GetButtonDown("interact") && currentInterObj)
        {
            //check to see if object is to be stored in inverntory
            if (currentInterObjScript.inventory)
            {
                //inventory.AddItem(currentInterObj);
                //We will need to change this to an int based on what item it is, unfortunatly.
            }


            //Do something with object
            currentInterObj.SendMessage("DoInteraction");
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("interObject"))
        {
            Debug.Log(other.name);
            currentInterObj = other.gameObject;
            currentInterObjScript = currentInterObj.GetComponent<InteractionObject>();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("interObject"))
        {
            if (other.gameObject == currentInterObj)
            {
                currentInterObj = null;
              
                GameManager.instance.wood += 5;
                treeamount.text = GameManager.instance.wood.ToString();
            }
        }
    }
}
