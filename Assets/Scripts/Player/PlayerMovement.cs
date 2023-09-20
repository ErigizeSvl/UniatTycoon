using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //Var Pub
    public float walkSpeed, runSpeed, rotationSpeed;
    public bool canMove;
    public Transform cameraAim;

    //Var Priv
    private Vector3 movementVector;
    private float speed;
    private CharacterController characterController;

    void Start()
    {
        speed = 0f;
        movementVector = Vector3.zero;
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (canMove)
        {
            Walk();
            Run();
            AlignPlayer();
        }

        //Gavity prov
        Gravity();
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

        //Move
        characterController.Move(movementVector * speed * Time.deltaTime);
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

    //Fn gravity prov
    void Gravity()
    {
        characterController.Move(new Vector3(0f, -4f * Time.deltaTime, 0f));
    }

}
