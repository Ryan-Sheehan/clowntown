using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{

    public GameObject pie1;
    public GameObject pie2;

    public Player2Combat player2combat;
    public PlayerCombat player1combat;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (player1combat.hasPie == false && player1combat.hasIceCream == false)
            {
                player1combat.hasSword = true;
                pie1.SetActive(true);
                OnDestroy();
            }
        } else if (collision.tag == "Player2")
        {
            if (player2combat.hasPie == false && player2combat.hasIceCream == false)
            {
                player2combat.hasSword = true;
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
