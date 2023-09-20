using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Var Pub
    public float sensibility;
    public Transform targetObj, cameraAimY;
    public bool canRotate;

    //Var Priv
    private float xRotation, yRotation;

    void Start()
    {
        //Initialice var
        xRotation = 0f;
        yRotation = 0f;
    }

    void Update()
    {
        //If can rotate
        if (canRotate)
        {
            Rotate();
        }
        //Follow objective
        FollowTarget();
    }


    //-------------------------------------
    //--------------FUNCIONES--------------
    //-------------------------------------

    //Fn Rotate
    void Rotate()
    {
        //Get mouse inputs
        xRotation += Input.GetAxis("Mouse X") * Time.deltaTime * sensibility;
        yRotation += Input.GetAxis("Mouse Y") * Time.deltaTime * sensibility;

        //Limit y rotation
        yRotation = Mathf.Clamp(yRotation, -65, 65);

        //Rotate camera components
        transform.localRotation = Quaternion.Euler(0f, xRotation, 0f);
        cameraAimY.localRotation = Quaternion.Euler(-yRotation, 0f, 0f);
    }

    //Fn Follow
    void FollowTarget()
    {
        transform.position = targetObj.position;
    }
}
