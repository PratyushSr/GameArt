using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{

    public Animator myanimator;
    Collider2D axe;


    // Start is called before the first frame update
    void Start()
    {
        axe = GameObject.FindGameObjectWithTag("axe").GetComponent<Collider2D>();
        myanimator = this.GetComponent<Animator>();
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

    void Swing()
    {
        axe.enabled = true;
    }

    void NoSwing()
    {
        axe.enabled = false;
        myanimator.ResetTrigger("swing");
    }
}
