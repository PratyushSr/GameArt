using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    public float x;
    public float y;
    public GameObject screens;
    public GameObject Player;
    public GameObject destination;
    private bool teleported;
    private void Start()
    {
        teleported = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("transport");
        if (other.CompareTag("Player")&&!teleported)
            StartCoroutine(Teleport());
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            teleported = false;
    }

    IEnumerator Teleport()
    {
        if(screens==null)
        {

        }
        teleported = true;
        screens.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        Player.transform.position = new Vector2(x,y);
        yield return new WaitForSeconds(0.5f);
        screens.SetActive(false);
        yield return new WaitForSeconds(.3f);
        if ((x == -72 && y == 41))
            GameManager.instance.locationPopIn("Tavern");
        else
            GameManager.instance.locationPopIn("Iso Village");
    }
}
