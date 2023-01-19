using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageController : MonoBehaviour
{
    public  Animator    mageAnimator; //Adicionando o animator do gameobject sprite (filho)

    private Rigidbody2D mageRigidbody2D;
    public  float       moveSpeed;
    private float       touchRun = 0.0f;

    public  Transform   groundCheck;
    public  bool        facingRight = true;

    public  GameObject  sprite; // Pegando o gameobject filho sprite, gameobject dos sprites e animações

    

    // Start is called before the first frame update
    void Start()
    {
        
        mageRigidbody2D = GetComponent<Rigidbody2D>(); //Adicionando Rigidbody a variável
        sprite = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        touchRun = Input.GetAxisRaw("Horizontal");  
        MoveMage();

        SetAnimations();


        if(touchRun < 0 && facingRight || touchRun > 0 && !facingRight)
        {
            Flip();
        }
        
    }

    void MoveMage()
    {
        mageRigidbody2D.velocity = new Vector2(moveSpeed * touchRun, mageRigidbody2D.velocity.y);
    }

    void Flip()
    {
        facingRight = !facingRight;
        
        sprite.transform.localScale = new Vector3(-sprite.transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    

    void SetAnimations()
    {
        
        mageAnimator.SetBool("Running", mageRigidbody2D.velocity.x != 0);
    }

}
