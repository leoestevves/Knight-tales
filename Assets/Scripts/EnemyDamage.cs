using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int maxHealth;
    int currentHealth;



    // Start is called before the first frame update
    void Start()
    {       
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

        //Disable the enemy
    }
}
