using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageController : MonoBehaviour
{
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
        Debug.Log(touchRun);
  
        MageMove();

        if(touchRun < 0 && facingRight || touchRun > 0 && !facingRight)
        {
            Flip();
        }
        
    }

    private void MageMove()
    {
        mageRigidbody2D.velocity = new Vector2(moveSpeed * touchRun, mageRigidbody2D.velocity.y);
    }

    private void Flip()
    {
        facingRight = !facingRight;
        
        sprite.transform.localScale = new Vector3(-sprite.transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
}
