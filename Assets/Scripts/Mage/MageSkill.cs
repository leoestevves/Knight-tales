using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MageSkill : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] lightningballs;

    [Header("References")]
    [SerializeField] private UIManager uiManager;

    private Animator anim;
    private MageController mageController;
    private float cooldownTimer = Mathf.Infinity;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        mageController = GetComponent<MageController>();
    }

    private void Update()
    {
        if(uiManager.gameIsPaused == false)
        {
            if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown && mageController.canAttack())
            {
                Skill();
            }

            cooldownTimer += Time.deltaTime;
        }
        
    }

    private void Skill()
    {
        anim.SetTrigger("skill");
        cooldownTimer = 0;        
        
    }

    
    public void ActivateLightningBall()
    {
        lightningballs[FindLightningball()].transform.position = firePoint.position;
        lightningballs[FindLightningball()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }
    

    private int FindLightningball()
    {
        for (int i = 0; i < lightningballs.Length; i++)
        {
            if (!lightningballs[i].activeInHierarchy)
                return i;
        }

        return 0;
    }


}


