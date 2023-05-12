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

        //when player presses w
        if (!isWalking && forwardPressed)
        {
            //then set the isWalking bool to true
            animator.SetBool(isWalkingHash, true);
        }

        //when player is not pressing w
        if (isWalking && !forwardPressed)
        {
            //then set the isWalking bool to false
            animator.SetBool(isWalkingHash, false);
        }

        //if player is not running and walking and presses left shift
        if (!isRunning && (forwardPressed && runPressed))
        {
            //then set the isRunning bool to true
            animator.SetBool(isRunningHash, true);
        }
        
        //if player is running and stops walking or running
        if (isRunning && (!forwardPressed || !runPressed))
        {
            //then set the isRunning bool to false
            animator.SetBool(isRunningHash, false);
        }

        if (jumpPressed)
        {
            animator.SetBool(isJumpingHash, true);
            StartCoroutine(MyCoroutine());
            animator.SetBool(isJumpingHash, false);
            Debug.Log("jump");
        }

        if (slashPressed)
        {
            animator.SetBool(isSlashingHash, true);
            StartCoroutine(MyCoroutine());
            animator.SetBool(isSlashingHash, false);
            Debug.Log("slash");
        }

        if (highSpinPressed)
        {
            animator.SetBool(highSpinHash, true);
            StartCoroutine(MyCoroutine());
            StartCoroutine(MyCoroutine());
            StartCoroutine(MyCoroutine());
            StartCoroutine(MyCoroutine());
            StartCoroutine(MyCoroutine());
            StartCoroutine(MyCoroutine());
            animator.SetBool(highSpinHash, false);
            Debug.Log("high spin");
        }
    }

    IEnumerator MyCoroutine()
    {
        yield return new WaitForSeconds(0.3f); // Wait for 0.3 seconds

        // Do some work here after the delay...
    }

}
