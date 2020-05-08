﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;
    public Transform attackPoint;
    public Transform swordAttackPoint;
    public float attackRange = 0.1f;
    public float swordAttackRange = 0.15f;
    public LayerMask enemyLayers;
    public int attackDamage = 10;

    public GameObject bulletPrefab;
    public GameObject iceCreamPrefab;
    public GameObject pie;
    public GameObject sword;
    public GameObject iceCream;
    public Sword2 sword2;

    public bool hasPie;
    public bool hasSword;
    public bool hasIceCream;

    public Transform firePoint;


    private void Start()
    {
        pie.SetActive(false);
        sword.SetActive(false);
        iceCream.SetActive(false);
        hasPie = false;
        hasSword = false;
        hasIceCream = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (!PauseMenu.GameIsPaused && GameController.IsInputEnabled)
        {
            if (Input.GetButtonDown("Attack1"))
            {
                if (hasPie)
                    Shoot();
                else if (hasSword)
                    Stab();
                else if (hasIceCream)
                    IceCream();
                else
                    Attack();
            }
        }
    }

    void IceCream()
    {
        animator.SetTrigger("Pie");
        Instantiate(iceCreamPrefab, firePoint.position, firePoint.rotation);
    }

    void Stab()
    {
        //Detect enemies in range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(swordAttackPoint.position, swordAttackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<HealthBar>().TakeDamage(40);
        }
        animator.SetTrigger("Sword");

    }

    void Shoot()
    {
        animator.SetTrigger("Pie");
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    void Attack()
    {
        //Play attack anim
        animator.SetTrigger("Attack");

        //Detect enemies in range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<HealthBar>().TakeDamage(attackDamage);
        }

        //Apply damage
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        Gizmos.DrawWireSphere(swordAttackPoint.position, swordAttackRange);
    }
}
