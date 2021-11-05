using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    

    public float speed;
    private float speedVal;
    public float jumpHeight;
   
    private float turnSmoothTime = 0.1f;
    public float gravMultiplier;
    private bool canMove;
    private GameManager GameManager;

    private float turnSmoothVelocity;
    private Vector3 velocity;

    public Transform groundCheck;
    private float groundDistance = 0.1f;
    public LayerMask groundMask;
    bool isGrounded;

    private Animator anim;

    // Notes:
    //    Doesn't work with a rigidbody, but will need to.
    //    Jump needs to work with physics: 
    // I.e., player should continue in the direction they jumped, not just drop straight down if they stop moving mid-jump
    //        - RL
    private void Start()
    {
        canMove = true;
        speedVal = speed;
        anim = GetComponent<Animator>();
        GameManager = GetComponent<GameManager>();
    }


    void Grounded()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
    }

    void Jump()
    {

        // Jump
        //if (Input.GetButtonDown("Jump") && controller.isGrounded)
        if (Input.GetButtonDown("Jump") && velocity.y < 0)
        {
            velocity.y = jumpHeight + (Physics.gravity.y * gravMultiplier * Time.deltaTime);
        }
    }


    void Sprint()
    {
        //Sprint
        // if (Input.GetKeyDown(KeyCode.LeftShift) && controller.isGrounded)
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed *= 2.5f;
            GameManager.sub = 2;
        }

        //if (Input.GetKeyUp(KeyCode.LeftShift) && controller.isGrounded)
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = speedVal;
            GameManager.sub = 1;
        }
    }

    void Move()
    {

        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        // Determine movement direction
        if (direction.magnitude >= 0.1f && canMove)
        {

            anim.SetBool("isWalking", true);

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        else anim.SetBool("isWalking", false);

        // Move the controller
        controller.Move(velocity * Time.deltaTime);
    }

    void Update()
    {
        // Apply gravity to the controller
        velocity.y += Physics.gravity.y * gravMultiplier * Time.deltaTime;
       

        Jump();

        Sprint();

        Move();

        if (Input.GetMouseButtonDown(0))
            canMove = false;

        if (Input.GetMouseButtonUp(0))
            canMove = true;

       //Grounded();
    }
        

}