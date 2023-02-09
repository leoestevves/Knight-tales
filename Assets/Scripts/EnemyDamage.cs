using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public Animator animator;
    public GameObject wolf;
    public IAWolf iAWolf;

    public int maxHealth;
    int currentHealth;
    



    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        wolf = transform.GetChild(0).gameObject;
        iAWolf = GetComponent<IAWolf>();

        currentHealth = maxHealth;
    }

        
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Enemy died");

        //Die animation
        animator.SetBool("isDead", true);

        //Disable the enemy
        wolf.GetComponent<Collider2D>().enabled = false;
        //this.enabled = false;
        TurnOff(); //Desabilita o script de movimentação do inimigo


    }
    
    public void Destroy()
    {
        Destroy(wolf.gameObject);
        
    }
    
    public void TurnOff()
    {
        iAWolf.enableScript = false;
    }
}
