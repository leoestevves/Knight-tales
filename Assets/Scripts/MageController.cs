using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MageController : MonoBehaviour
{
    private  Animator    mageAnimator; //Adicionando o animator do gameobject sprite (filho)

    private Rigidbody2D mageRigidbody2D;
    public  float       moveSpeed;
    private float       touchRun = 0.0f;

    public  Transform   groundCheck;
    public  bool        facingRight = true;
    public  bool        isGround = false;

    public  GameObject  sprite; // Pegando o gameobject filho sprite, gameobject dos sprites e animações

    public  float       jumpForce;
    //private int         numberJumps;
    //public  int         maxJumps;

    private bool isJumping = false;
    //private bool isFalling = false;
    //private bool isLanding = false;


    

    // Start is called before the first frame update
    void Start()
    {
        mageAnimator = GetComponent<Animator>();
        mageRigidbody2D = GetComponent<Rigidbody2D>(); //Adicionando Rigidbody a variável
        sprite = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        isGround = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")); //Se tocar em algum tile colider, o isGround vira true
        mageAnimator.SetBool("IsGrounded", isGround); //Passando o true do isGround para o IsGrounded do animator

        touchRun = Input.GetAxisRaw("Horizontal");
        MoveMage();

        SetAnimations();

     
        

        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            JumpMage();
        }
        
    }

    

    void MoveMage()
    {
        
        mageRigidbody2D.velocity = new Vector2(moveSpeed * touchRun, 0f);
        //mageAnimator.SetBool("Running", mageRigidbody2D.velocity.x != 0);

        if (touchRun < 0 && facingRight || touchRun > 0 && !facingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        
        sprite.transform.localScale = new Vector3(-sprite.transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    void JumpMage()
    {
        if (isGround)
        {
            Debug.Log(isGround);
            mageAnimator.SetBool("IsJumping", true);            
        }
        Debug.Log(isGround + "olá");
               
    }

    /*void JumpMage()
    {
        if (isGround)
        {
            numberJumps = 0;
        }

        if (numberJumps < maxJumps)
        {
            isGround = false;
            numberJumps++;
            mageAnimator.SetBool("IsJumping", !isGround);
        }
        isJumping = false;
    }*/

    public void AddForceJumpMage()
    {
        
        mageRigidbody2D.AddForce(new Vector2(0f, jumpForce));
        
        isJumping = false;
        Debug.Log(isJumping);
        mageAnimator.SetBool("IsJumping", false);
    }

    void SetAnimations()
    {
        mageAnimator.SetFloat("EixoY", mageRigidbody2D.velocity.y);
        mageAnimator.SetBool("Running", mageRigidbody2D.velocity.x != 0 && isGround);
        //mageAnimator.SetBool("IsJumping", !isGround);
    }

}
