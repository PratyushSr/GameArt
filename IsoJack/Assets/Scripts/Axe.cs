using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{

    Animator myanimator;
    Collider2D axe;

    // Start is called before the first frame update
    void Start()
    {
        axe = GameObject.FindObjectWithTag("Axe").GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("interact"))
        {
            myanimator.SetTrigger("swing");
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
