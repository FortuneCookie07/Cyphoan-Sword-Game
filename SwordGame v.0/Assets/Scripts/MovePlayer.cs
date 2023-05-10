using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float speed = 5f; 
    public Rigidbody rb;
    
    public int jumpForce = 50;
    private bool canJump;
    private bool onGround; 
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // In Update we get the Input for left, right, up and down and put it in the variable 'movement'...
        // We only get the input of x and z, y is left at 0 as it's not required
        // 'Normalized' diagonals to prevent faster movement when two inputs are used together
        //movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        if(Input.GetKeyUp(KeyCode.Space) && onGround)
        {
            canJump = true;
            onGround = false;
        }

    }

    void FixedUpdate()
    {
        // We call the function 'moveCharacter' in FixedUpdate for Physics movement
        //rb.velocity = direction * speed * Time.deltaTime;

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        rb.MovePosition(transform.position + movement * Time.deltaTime * speed);

        if(canJump)
        {
            canJump = false;
            rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
        }
    }    

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("terrain_t"))
        {
            onGround = true; 
        }
    }
}
