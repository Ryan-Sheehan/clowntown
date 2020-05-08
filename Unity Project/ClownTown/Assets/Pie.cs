using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pie : MonoBehaviour
{

    public GameObject pie1;
    public GameObject pie2;

    public Player2Combat player2combat;
    public PlayerCombat player1combat;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (player1combat.hasIceCream == false && player1combat.hasSword == false)
            {
                player1combat.hasPie = true;
                pie1.SetActive(true);
                OnDestroy();
            }
        } else if (collision.tag == "Player2")
        {
            if (player2combat.hasIceCream == false && player2combat.hasSword == false)
            {
                player2combat.hasPie = true;
                pie2.SetActive(true);
                OnDestroy();
            }
        }

    }

    private void OnDestroy()
    {
        Destroy(gameObject);
    }
}
