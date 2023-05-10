using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isRunningHash;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
    }

    // Update is called once per frame
    void Update()
    {
        bool isrunning = animator.GetBool(isRunningHash);
        bool isWalking = animator.GetBool(isWalkingHash);
        bool forwardPressed = Input.GetKey("w");
        bool runPressed = Input.GetKey("left shift");

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
        if (!isrunning && (forwardPressed && runPressed))
        {
            //then set the isRunning bool to true
            animator.SetBool(isRunningHash, true);
        }
        
        //if player is running and stops walking or running
        if (isrunning && (!forwardPressed || !runPressed))
        {
            //then set the isRunning bool to false
            animator.SetBool(isRunningHash, false);
        }
    }
}
