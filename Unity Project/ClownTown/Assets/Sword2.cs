using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword2 : MonoBehaviour
{
    public int damage = 40;
    public bool attacking;

    private void Start()
    {
        attacking = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HealthBar player = collision.GetComponent<HealthBar>();

        if (player != null)
        {
            player.TakeDamage(damage);
            attacking = false;
        }
    }
}
