using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isRunningHash;
    int isJumpingHash;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        isJumpingHash = Animator.StringToHash("isJumping");
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isRunning = animator.GetBool(isRunningHash);
        bool forwardPressed = Input.GetKey("w");
        bool runPressed = Input.GetKey("left shift");
        //bool jumpPressed = Input.GetKey("space");

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

        if (Input.GetKeyDown("space"))
        {
            animator.SetBool(isJumpingHash, true);
        }
        if (Input.GetKeyUp("space"))
        {
            animator.SetBool(isJumpingHash, false);
        }
        
    }
}
