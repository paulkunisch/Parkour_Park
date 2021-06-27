using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

// Author: David Hasenhüttl, Paul Kunisch
public class Controller : MonoBehaviour
{
    // Inputsystem Controller
    public InputMaster ctrl;

    // POWER-UPs
    [SerializeField]
    private GameObject boost;

    //Rigidbody of PlayerGO
    private Rigidbody rb;


    // Saves Inputs for Movement
    private Vector2 inputMove;


    // Camera Position
    private Transform cameraMainTransform;

    // Jumps 
    [SerializeField]
    private Transform groundCheck; 
    private float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    public float jumpheigth = 3;
    public float jumpamount = 2;
    private float jumpcount;

    // Jump-Sound
    [SerializeField]
    private AudioClip jumpSound; // Add your Audio Clip on this gameobject as well

    // Movement speed 
    [SerializeField]
    private float acceleration = 10f;
    [SerializeField]
    private float playerRotation = 5f;
    [SerializeField]
    private float maxSpeed = 15f;
    private float currentSpeed = 15f;
    private float saveMaxSpeed;
    private float saveAcceleration;


    private void Awake()
    {
        ctrl = new InputMaster();
        cameraMainTransform = Camera.main.transform;

        // Inputs Keyboard save into variables
        ctrl.Player.MovementKeyboard.performed += context => inputMove = context.ReadValue<Vector2>();
        ctrl.Player.MovementKeyboard.canceled += context => inputMove = Vector2.zero;

        // Inputs GamePad save into variables 
        ctrl.Player.MovementGamepad.performed += context => inputMove = context.ReadValue<Vector2>();
        ctrl.Player.MovementGamepad.canceled += context => inputMove = Vector2.zero;

        // Jump action
        ctrl.Player.Jump.performed += Jump_performed;
        ctrl.Player.Jump.canceled += Jump_canceled;

        // Interaction (reserved for future use)
        ctrl.Player.Interact.performed += Interact_performed;
        ctrl.Player.Interact.canceled += Interact_canceled;
    }



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // set boost
        if(SceneManager.GetActiveScene().name == "Level 1_King's Castle")
        {
            PlayerPrefs.SetInt("boost", 0);
        }
        else if (PlayerPrefs.GetInt("boost") > 0)
        {
            jumpamount += PlayerPrefs.GetInt("boost");
            boost.SetActive(true);
        }

        // save values for swamp-area
        saveMaxSpeed = maxSpeed;
        saveAcceleration = acceleration;

        // Jump-Sound
        GetComponent<AudioSource>().clip = jumpSound;
    }

    private void Jump_performed(InputAction.CallbackContext obj)
    {
        // check if jump is allowed
        if (isGrounded || jumpcount > 1)
        {
            // do jump
            Debug.Log("jump started");
            rb.AddForce(0f, jumpheigth, 0f, ForceMode.Impulse);

            // Sound
            GetComponent<AudioSource>().Play();

            jumpcount--;
        }
    }
    private void Jump_canceled(InputAction.CallbackContext obj)
    {
    }
    private void Interact_performed(InputAction.CallbackContext obj)
    {
        Debug.Log("Interaction performed"); // saved for future use
    }
    private void Interact_canceled(InputAction.CallbackContext obj)
    {
    }

    private void OnEnable()
    {
        ctrl.Player.Enable();
    }

    private void OnDisable()
    {
        ctrl.Player.Disable();
    }


    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded)
        {
            jumpcount = jumpamount;
        }
      
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("POWER-UPs")) // increase jump amount of players by 1
        {
            PlayerPrefs.SetInt("boost", PlayerPrefs.GetInt("boost") + 1);
            jumpamount += 1;
            boost.SetActive(true);
            other.gameObject.SetActive(false);
        }

        else if (other.gameObject.CompareTag("Water")) // swamp water slows us down
        {
            maxSpeed = 3;
            acceleration = 10;
        }

    }

    private void OnTriggerExit(Collider other)
    {        
        if (other.gameObject.CompareTag("Water")) // return to original speed
        {
            maxSpeed = saveMaxSpeed;
            acceleration = saveAcceleration;
        }
    }

    void FixedUpdate()
    {
        if (inputMove != Vector2.zero )
        {

            Vector3 move = new Vector3(inputMove.x, 0f, inputMove.y) * acceleration;
            move = cameraMainTransform.forward * move.z + cameraMainTransform.right * move.x; // include current camera angle in control
            move.y = 0f;

            float targetAngle = Mathf.Atan2(inputMove.x, inputMove.y) * Mathf.Rad2Deg + cameraMainTransform.eulerAngles.y; // get input for character rotation
            Quaternion rotation = Quaternion.Euler(0f, targetAngle, 0f); // smooth transition
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * playerRotation);  // apply character rotation


            
            // here we get the current speed - might want to do some Debug.Log() statements and see how fast it gets going, before deciding what to set max speed to!
            currentSpeed = rb.velocity.magnitude;
            // Debug.Log(currentSpeed);

            // here we are applying the forces to the rigidbody. 
            //if (currentSpeed > maxSpeed - (maxSpeed / 4)) // linear acceleration until 75% of speed
            {
                // we are going fast enough to limit the speed
                move = move * (maxSpeed - currentSpeed) / maxSpeed;
            }
            /*else //  we are not moving too fast, add full force
            {
                 move = move;
            }*/

            // now we actually add the force
            rb.AddForce(move, ForceMode.Force);
        }

    }
}
