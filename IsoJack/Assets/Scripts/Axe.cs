using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Axe : MonoBehaviour
{

    public Animator myanimator;


    public GameObject axe1;
    public GameObject axe2;
    public GameObject axe3;
    public Text treeamount;



    // Start is called before the first frame update
    void Start()
    {

        myanimator = this.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            changeaxes();
        }
    }




    // Update is called once per frame

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("interObject") && Input.GetKeyDown(KeyCode.E))
        {
            
            myanimator.SetTrigger("swing");
            Debug.Log("swing");

        }


    }

    void changeaxes()
    {
        if (axe1.active == true)
        {
            axe1.SetActiveRecursively(false);
            axe2.SetActiveRecursively(true);
            axe3.SetActiveRecursively(false);
           
        }
        else if (axe2.active == true)
        {
            axe1.SetActiveRecursively(false);
            axe2.SetActiveRecursively(false);
            axe3.SetActiveRecursively(true);
            
        }
        else if (axe3.active == true)
        {
            axe1.SetActiveRecursively(true);
            axe2.SetActiveRecursively(false);
            axe3.SetActiveRecursively(false);
            
        }

    }

    /*void Swing()
    {
        axe.enabled = true;
    }

    void NoSwing()
    {
        axe.enabled = false;
        myanimator.ResetTrigger("swing");
    }*/
}
