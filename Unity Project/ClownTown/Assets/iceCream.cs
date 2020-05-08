using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iceCream : MonoBehaviour
{
    public GameObject iceCream1;
    public GameObject iceCream2;

    public Player2Combat player2combat;
    public PlayerCombat player1combat;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (player1combat.hasPie == false && player1combat.hasSword == false)
            {
                player1combat.hasIceCream = true;
                iceCream1.SetActive(true);
                OnDestroy();
            }
        }
        else if (collision.tag == "Player2")
        {
            if (player2combat.hasPie == false && player2combat.hasSword == false)
            {
                player2combat.hasIceCream = true;
                iceCream2.SetActive(true);
                OnDestroy();
            }
        }

    }

    private void OnDestroy()
    {
        Destroy(gameObject);
    }
}
