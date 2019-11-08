using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphyInv : MonoBehaviour
{

    public Vector2 target;
    public GameObject item;
    public GameObject itemr;
    public Vector2 spot;
    public float startspeed;
    public float movespeed;
    public bool itemactive;
    public bool inventory;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        itemactive = false;
        movespeed = startspeed;
    }

    // Update is called once per frame
    void Update()
    {
        target = new Vector2(player.transform.position.x - 10, player.transform.position.y + 3);
        if (Input.GetKeyDown(KeyCode.E))
        {
            itemactive = true;
        }
        if (itemactive)
        {
            itemr.SetActive(true);
            if (Vector2.Distance(itemr.transform.position,target)>3.3f)
            {
                itemr.transform.position = Vector2.MoveTowards(itemr.transform.position, target, movespeed * Time.deltaTime);
            }

        }
        else
        {
            itemr.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("in");
        if (other.CompareTag("Player"))
        {
            Debug.Log("In");
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Interacted");
                itemactive = true;
            }
        }
    }
}

