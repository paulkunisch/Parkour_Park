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

    private GameObject respawnPoint1;
    private GameObject respawnPoint2;
    private GameObject respawnPoint3;
    private GameObject respawnPoint4;

    // POWER-UPs
    [SerializeField]
    private GameObject boost;

    //Rigidbody of PlayerGO
    private Rigidbody rb;


    //Saves Inputs for Movement
    private Vector2 inputMove;


    //Camera Position
    private Transform cameraMainTransform;

    //Jump
    [SerializeField]
    private Transform groundCheck;
    private float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    public float jumpheigth = 3;
    public float jumpamount = 2;
    private float jumpcount;

    // Death-Sound
    private AudioSource[] Sounds; // using Workaround here since objects are spawned in as prefabs with multiple audiosources.
                                  // make sure jump is first audiosource and dying sound is second.

    //Movement speed 
    [SerializeField]
    private float acceleration = 10f;
    [SerializeField]
    private float playerRotation = 5f;
    [SerializeField]
    private float maxSpeed = 15f;
    private float currentSpeed = 15f;
    private GameObject ThirdPersonCamera;

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

        // reset current spawnPoint
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

        // Respawn
        deathzone = PlayerPrefs.GetInt("deathzone");
        respawnPoint = PlayerPrefs.GetInt("respawnPoint");

        // RespawnPoints
        respawnPoint1 = GameObject.Find("StartPoint Laver Lake");
        respawnPoint2 = GameObject.Find("respawnPoint2");
        respawnPoint3 = GameObject.Find("StartPoint Arluvior Tower");
        respawnPoint4 = GameObject.Find("respawnPoint4");

        // save values for swamp-area
        saveMaxSpeed = maxSpeed;
        saveAcceleration = acceleration;

        // Sound

        Sounds = GetComponents<AudioSource>();
    }

    private void Jump_performed(InputAction.CallbackContext obj)
    {
        if (isGrounded || jumpcount > 1)
        {
            // do jump
            Debug.Log("jump started");
            rb.AddForce(0f, jumpheigth, 0f, ForceMode.Impulse);

            // Sound
            Sounds[0].Play();


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
                Sounds[1].Play(); 
                Debug.Log(deathzone);
                respawnPoint = PlayerPrefs.GetInt("respawnPoint");
                Debug.Log(respawnPoint);
                switch (respawnPoint)
                {
                    case 1:
                        transform.position = respawnPoint1.transform.position;
                        break;
                    case 2:
                        transform.position = respawnPoint2.transform.position;
                        break;
                    case 3:
                        transform.position = respawnPoint3.transform.position;
                        break;
                    case 4:
                        transform.position = respawnPoint4.transform.position;
                        break;
                }
            }

        }

    }
    private void OnCollisonEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("POWER-UPs"))
        {
            jumpamount += 1;
            boost.SetActive(true);
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("Water"))
        {
            maxSpeed = 3;
            acceleration = 10;
        }

    }

    private void OnTriggerExit(Collider other)
{
    if (other.gameObject.CompareTag("Water"))
    {
        maxSpeed = saveMaxSpeed;
        acceleration = saveAcceleration;
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
