using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TraslucentWhenBehind : MonoBehaviour
{
    public GameObject ObjectToTrack;

    private bool isTranslucent;
    private SpriteRenderer image;

    // Start is called before the first frame update
    void Start()
    {
        isTranslucent = false;
    }

    // Update is called once per frame
    void Update()
    {
        bool playerIsBehind = ((transform.position.y < ObjectToTrack.transform.position.y)
            && (transform.position.y+5 > ObjectToTrack.transform.position.y)
            && (transform.position.x-5 < ObjectToTrack.transform.position.x)
            && (transform.position.x+5 > ObjectToTrack.transform.position.x));
        //Debug.Log(playerIsBehind);
        if (isTranslucent && !playerIsBehind)
        {
            isTranslucent = false;

            //Change Back to Normal Visability based on Editor Settings
            image = GetComponent<SpriteRenderer>();
            var tempColor = image.color;
            tempColor.a = 1f;
            image.color = tempColor;
        }
        else if (!isTranslucent && playerIsBehind)
        {
            isTranslucent = true;

            //Make Translucent
            image = GetComponent<SpriteRenderer>();
            var tempColor = image.color;
            tempColor.a = 0.5f;
            image.color = tempColor;
        }
    }
}
