using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 100;
    public int currentHealth;

    public Collider2D circle;
    public Collider2D box;

    public GameObject gameOverMenu;

    bool isDead = false;

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
        if (!isDead) {
            isDead = true;

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

            if (this.name == "clown2")
            {
                PlayerPrefs.SetInt("Score1", PlayerPrefs.GetInt("Score1", 0) + 1);
            }
            else if (this.name == "clown1")
            {
                PlayerPrefs.SetInt("Score2", PlayerPrefs.GetInt("Score2", 0) + 1);
            }

            string sceneName = SceneManager.GetActiveScene().name;

            //CHANGE THIS CODE WHEN MORE LEVELS ADDED
            if (sceneName == "Stage2")
            {
                GameObject.Find("PauseCanvas").GetComponent<PauseMenu>().isGameOver = true;
                gameOverMenu.SetActive(true);
                this.enabled = false;
            }
            else
            {

                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
