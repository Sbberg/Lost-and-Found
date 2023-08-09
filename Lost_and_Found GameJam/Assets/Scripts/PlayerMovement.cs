using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    //Movement
    public CharacterController2D controller;
    public Animator animator;


    public GameObject Fader;
    public float runSpeed = 40f;

    float HorizontalMove = 0f;
    public GameObject Layer1;
    public GameObject Layer2;
    //jump variant
    public bool Movement = true;
    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;
    public float jumpForce;
    public Rigidbody2D rb;

    public Renderer rend;
    //making sure is grounded
    private bool isGrounded;
    public bool stop;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    //bools
    bool jump = false;
    bool crouch = false;
    // Update is called once per frame
    void Update()
    {
        
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (Input.GetKeyDown(KeyCode.F) && isGrounded && HorizontalMove == 0f)
        {
            // makes it so player can't move while seeing invisible platforms and enemies
            Movement = false;
            //lets player see invisible platforms
            Layer2.transform.position = new Vector3(0, 0, 2);
            Layer1.transform.position = new Vector3(0, 0, -2);
            //Uses the fade effect funcion from another script to make screen darken
            Fader.GetComponent<FadeScript>().Fadingin();
        }
        //this is what was just changed (down)
        if (Input.GetKeyUp(KeyCode.F) )
        {
            // checks to make sure the player can't move before removing fade.
            if (Movement == false)
            {
                //Uses the fade effect funcion from another script to lighten the screen
                Fader.GetComponent<FadeScript>().Fadingin();
            }
            // makes it so player can move again
            Movement = true;
            //lets player see visible platforms
            Layer1.transform.position = new Vector3(0, 0, 2);
            Layer2.transform.position = new Vector3(0, 0, -2);
            

        }

       
        //normal movement


        if (Movement == true)
        {
            HorizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

            //sets Speed variable for walking animation
            animator.SetFloat("Speed", Mathf.Abs(HorizontalMove));

            if (isGrounded == true && Input.GetButtonDown("Jump"))
            {
                //jump variant
                isJumping = true;
                jumpTimeCounter = jumpTime;
                //original
                jump = true;
                animator.SetBool("IsJumping", true);
            }
            //jump variant
            if (Input.GetKey(KeyCode.Space))
            {
                if (jumpTimeCounter > 0)
                {
                    rb.velocity = Vector2.up * jumpForce;
                    jumpTimeCounter -= Time.deltaTime;
                    //starts jump animation
                    animator.SetBool("IsJumping", true);
                }
                else
                {
                    isJumping = false;
                }
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                isJumping = false;
            }

            //stops jump animation
            if (isGrounded == true)
            {
                animator.SetBool("IsJumping", false);
            }
        }

        
    }

    IEnumerator EyesOpen(float duration)
    {
        for (float t = 0f; t < duration; t += Time.deltaTime)
        {
            Layer2.transform.position = new Vector3(0, 0, 2);
            Layer1.transform.position = new Vector3(0, 0, -2);

            yield return null;


        }


    }
    IEnumerator EyesClose(float duration)
    {
        for (float t = 0f; t < duration; t += Time.deltaTime)
        {
            Layer2.transform.position = new Vector3(0, 0, 2);
            Layer1.transform.position = new Vector3(0, 0, -2);

            yield return null;


        }


    }
    //stops jump animation
    //public void OnLanding ()
    // {
    //     animator.SetBool("IsJumping", false);
    // }
    void FixedUpdate ()
    {
        //move our character
        controller.Move(HorizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    //void Start()
    //{
    //    DontDestroyOnLoad(gameObject);
    //}
}
