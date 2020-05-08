using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iceCream : MonoBehaviour
{
    public GameObject iceCream1;
    public GameObject iceCream2;

    public Player2Combat player2combat;
    public PlayerCombat player1combat;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetButtonDown("Pickup") && !player1combat.hasIceCream)
        {
            player1combat.hasPie = false;
            player1combat.hasSword = false;
            if (player1combat.pie != null)
                player1combat.pie.SetActive(false);
            if (player1combat.sword != null)
                player1combat.sword.SetActive(false);
            player1combat.hasIceCream = true;
            iceCream1.SetActive(true);
            OnDestroy();
        }
        else if (collision.tag == "Player2" && Input.GetButtonDown("Pickup2") && !player2combat.hasIceCream)
        {
            player2combat.hasPie = false;
            player2combat.hasSword = false;
            if (player2combat.pie != null)
                player2combat.pie.SetActive(false);
            if (player2combat.sword != null)
                player2combat.sword.SetActive(false);
            player2combat.hasIceCream = true;
            iceCream2.SetActive(true);
            OnDestroy();
        }

    }

    private void OnDestroy()
    {
        Destroy(gameObject);
    }
}
