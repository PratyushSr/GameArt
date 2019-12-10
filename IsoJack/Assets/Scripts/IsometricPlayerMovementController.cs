using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricPlayerMovementController : MonoBehaviour
{

    public float movementSpeed = 1f;
    IsometricCharacterRenderer isoRenderer;
    public Animator animator;
    Rigidbody2D rbody;
    bool isbusy = false;
    float temptimer;
    float timer = 1;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        isoRenderer = GetComponentInChildren<IsometricCharacterRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            int x = GameObject.Find("HUDCanvas").transform.Find("Inventory").gameObject.GetComponent<Inventory>().GetSlotCount(1);
            Debug.Log(x);
            if (x == 1)
            {
                animator.SetBool("attack", true);
                animator.SetBool("attack2", false);
                animator.SetBool("attack3", false);
            }
            else if (x == 2)
            {
                animator.SetBool("attack2", true);
                animator.SetBool("attack", false);
                animator.SetBool("attack3", false);
            }
            else if (x == 3)
            {
                animator.SetBool("attack2", false);
                animator.SetBool("attack3", true);
                animator.SetBool("attack", false);
            }
            isbusy = true;
            temptimer = timer;
        }

        if (!isbusy)
        {
            Vector2 currentPos = rbody.position;
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            Vector2 inputVector = new Vector2(horizontalInput, verticalInput);
            inputVector = Vector2.ClampMagnitude(inputVector, 1);
            Vector2 movement = inputVector * movementSpeed;
            Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
            rbody.MovePosition(newPos);
            isoRenderer.SetDirection(movement);
        }
        else
        {
            if (temptimer >= 0)
            {
                temptimer -= Time.deltaTime;
                Vector2 currentPos = rbody.position;
                float horizontalInput = Input.GetAxis("Horizontal");
                float verticalInput = Input.GetAxis("Vertical");
                Vector2 inputVector = new Vector2(horizontalInput, verticalInput);
                inputVector = Vector2.ClampMagnitude(inputVector, 1);
                Vector2 movement = inputVector * movementSpeed;
                Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
                rbody.MovePosition(newPos);
            }
            else
            {
                animator.SetBool("attack", false);
                animator.SetBool("attack2", false);
                animator.SetBool("attack3", false);
                isbusy = false;
            }
        }
    }
}
