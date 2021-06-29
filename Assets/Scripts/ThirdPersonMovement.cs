using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author: David Hasenhüttl/25.04.2021
/*
 *              IMPORTANT: DEPRECATED VERSION!
 *              this is the old Version of our Player-controller.
 *              
 *              While this script is working rather fine in 
 *              combination with the cinemachine camera and the 
 *              unity charactercontroller,
 *              
 *              it is currently NOT used in the scope of our project,
 *              since the implemented charactercontroller by unity
 *              was missing features (collision) and we wanted to 
 *              switch to the new input system. 
 * 
 */
public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller; // add charactercontroller to player
    public Transform cam;                   // add cinemachine camera to scene
    Vector3 velocity;

    // setting variables
    public float speed = 20;
    public float jumpheigth = 3;
    public float jumpamount = 2;
    public float jumpcount;

    public float turnSmoothTime = 0.05f;
    public float gravity = -20;
    float turnSmoothVelocity; 

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    void Awake()
    {        
    jumpcount = jumpamount; // jump reset
    }


    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); // is player currently on the ground?
                                                                                            // set layer of colliding gameobject to layer in groundmask

        if(isGrounded && velocity.y < 0) // handling jumps
        {
            velocity.y = -2f;
            jumpcount = jumpamount;
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized; // handling speed when moving in both directions

        if (direction.magnitude >= 0.1f)
        {
            // rotate according to camera position and current player rotation
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            // move towards player rotation
            Vector3 moveDir = Quaternion.Euler(0f, angle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }


        if(Input.GetButtonDown("Jump") && jumpcount > 0) // jump!
        {
            velocity.y = Mathf.Sqrt(jumpheigth * -2f * gravity);
            jumpcount--;
        }
        velocity.y += gravity * Time.deltaTime; // gravity
        controller.Move(velocity * Time.deltaTime); // normalizing speed
    }
 }