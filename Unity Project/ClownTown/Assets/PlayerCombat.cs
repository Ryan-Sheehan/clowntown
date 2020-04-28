using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 40;

    public GameObject bulletPrefab;
    public GameObject pie;
    public GameObject sword;
    public Sword2 sword2;

    public bool hasPie;
    public bool hasSword;

    public Transform firePoint;

    private void Start()
    {
        pie.SetActive(false);
        sword.SetActive(false);
        hasPie = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (!PauseMenu.GameIsPaused)
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                if (hasPie)
                    Shoot();
                else if (hasSword)
                    Stab();
                else
                    Attack();
            }
        }
    }

    void Stab()
    {
        sword2.attacking = true;
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
    }
}
