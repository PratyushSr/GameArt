using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForgeMasterAnimation : MonoBehaviour
{
    public Animator animation;
    private int currentDirection;
    private bool walk = false;
    private Vector3 previousLocation;
    // Start is called before the first frame update
    void Start()
    {
        currentDirection = 0;
        /* 0 = NE  ^  >
         * 1 = NW  ^  <
         * 2 = SW  v  <
         * 3 = SE  v  >
         * */
        walk = false;
        previousLocation = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(previousLocation, transform.position) < .01f)
        {
            if (walk)
            {
                walk = false;
                updateAnimation();
            }
        }
        else if (!walk)
        {
            walk = true;
            updateAnimation();
        }
        int newDirection = currentDirection;
        if (previousLocation.y < transform.position.y)
        {
            if (previousLocation.x > transform.position.x)
            {
                newDirection = 1;
            }
            if (previousLocation.x < transform.position.x)
            {
                newDirection = 0;
            }
        }
        if (previousLocation.y > transform.position.y)
        {
            if (previousLocation.x > transform.position.x)
            {
                newDirection = 2;
            }
            if (previousLocation.x < transform.position.x)
            {
                newDirection = 3;
            }
        }

        if (currentDirection != newDirection){
            currentDirection = newDirection;
            updateAnimation();
        }

        previousLocation = transform.position;
    }

    public void updateAnimation()
    {
        if (walk)
        {
            switch (currentDirection)
            {
                case 0: animation.Play("Forge_Master_NE_Walk"); break;
                case 1: animation.Play("Forge_Master_NW_Walk"); break;
                case 2: animation.Play("Forge_Master_SW_Walk"); break;
                case 3: animation.Play("Forge_Master_SE_Walk"); break;
            }
        }
        else
        {
            switch (currentDirection)
            {
                case 0: animation.Play("Forge_Master_NE_Idle"); break;
                case 1: animation.Play("Forge_Master_NW_Idle"); break;
                case 2: animation.Play("Forge_Master_SW_Idle"); break;
                case 3: animation.Play("Forge_Master_SE_Idle"); break;
            }
        }
    }
}
