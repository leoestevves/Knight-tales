using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.TextCore.Text;
using UnityEngine;

public class MageController : MonoBehaviour
{
    private  Animator    mageAnimator; //Adicionando o animator do gameobject sprite (filho)
    private Animation mageAnimation;

    private Rigidbody2D mageRigidbody2D;
    public  float       moveSpeed;
    private float       touchRun = 0.0f;

    public  Transform   groundCheck;
    public  bool        facingRight = true;
    public  bool        isGround = false;

    public  GameObject  sprite; // Pegando o gameobject filho sprite, gameobject dos sprites e animações

    public  float       jumpForce;
    

    public bool isJumping = false;
    public bool antecipateJump = false;
    public bool isLanding = false;

    
    public int combo;
    public bool isAttacking;

    public float fixAnimation = 0.2f;

    

    // Start is called before the first frame update
    void Start()
    {
        mageAnimation = GetComponent<Animation>();
        mageAnimator = GetComponent<Animator>();
        mageRigidbody2D = GetComponent<Rigidbody2D>(); //Adicionando Rigidbody a variável
        sprite = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        isGround = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")); //Se tocar em algum tile colider, o isGround vira true
        isLanding = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        mageAnimator.SetBool("IsGrounded", isGround); //Passando o true do isGround para o IsGrounded do animator
        mageAnimator.SetBool("IsLanding", isLanding);
        

        touchRun = Input.GetAxisRaw("Horizontal");
        MoveMage();

        SetAnimations();        

        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            StartCoroutine(JumpMage());            
        }

        AttackCombo();
       



        
    }

    

    void MoveMage()
    {
        if (isAttacking == false)
        {
            mageRigidbody2D.velocity = new Vector2(moveSpeed * touchRun, mageRigidbody2D.velocity.y);

            if (touchRun < 0 && facingRight || touchRun > 0 && !facingRight)
            {
                Flip();
            }
        }
        
    }

    void Flip()
    {
        facingRight = !facingRight;        
        sprite.transform.localScale = new Vector3(-sprite.transform.localScale.x, transform.localScale.y, transform.localScale.z);
        //sprite.transform.position = new Vector3(-sprite.transform.position.x, transform.position.y, transform.position.z);
    }

    IEnumerator JumpMage()
    {
        if (isGround)
        {
            antecipateJump = true;                     
            yield return new WaitForSeconds(0.30f);            
            antecipateJump = false;           
            mageRigidbody2D.velocity = Vector2.up * jumpForce;
            isJumping = true;
        }        
    }


    void SetAnimations()
    {        
        mageAnimator.SetFloat("EixoY", mageRigidbody2D.velocity.y);
        mageAnimator.SetBool("Running", mageRigidbody2D.velocity.x != 0 && isGround);
        mageAnimator.SetBool("IsJumping", !isGround);
        mageAnimator.SetBool("AntecipateJump", antecipateJump);
        
    }

   public void AttackCombo()
    {
        if (Input.GetMouseButtonDown(0) && !isAttacking)
        {
            isAttacking = true;
            mageAnimator.SetTrigger("" + combo);
        }
    }
    
    public void StartCombo()
    {
        isAttacking = false;
        if(combo < 2)
        {
            combo++;
        }
    }

    public void FinishAttackCombo()
    {
        isAttacking = false;
        combo = 0;
    }

    public void FlipSprite()
    {
        Debug.Log(facingRight);
        if(facingRight == false)
        {
            sprite.transform.position = new Vector2(sprite.transform.position.x - fixAnimation, sprite.transform.position.y);
            
            Debug.Log(sprite.transform.position.x);
        }
        
    }
}
