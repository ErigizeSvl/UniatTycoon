using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //Var Pub
    public float walkSpeed, runSpeed, jumpForce, rotationSpeed;
    public bool canMove;
    public Transform cameraAim;
    public GroundDetector groundDetector;

    //Var Priv
    private Vector3 movementVector, verticalForce;
    private bool isGrounded;
    private float speed, currentSpeed;
    private CharacterController characterController;

    void Start()
    {
        speed = 0f;
        currentSpeed = 0f;
        movementVector = Vector3.zero;
        verticalForce = Vector3.zero;
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (canMove)
        {
            Walk();
            Run();
            AlignPlayer();
            Jump();
        }

        //Gavity 
        Gravity();
        CheckGround();
    }


    //-------------------------------------
    //--------------FUNCIONES--------------
    //-------------------------------------

    //Fn Walk
    void Walk()
    {
        //Inputs WASD
        movementVector.x = Input.GetAxis("Horizontal");
        movementVector.z = Input.GetAxis("Vertical");

        //Normalize movement vector
        movementVector = movementVector.normalized;

        //Move to camera direction
        movementVector = cameraAim.TransformDirection(movementVector);

        //Smooth Velocity
        currentSpeed = Mathf.Lerp(currentSpeed, movementVector.magnitude * speed, 10f * Time.deltaTime);

        //Move
        characterController.Move(movementVector * currentSpeed * Time.deltaTime);
    }

    //Fn Run
    void Run()
    {
        //Modify speed if running
        if (Input.GetAxis("Run") > 0f)
        {
            speed = runSpeed;
        }
        else
        {
            speed = walkSpeed;
        }
    }

    //Fn align player
    void AlignPlayer()
    {
        //Align player if moving
        if (characterController.velocity.magnitude > 0f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movementVector), rotationSpeed * Time.deltaTime
            );
        }

    }

    //Fn provisional gravity 
    void Gravity()
    {
        //if not touching ground
        if (!isGrounded)
        {
            // ++ gravity speed 
            verticalForce += Physics.gravity * Time.deltaTime;
        }
        else
        {
            characterController.Move(new Vector3(0f, -2f * Time.deltaTime, 0f));
        }
        //Aplicar vertical force
        characterController.Move(verticalForce * Time.deltaTime);
    }

    //Fn jump
    void Jump()
    {
        //if its touching ground and press SPACE BAR
        if(isGrounded && Input.GetAxis("Jump") > 0f)
        {
            verticalForce = new Vector3(0f, jumpForce, 0f);
            isGrounded = false;
        }
    }

    //Fn to know if its touching ground
    void CheckGround()
    {
        isGrounded = groundDetector.GetIsGrounded();
    }

    // Fn return currentSpeed
    public float GetCurrentSpeed()
    {
        return currentSpeed;
    }

}
