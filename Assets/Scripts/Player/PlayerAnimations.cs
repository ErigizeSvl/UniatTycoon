using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    //Pub Var
    public PlayerMovement playerMovement;
    public GroundDetector groundDetector;

    //Priv Var
    private float speed;
    private bool isGrounded;

    private Animator animator;

    void Start()
    {
        speed = 0f;
        isGrounded = true;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        CheckGround();
        CheckSpeed();
        SetParameters();
    }

    public void SetParameters()
    {
        animator.SetFloat("Speed", speed);
        animator.SetBool("isGrounded", isGrounded);
    }

    public void CheckSpeed()
    {
        speed = playerMovement.GetCurrentSpeed();
    }

    public void CheckGround()
    {
        isGrounded = groundDetector.GetIsGrounded();
    }
}
