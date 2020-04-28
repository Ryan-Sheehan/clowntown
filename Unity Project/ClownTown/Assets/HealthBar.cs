using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 100;
    public int currentHealth;

    public Collider2D circle;
    public Collider2D box;

    public GameObject gameOverMenu;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        GameObject.Find("PauseCanvas").GetComponent<PauseMenu>().isGameOver = false;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        animator.SetBool("isDead", true);
        if (GetComponent<Player2Movement>() == null)
            GetComponent<PlayerMovement>().enabled = false;
        else 
            GetComponent<Player2Movement>().enabled = false;

        if (GetComponent<Player2Combat>() == null)
            GetComponent<PlayerCombat>().enabled = false;
        else
            GetComponent<Player2Combat>().enabled = false;
        circle.enabled = false;
        box.enabled = false;

        GameObject.Find("PauseCanvas").GetComponent<PauseMenu>().isGameOver = true;
        gameOverMenu.SetActive(true);

        this.enabled = false;
    }
}
