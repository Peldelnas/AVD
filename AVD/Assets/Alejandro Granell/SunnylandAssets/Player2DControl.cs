using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class Player2DControl : MonoBehaviour

{
    public CharacterController2D controller;
    public Animator animator;
    public float runSpeed = 1f;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    public float Gravity2D = 0f;

    private void ChangeGravity(float g)
    {



    }



    private void Start()

    {

        Physics2D.gravity = new Vector2(0, Gravity2D);

    }



    void Update()

    {



        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;



        // animator.SetFloat("Speed", Mathf.Abs(horizontalMove)); 



        if (Input.GetButtonDown("Jump"))

        {

            jump = true;

            //  animator.SetBool("IsJumping", true); 

        }



        if (Input.GetButtonDown("Crouch"))

        {

            crouch = true;

        }

        else if (Input.GetButtonUp("Crouch"))

        {

            crouch = false;

        }

        

    }



    public void OnLanding()

    {

        // animator.SetBool("IsJumping", false); 

    }

}