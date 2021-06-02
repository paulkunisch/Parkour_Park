using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//[RequireComponent(typeof(InputMaster))]
public class Controller : MonoBehaviour
{
    //Player GO
    private GameObject pl;
    //Inputsystem Controller
    public InputMaster ctrl;

  

    //Rigidbody of PlayerGO
    private Rigidbody rb;


    //Saves Inputs for Movement
    private Vector2 inputMove;

    //Vector for Jumps
    private float jumpVelocity;

    //Camera Position
    private Transform cameraMainTransform;

    //Check if Jump is currently Performed 
    private bool grounded = true;
    //hight of Jumps
    [SerializeField]
    private float force = 1f;
    //Movement speed 
    [SerializeField]
    private float speed = 10f;
    [SerializeField]
    private float gravity = 9.81f;
    [SerializeField]
    private float playerRotation = 1f;
    //Replace with your max speed
    [SerializeField]
    private float maxSpeed = 15f;
    



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
        //Interaaktion (noch ohne Funktion)
        ctrl.Player.Interact.performed += Interact_performed;
        ctrl.Player.Interact.canceled += Interact_canceled;
    }





    private void Jump_performed(InputAction.CallbackContext obj)
    {
        //throw new System.NotImplementedException();
        Debug.Log("jump started");
        if (grounded)
        {
            jumpVelocity += Mathf.Sqrt( force * -3.0f * gravity);    
        }
        jumpVelocity += gravity * Time.deltaTime;
        //plCtrl.Move(new Vector3(0f, jumpVelocity, 0f)*Time.deltaTime);
        rb.AddForce(0f, force, 0f,ForceMode.Impulse);
    }
    private void Jump_canceled(InputAction.CallbackContext obj)
    {
        // throw new System.NotImplementedException();
        Debug.Log("jump canceld");
    }
    private void Interact_performed(InputAction.CallbackContext obj)
    {
        //throw new System.NotImplementedException();
        Debug.Log("Interaction performed");
    }
    private void Interact_canceled(InputAction.CallbackContext obj)
    {
        //throw new System.NotImplementedException();
        Debug.Log("Interaction canceld");
    }
    private void OnEnable()
    {
        ctrl.Player.Enable();
    }

    private void OnDisable()
    {
        ctrl.Player.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        //plCtrl = gameObject.GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (inputMove != Vector2.zero)
        {
            //transform.position = transform.position + new Vector3(inputMove.x, 0f, inputMove.y)*Time.deltaTime*speed;
            //rb.AddForce(inputMove.x, 0f, inputMove.y);
            Vector3 move = new Vector3(inputMove.x, 0f, inputMove.y)*speed;
            move = cameraMainTransform.forward * move.z + cameraMainTransform.right * move.x;
            move.y = 0f;
           // plCtrl.Move(move*Time.deltaTime*speed);

            float targetAngle = Mathf.Atan2(inputMove.x, inputMove.y) * Mathf.Rad2Deg + cameraMainTransform.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0f, targetAngle, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * playerRotation);
            //rb.AddForce(move,ForceMode.Force);
            transform.position=transform.position+move*Time.deltaTime;
        }
      
    }
    private void OnCollisonEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
            Debug.Log("Ground");
        }
    }
   
   /* void FixedUpdate()
    {
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }*/
}
