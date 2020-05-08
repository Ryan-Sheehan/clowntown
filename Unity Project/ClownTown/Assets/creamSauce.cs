using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creamSauce : MonoBehaviour
{
    public int damage;

    private void Start()
    {
        damage = 1;
    }


    IEnumerator ExampleCoroutine2(Player2Movement player2Movement)
    {
        yield return new WaitForSeconds(2);
        player2Movement.runSpeed = 40;
    }

    IEnumerator ExampleCoroutine1(PlayerMovement playerMovement)
    {
        yield return new WaitForSeconds(2);
        playerMovement.runSpeed = 40;
    }

    IEnumerator TakeDamage(HealthBar player)
    {
        player.TakeDamage(damage);
        yield return new WaitForSeconds(2);
    }

    private void OnParticleCollision(GameObject other)
    {
        HealthBar player = gameObject.GetComponent<HealthBar>();
        Player2Movement player2Movement = gameObject.GetComponent<Player2Movement>();
        PlayerMovement player1Movement = gameObject.GetComponent<PlayerMovement>();

        if (player != null)
            StartCoroutine(TakeDamage(player));

        if (player1Movement != null)
        {
            player1Movement.runSpeed = 20;
            StartCoroutine(ExampleCoroutine1(player1Movement));
        }

        if (player2Movement != null)
        {
            player2Movement.runSpeed = 20;
            StartCoroutine(ExampleCoroutine2(player2Movement));
        }


    }
}
