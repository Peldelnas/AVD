using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class Player2DControl : MonoBehaviour

{
    public CharacterController2D controller;
    public Animator animator;
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    public bool crouch = false;
    public float Gravity2D = -30f;
    private Rigidbody2D rigid;
    private GameObject door;
    private bool canMove = true;



    private void Start()

    {

        Physics2D.gravity = new Vector2(0, Gravity2D);
        rigid = gameObject.GetComponent<Rigidbody2D>();
        door = GameObject.FindGameObjectWithTag("door");

    }



    void Update()

    {

        if (canMove)
        {

            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;


         animator.SetFloat("Speed", Mathf.Abs(horizontalMove));


        
            if (Input.GetButtonDown("Jump"))

            {

                jump = true;

                animator.SetBool("IsJumping", true);

            }



            if (Input.GetButton("Crouch"))

            {

                crouch = true;
                animator.SetBool("IsCrouching", true);

            }

            else if (Input.GetButtonUp("Crouch"))

            {

                crouch = false;
                animator.SetBool("IsCrouching", false);
            }
            animator.SetFloat("SpeedY", rigid.velocity.y);
        }
                

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("door"))
        {
            if(Input.GetKey(KeyCode.E))
            {

                StartCoroutine(doorCoroutine());
                
            }
        }
    }
    IEnumerator doorCoroutine()
    {
        canMove = false;
        door.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(1);
        door.GetComponent<SpriteRenderer>().enabled = false;
    }

    public void OnLanding()

    {

         animator.SetBool("IsJumping", false); 

    }

    public void OnCrouching(bool isCrouching) { 
        animator.SetBool("IsCrouching", isCrouching);
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

}