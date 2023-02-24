using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.TextCore.Text;
using UnityEngine;

/*
 Script de movimentação e parte básico do jogador
*/

public class MageController : MonoBehaviour
{
    private Animator       mageAnimator;
    private Rigidbody2D    mageRigidbody2D;

    [Header ("Components")]
    [SerializeField] private Transform  groundCheck;
    [SerializeField] private GameObject sprite; // Pegando o gameobject filho sprite, gameobject dos sprites e animações

    [Header ("References")]
    [SerializeField] private UIManager uiManager;

    [Header ("Movement")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private bool facingRight = true;
    [SerializeField] private bool isGround = false;
    private float touchRun = 0.0f;    

    [Header ("Jump attributes")]
    [SerializeField] private float    jumpForce;
    //[SerializeField] private bool     isJumping       = false;
    [SerializeField] private bool     antecipateJump  = false;
    [SerializeField] private bool     isLanding       = false;

    //[SerializeField] private Transform attackPoint;
    

    // Start is called before the first frame update
    void Start()
    {
        mageAnimator    = GetComponent<Animator>();
        mageRigidbody2D = GetComponent<Rigidbody2D>(); //Adicionando Rigidbody a variável
        sprite          = transform.GetChild(0).gameObject;        
    }

    // Update is called once per frame
    void Update()
    {
        isGround = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")); //Se tocar em algum tile colider, o isGround vira true
        isLanding = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        mageAnimator.SetBool("IsGrounded", isGround); //Passando o true do isGround para o IsGrounded do animator
        mageAnimator.SetBool("IsLanding", isLanding);


        if (uiManager.gameIsPaused == false)
        {
            touchRun = Input.GetAxisRaw("Horizontal");
            MoveMage();

            SetAnimations();

            if (Input.GetButtonDown("Jump"))
            {
                //isJumping = true;
                StartCoroutine(JumpMage());
            }
        }
                    
    }

    

    void MoveMage()
    {        
        mageRigidbody2D.velocity = new Vector2(moveSpeed * touchRun, mageRigidbody2D.velocity.y);

        if (touchRun < 0 && facingRight || touchRun > 0 && !facingRight)
        {
            Flip();
        }


    }

    void Flip()
    {
        facingRight = !facingRight;        
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        
    }

    IEnumerator JumpMage()
    {
        if (isGround)
        {
            antecipateJump = true;                     
            yield return new WaitForSeconds(0.30f);            
            antecipateJump = false;           
            mageRigidbody2D.velocity = Vector2.up * jumpForce;
            //isJumping = true;
        }        
    }


    void SetAnimations()
    {        
        mageAnimator.SetFloat("EixoY", mageRigidbody2D.velocity.y);
        mageAnimator.SetBool("Running", mageRigidbody2D.velocity.x != 0 && isGround);
        mageAnimator.SetBool("IsJumping", !isGround);
        mageAnimator.SetBool("AntecipateJump", antecipateJump);
        
    }


    public bool canAttack()
    {
        return touchRun == 0 && isGround;
    }


    //Transformando o player em filho do objeto plataforma, dessa forma o player se movimenta junto com a plataforma
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Platform":
                this.transform.parent = collision.transform;
                break;
        }
    }

    //Retirando o player como filho do objeto plataforma
    private void OnCollisionExit2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Platform":
                this.transform.parent = null;
                break;
        }
    }
}
