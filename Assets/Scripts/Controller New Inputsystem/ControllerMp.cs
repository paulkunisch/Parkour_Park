using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using MLAPI;

//[RequireComponent(typeof(InputMaster))]
public class ControllerMp : NetworkBehaviour
{
    //Player GO
    private GameObject pl;
    //Inputsystem Controller
    public InputMaster ctrl;

    //Respawn
    private int deathzone;
    private int respawnPoint;
    [SerializeField]
    private Vector3 respawnPoint1 = new Vector3((float)329.96, (float)19.9, (float)317.19);
    [SerializeField]
    private Vector3 respawnPoint2 = new Vector3((float)-11.86, (float)19.9, (float)14);
    [SerializeField]
    private Vector3 respawnPoint3 = new Vector3((float)1612.5, (float)39.8, (float)1454.15);
    [SerializeField]
    private Vector3 respawnPoint4 = new Vector3((float)624.63, (float)107.94, (float)462.94);


    //Rigidbody of PlayerGO
    private Rigidbody rb;


    //Saves Inputs for Movement
    private Vector2 inputMove;

    //Vector for Jumps
    private float jumpVelocity;

    //Camera Position
    private Transform cameraMainTransform;

    //Check if Jump is currently Performed 
    [SerializeField]
    private Transform groundCheck;
    private float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    public float jumpheigth = 3;
    public float jumpamount = 2;
    private float jumpcount;


    //Movement speed 
    [SerializeField]
    private float acceleration = 10f;
    [SerializeField]
    private float playerRotation = 5f;

    [SerializeField]
    private float maxSpeed = 15f;
    private float currentSpeed = 15f;
    private GameObject ThirdPersonCamera;




    private void Awake()
    {
        ctrl = new InputMaster();
        cameraMainTransform = Camera.main.transform;

        //Inputs für Keyboard in Variable übertragen 
        ctrl.Player.MovementKeyboard.performed += context => inputMove = context.ReadValue<Vector2>();
        ctrl.Player.MovementKeyboard.canceled += context => inputMove = Vector2.zero;

        //Inputs von GamePad in Variable übertragen 
        ctrl.Player.MovementGamepad.performed += context => inputMove = context.ReadValue<Vector2>();
        ctrl.Player.MovementGamepad.canceled += context => inputMove = Vector2.zero;

        //Sprung ausführen 
        ctrl.Player.Jump.performed += Jump_performed;
        ctrl.Player.Jump.canceled += Jump_canceled;

        //Interaktion (noch ohne Funktion)
        ctrl.Player.Interact.performed += Interact_performed;
        ctrl.Player.Interact.canceled += Interact_canceled;

        PlayerPrefs.SetInt("deathzone", 0);
        PlayerPrefs.SetInt("respawnPoint", 1);
    }



    // Start is called before the first frame update
    void Start()
    {
        ThirdPersonCamera = GameObject.Find("Third Person Camera");

        rb = GetComponent<Rigidbody>();
        if (IsClient) 
        {
            ThirdPersonCamera.name = "Third Person Camera-c";
            Debug.Log("Rename tpc" + ThirdPersonCamera.name);
        } 

        if (!IsLocalPlayer)
        {
            ThirdPersonCamera.gameObject.SetActive(false);
        }

        deathzone = PlayerPrefs.GetInt("deathzone");
        respawnPoint = PlayerPrefs.GetInt("respawnPoint");
    }

    private void Jump_performed(InputAction.CallbackContext obj)
    {
        Debug.Log("jump");
        Debug.Log(jumpcount);
        if (isGrounded || jumpcount > 1)
        {
            Debug.Log("jump started");
            jumpVelocity = jumpheigth * Time.deltaTime;
            rb.AddForce(0f, jumpheigth, 0f, ForceMode.Impulse);
            jumpcount--;
        }
    }
    private void Jump_canceled(InputAction.CallbackContext obj)
    {

    }
    private void Interact_performed(InputAction.CallbackContext obj)
    {
        Debug.Log("Interaction performed");
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

        if (IsLocalPlayer)
        {
            deathzone = PlayerPrefs.GetInt("deathzone");
            if (transform.position.y < deathzone)
            {
                respawnPoint = PlayerPrefs.GetInt("respawnPoint");
                switch (respawnPoint)
                {
                    case 1:
                        transform.position = respawnPoint1;
                        break;
                    case 2:
                        transform.position = respawnPoint2;
                        break;
                    case 3:
                        transform.position = respawnPoint3;
                        break;
                    case 4:
                        transform.position = respawnPoint4;
                        break;


                    default:
                        transform.position = respawnPoint1;
                        break;
                }
            }

        }

    }
    private void OnCollisonEnter(Collision collision)
    {
        Debug.Log("hi");
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    void FixedUpdate()
    {
        if (inputMove != Vector2.zero)
        {

            Vector3 move = new Vector3(inputMove.x, 0f, inputMove.y) * acceleration;
            move = cameraMainTransform.forward * move.z + cameraMainTransform.right * move.x; // include current camera angle in control
            move.y = 0f;

            float targetAngle = Mathf.Atan2(inputMove.x, inputMove.y) * Mathf.Rad2Deg + cameraMainTransform.eulerAngles.y; // get input for character rotation
            Quaternion rotation = Quaternion.Euler(0f, targetAngle, 0f); // smooth transition
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * playerRotation);  // apply character rotation



            // here we get the current speed - might want to do some Debug.Log() statements and see how fast it gets going, before deciding what to set max speed to!
            currentSpeed = rb.velocity.magnitude;

            // here we are applying the forces to the rigidbody
            if (currentSpeed > maxSpeed - (maxSpeed / 4))
            {
                // we are going fast enough to limit the speed
                move = move * (maxSpeed - currentSpeed) / maxSpeed;
            }
            else //  we are not moving too fast, add full force
            {
                // move = move;
            }
            // now we actually add the force
            rb.AddForce(move, ForceMode.Force);
        }

    }
}
