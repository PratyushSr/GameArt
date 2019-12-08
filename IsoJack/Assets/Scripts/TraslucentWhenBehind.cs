using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TraslucentWhenBehind : MonoBehaviour
{
    public GameObject ObjectToTrack;
    public bool CircleCollision;
    public double radius;
    public double xoffset;
    public double yoffset;
    public double xAdditionalRadiusIfRectangle;
    public double yAdditionalRadiusIfRectangle;

    //Leaving everything blank keeps it at default 10 width and 5 height above the object.
    //-------------------

    private bool isTranslucent;
    private SpriteRenderer image;

    // Start is called before the first frame update
    void Start()
    {
        isTranslucent = false;
        if (radius == 0)
        {
            radius = 2.5;
            xAdditionalRadiusIfRectangle = 2.5;
            yoffset = 2.5;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ObjectToTrack != null)
        {
            bool playerIsBehind;
            if (CircleCollision)
            {
                //Distance Formula
                playerIsBehind = Math.Sqrt(Math.Pow(transform.position.x + xoffset - ObjectToTrack.transform.position.x, 2) +
                    Math.Pow(transform.position.y + yoffset - ObjectToTrack.transform.position.y, 2)) <= radius;
            }
            else
            {
                playerIsBehind = ((transform.position.y - radius - yAdditionalRadiusIfRectangle + yoffset < ObjectToTrack.transform.position.y)
                    && (transform.position.y + radius + yAdditionalRadiusIfRectangle + yoffset > ObjectToTrack.transform.position.y)
                    && (transform.position.x - radius - xAdditionalRadiusIfRectangle + xoffset < ObjectToTrack.transform.position.x)
                    && (transform.position.x + radius + xAdditionalRadiusIfRectangle + xoffset > ObjectToTrack.transform.position.x));
            }
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
}
