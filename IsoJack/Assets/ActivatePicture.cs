using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePicture : MonoBehaviour
{
    public GameObject objectToTrack;
    public GameObject pictureOverlay;

    private bool pictureActive = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pictureActive && Input.GetKeyDown(KeyCode.Space))
        {
            pictureActive = false;
            pictureOverlay.SetActive(false);
        }
        else if (!pictureActive && Input.GetKeyDown(KeyCode.Space) && Vector2.Distance(objectToTrack.transform.position, transform.position) < 2)
        {
            pictureActive = true;
            pictureOverlay.SetActive(true);
        }
    }
}
