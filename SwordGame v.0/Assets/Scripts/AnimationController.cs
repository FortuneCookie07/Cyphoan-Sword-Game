using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AnimationController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isRunningHash;
    int isJumpingHash;
    int isSlashingHash;
    int highSpinHash;

    public bool animatorDebug = false;

    //static Timer myTimer = new Timer(2000);

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        isJumpingHash = Animator.StringToHash("isJumping");
        isSlashingHash = Animator.StringToHash("isSlashing");
        highSpinHash = Animator.StringToHash("highSpin");
    }

    // Update is called once per frame
    void Update()
    {
        
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isRunning = animator.GetBool(isRunningHash); 
        bool isJumping = animator.GetBool(isJumpingHash);
        bool isSlashing = animator.GetBool(isSlashingHash);
        bool highSpin = animator.GetBool(highSpinHash);

        bool forwardPressed = Input.GetKey("w");
        bool runPressed = Input.GetKey("left shift");
        bool jumpPressed = Input.GetKey("space");
        bool slashPressed = Input.GetMouseButtonDown(0);
        bool highSpinPressed = Input.GetKeyDown(KeyCode.F);

        //1 - when player presses w
        if (!isWalking && forwardPressed)
        {
            animator.SetBool(isWalkingHash, true);
            animDebug("1");
        }

        //2 - when player is not pressing w
        if (isWalking && !forwardPressed)
        {
            animator.SetBool(isWalkingHash, false);
            animDebug("2");
        }

        //3 - if player is not running but is walking and presses left shift
        if (!isRunning && (forwardPressed && runPressed))
        {
            animator.SetBool(isRunningHash, true);
            animDebug("3");
        }
        
        //4 - if player is running and stops walking or running
        if (isRunning && (!forwardPressed || !runPressed))
        {
            animator.SetBool(isRunningHash, false);
            animDebug("4");
        }

        //5 - if the player lets go of shift but is still pressing w
        if (forwardPressed && !runPressed)
        {
            animator.SetBool(isWalkingHash, true);
            animator.SetBool(isRunningHash, false);
            animDebug("5");
        }

        //6 - if the player presses space
        if (jumpPressed)
        {
            animator.SetBool(isJumpingHash, true);
            animDebug("6");
        }

        //7 - when the player lets go of space and is walking
        if (!jumpPressed && (isWalking && !runPressed))
        {
            animator.SetBool(isJumpingHash, false);
            animator.SetBool(isRunningHash, false);
            animDebug("7");
        }

        //8 - when the player lets go of space and is running
        if(!jumpPressed && runPressed)
        {
            animator.SetBool(isJumpingHash, false);
            animator.SetBool(isRunningHash, true);
            animDebug("8");
        }

        //9 - when the player lets go of space and is idle
        if(!jumpPressed && (!forwardPressed && !runPressed))
        {
            animator.SetBool(isJumpingHash, false);
            animDebug("9");
        }

        //10 - when the player left clicks
        if (slashPressed)
        {
            animator.SetBool(isSlashingHash, true);
            animDebug("10");
        }

        //11 - when the player lets go of left click
        if (!slashPressed)
        {
            animator.SetBool(isSlashingHash, false);
            animDebug("11");
        }

        if (highSpinPressed)
        {
            animator.SetBool(highSpinHash, true);

            animDebug("high spin");
        }
    }

    void animDebug(string input)
    {
        if (animatorDebug)
        {
            Debug.Log(input);
        }

    }

   
}
