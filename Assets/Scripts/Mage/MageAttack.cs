using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
  Script que controla toda a parte de ataque do nosso jogador
*/

public class MageAttack : MonoBehaviour
{
    private Animator mageAnimator;    
    

    public int combo;
    public bool isAttacking;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackRange = 0.5f;
    public int attackDamage = 100;



    // Start is called before the first frame update
    void Start()
    {
        mageAnimator = GetComponent<Animator>();
        
        
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        AttackCombo();

    }

    public void AttackCombo()
    {
        if (Input.GetMouseButtonDown(0) && !isAttacking)
        {
            isAttacking = true;
            //Animação
            mageAnimator.SetTrigger("" + combo);

            
        }
    }

    public void StartCombo()
    {
        isAttacking = false;
        if (combo < 2)
        {
            combo++;                       
        }
    }

    public void FinishAttackCombo()
    {
        isAttacking = false;
        combo = 0;
    }



    /*
    public void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.gameObject.TryGetComponent<EnemyDamage>(out EnemyDamage enemyComponent))
        {
            enemyComponent.TakeDamage(1);
        }
    }


    /*public void DetectEnemy()
    {
        //Detect enemy
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);//Detecção dos inimigos

        
        //Damage
        foreach (Collider2D enemy in hitEnemies)
        {
            //_enemyDamage = FindObjectOfType(typeof(EnemyDamage)) as EnemyDamage;
            _enemyDamage.TakeDamage(attackDamage);
        }*/ 
    }
