using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [Header("Object storage")]
    //Stores enemy script game object
    public AI_Enemy enemy;

    [Header("Movement")]
    private float moveSpeed;
    public float sprintSpeed;
    public float walkSpeed;


   
    public float groundDrag;
    
    [Header("Crouching")]
    public float crouchSpeed;
    public float crouchYScale;
    private float startYScale;
    //Keeps track of weather charecter is crouching
    private bool isCrouching;



   [Header("Keybinds")]
    public KeyCode crouchKey = KeyCode.Space;
    public KeyCode sprintKey = KeyCode.LeftShift;
    
    
    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;




    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;


   
    



   
    
    public MovementState state;
    public enum MovementState
    {
        sprinting,
        walking,
        crouching
    }
 

    private void Start()
    {
        rb =GetComponent<Rigidbody>();
        rb.freezeRotation = true ;

        startYScale = transform.localScale.y;

      

      
        
    }

    private void Update()
    {
        //ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        MyInput();
        SpeedControl();
        StateHandler();

        //Handle Drag
        if(grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }
        
        //start crouch
        if(Input.GetKeyDown(crouchKey))
        {
            transform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z);
            rb.AddForce(Vector3.down * 5f,ForceMode.Impulse);
            //Update booleen on enemy to inform player is hidding
            enemy.isHiding = true;
        }

        //stop crouch
        if(Input.GetKeyUp(crouchKey))
        {
            transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z);
            //Update booleen on enemy to inform player is hidding
            enemy.isHiding = false;
        }
 

    }

    private void FixedUpdate()
    {
        MovePlayer();
    }



    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

    }
 
    
    //bug- crouchSpeed not working
    private void StateHandler()
    {

        //mode - Crouching
        if(grounded && Input.GetKey(crouchKey))
        {
            state = MovementState.crouching;
            moveSpeed = crouchSpeed;
        }
        //mode - Sprinting
        if(grounded && Input.GetKey(sprintKey))
        {
            state = MovementState.sprinting;
            moveSpeed = sprintSpeed;
            //Set chase speed of enemy 
            enemy.setChaseSpeed(true);

             
        }
          //mode - walking
        else if(grounded)
        {
            state = MovementState.walking;
            moveSpeed = walkSpeed;
        }


    }

    private void MovePlayer()
   {
      

        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
   }

   private void SpeedControl()
   {
       Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

       //Limit velocity if needed
       if(flatVel.magnitude > moveSpeed)
       {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
       }
   }



}
