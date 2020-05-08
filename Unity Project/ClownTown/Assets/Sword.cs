using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{

    public GameObject pie1;
    public GameObject pie2;

    public Player2Combat player2combat;
    public PlayerCombat player1combat;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetButtonDown("Pickup") && !player1combat.hasSword)
        {
            player1combat.hasPie = false;
            player1combat.hasIceCream = false;
            if (player1combat.pie != null)
                player1combat.pie.SetActive(false);
            if (player1combat.iceCream != null)
                player1combat.iceCream.SetActive(false);
            player1combat.hasSword = true;
            pie1.SetActive(true);
            OnDestroy();
        } else if (collision.tag == "Player2" && Input.GetButtonDown("Pickup2") && !player2combat.hasSword)
        {
            player2combat.hasPie = false;
            player2combat.hasIceCream = false;
            if (player2combat.pie != null)
                player2combat.pie.SetActive(false);
            if (player2combat.iceCream != null)
                player2combat.iceCream.SetActive(false);
            player2combat.hasSword = true;
            pie2.SetActive(true);
            OnDestroy();
        }

    }

    private void OnDestroy()
    {
        Destroy(gameObject);
    }
}
