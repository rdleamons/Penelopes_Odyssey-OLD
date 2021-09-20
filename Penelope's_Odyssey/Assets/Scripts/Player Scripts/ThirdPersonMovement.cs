using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public Transform groundCheck;
    public LayerMask groundMask;

    public float speed = 6f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float groundDistance = 0.1f;
    public float turnSmoothTime = 0.1f;
    public bool canMove;

    private float turnSmoothVelocity;
    private bool isGrounded;
    private Vector3 velocity;

    // Notes:
    //    Doesn't work with a rigidbody, but will need to.
    //    isGrounded not working
    //    Jump needs to work with physics: 
    // I.e., player should continue in the direction they jumped, not just drop straight down if they stop moving mid-jump
    //        - RL
    private void Start()
    {
        canMove = true;
    }
    void Update()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        // Apply gravity to the controller
        velocity.y += gravity * Time.deltaTime;

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
        // Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            //velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            velocity.y = jumpHeight;
        }

        // Determine movement direction
        if (direction.magnitude >= 0.1f && canMove)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        
        // Move the controller
        if(canMove)
            controller.Move(velocity * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
            canMove = false;

        if (Input.GetMouseButtonUp(0))
            canMove = true;
    }

}