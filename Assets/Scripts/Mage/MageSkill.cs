using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageSkill : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
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
    }


}


