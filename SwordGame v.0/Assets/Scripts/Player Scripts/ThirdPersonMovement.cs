using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    private float speed = 8f;

    public float strafeSpeed = 5f; 
    public float walkSpeed = 8f;
    public float runSpeed = 24f; 
    public float slideSpeed = 30f; 
    
    //private bool canJump;
    //private bool onGround; 
    public float jumpForce = 10f;
    public float gravity = -9.81f;
    [SerializeField] public float gravityMultiplier = 1.0f;
    Vector3 velocity;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public bool debugFlag = false; 
    private bool slideCoolDown = false; 
    private float slideCoolDownTimer = 2f; 
    public float slideCoolDownDur = 2f; 
    private bool isRun = false; 
    private bool isSlide = false; 
    private bool isStrafingLeft = false;
    private bool isStrafingRight = false;
    public float slideDur = 2f;
    private float slideTimer = 0; 


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //adds gravity to the player
        controller.Move(velocity * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
 
        //took me an hour to find out how to implement jump
        playerJump(); 

        //this is getting the input hopefully Unity doesn't hoe us because this method is kind of "outdated"
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        
        //makes a vector that lets us move in the X and Z with normalized movement
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        //makes it to where player moves in the direction they're facing IF AND ONLY IF they are actually moving
        if (direction.magnitude >= 0.1f && !attackPause.isAnimation) 
        {
            //arctan function dictates which direction/angle our character is moving in and it should in turn rotate him the correct amount
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            //this is just to smooth the turning movements
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            //some complex ass movement direction bullshit
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            //Strafe
            playerStrafe();
            
            //shift to sprint but only when on the ground (no midair movement increase...theoretically)
            playerRun(); 
            
            //Sliding Code
            //playerSlide(); 

            //moves mr dontai west in the direction our camera is facing
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
    }

    void FixedUpdate()
    {
        /*
        if(controller.isGrounded && Input.GetKeyUp(KeyCode.Space))
        {
            velocity.y += jumpForce;
        }
        */
    }

    void playerSlide()
    {
        if(isRun && controller.isGrounded && Input.GetKeyDown(KeyCode.V) && !isSlide && speed == runSpeed && !slideCoolDown)
            {
                speed = slideSpeed; 
                slideTimer = slideDur;
                isSlide = true; 
                if (debugFlag)
                    Debug.Log("slide start");
            }
            if (isSlide && controller.isGrounded)
            {
                slideTimer -= Time.deltaTime; 
                if (slideTimer < 0)
                {
                    isSlide = false;
                    slideCoolDown = true;
                    slideCoolDownTimer = slideCoolDownDur; 
                    slideTimer = slideDur;
                    speed = runSpeed;
                    if (debugFlag)
                        Debug.Log("slide end");
                }
            }
            if (isSlide && !controller.isGrounded)
            {
                isSlide = false;
                slideCoolDown = true; 
                slideCoolDownTimer = slideCoolDownDur; 
                slideTimer = slideDur; 
                if (debugFlag)
                    Debug.Log("slide jump");
            }
            if(controller.isGrounded && speed == slideSpeed && !isSlide)
            {
                if(isRun)
                    speed = runSpeed;
                else
                    speed = walkSpeed; 
            }
            if (slideCoolDown)
            {
                if (slideCoolDownTimer < 0)
                {
                    slideCoolDown = false; 
                }
                slideCoolDownTimer -= Time.deltaTime; 
            }
    }

    void playerJump()
    {
        if (controller.isGrounded && Input.GetButtonDown("Jump") && !attackPause.isAnimation)
        {
            float jumpVelocity = Mathf.Sqrt(jumpForce * -2f * gravity);
            velocity.y = jumpVelocity;
            Debug.Log("jump");
        }
    }

    
    void playerRun()
    {
        if (Input.GetButtonDown("Run") && controller.isGrounded)
        {
            isRun = true; 
            speed = runSpeed;
            if (debugFlag)
                Debug.Log("is running");
        }
        if (Input.GetButtonUp("Run") && controller.isGrounded && isRun)
        {
            isRun = false;
            speed = walkSpeed; 
            if (debugFlag)
                Debug.Log("is not running");
        }
    }

    void playerStrafe()
    {
        if(!Input.GetKeyDown(KeyCode.W))
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            if (horizontalInput < 0)
            {
                isStrafingLeft = true;
                isStrafingRight = false;
                if (debugFlag)
                    Debug.Log("Left Strafe");
            }
            else if (horizontalInput > 0)
            {
                isStrafingLeft = false;
                isStrafingRight = true;
                if (debugFlag)
                    Debug.Log("Right Strafe");
            }
            else
            {
                isStrafingLeft = false;
                isStrafingRight = false;
                // Stop moving the player
            }
        }

         if(!isRun && controller.isGrounded && !isSlide && !isStrafingLeft && !isStrafingRight)
         {
            speed = walkSpeed;
            //Debug.Log("Walking");
         }

        if(!isRun && controller.isGrounded && !isSlide && (isStrafingLeft || isStrafingRight))
        {
            speed = strafeSpeed;
        }
        else if(!isRun && controller.isGrounded && !isSlide)
        {
            speed = walkSpeed;
        }
    }
}
