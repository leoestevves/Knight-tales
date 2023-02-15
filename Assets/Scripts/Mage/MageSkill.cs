using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MageSkill : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] lightningballs;

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
        if (Input.GetMouseButton(1) && cooldownTimer > attackCooldown && mageController.canAttack())
        {
            Skill();
        }

        cooldownTimer += Time.deltaTime;
    }

    private void Skill()
    {
        anim.SetTrigger("skill");
        cooldownTimer = 0;

        
        //LightningBalls
        //lightningballs[FindLightningball()].transform.position = firePoint.position;
        //lightningballs[FindLightningball()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
        
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


