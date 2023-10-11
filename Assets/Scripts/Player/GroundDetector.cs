using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{ 
 //Public Var
    public float radius;
    public LayerMask detectedLayer;


//Priv var
    private bool isGrounded;


    void Update()
    {
     CheckGround();
    }

    //Fn detect ground
    void CheckGround()
    {
        isGrounded = Physics.CheckSphere(transform.position, radius, detectedLayer);
    }

    //Fn return value isGround
    public bool GetIsGrounded()
    {
        return isGrounded;
    }   
}
