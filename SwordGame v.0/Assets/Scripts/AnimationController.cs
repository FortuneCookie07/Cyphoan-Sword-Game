using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AnimationController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isBackingHash;
    int isRunningHash;
    int isJumpingHash;
    int isSlashingHash;
    int leftWalkStrafingHash;
    int rightWalkStrafingHash;

    public bool animatorDebug = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isBackingHash = Animator.StringToHash("isBacking");
        isRunningHash = Animator.StringToHash("isRunning");
        isJumpingHash = Animator.StringToHash("isJumping");
        isSlashingHash = Animator.StringToHash("isSlashing");
        leftWalkStrafingHash = Animator.StringToHash("leftWalkStrafing");
        rightWalkStrafingHash = Animator.StringToHash("rightWalkStrafing");
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isBacking = animator.GetBool(isBackingHash);
        bool isRunning = animator.GetBool(isRunningHash); 
        bool isJumping = animator.GetBool(isJumpingHash);
        bool isSlashing = animator.GetBool(isSlashingHash);
        bool leftWalkStrafing = animator.GetBool(leftWalkStrafingHash);
        bool rightWalkStrafing = animator.GetBool(rightWalkStrafingHash);

        bool forwardPressed = Input.GetKey("w");
        bool backwardPressed = Input.GetKey("s");
        bool runPressed = Input.GetKey("left shift");
        bool jumpPressed = Input.GetKey("space");
        bool slashPressed = Input.GetMouseButtonDown(0);
        float leftWalkStrafePressed = Input.GetAxis("Horizontal");
        float rightWalkStrafePressed = Input.GetAxis("Horizontal");

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
        if (slashPressed && !SwordSelect.isSelecting)
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

        //12 - when the player walks backwards
        if (backwardPressed)
        {
            animator.SetBool(isBackingHash, true);
            animDebug("12");
        }

        //13 - when the player lets go of s
        if(!backwardPressed)
        {
            animator.SetBool(isBackingHash, false);
            animDebug("13");
        }

        //14 - when the player strafes left 
        if ((leftWalkStrafePressed < 0) && !leftWalkStrafing)
        {
            animator.SetBool(leftWalkStrafingHash, true);
            animDebug("14");
        }
        else 
            animator.SetBool(leftWalkStrafingHash, false);

        //15 - when the player strafes right
        if ((rightWalkStrafePressed > 0) && !rightWalkStrafing)
        {
            animator.SetBool(rightWalkStrafingHash, true);
            animDebug("15");
        }
        else 
            animator.SetBool(rightWalkStrafingHash, false);
    }

    void animDebug(string input)
    {
        if (animatorDebug)
        {
            Debug.Log(input);
        }

    }

   
}
