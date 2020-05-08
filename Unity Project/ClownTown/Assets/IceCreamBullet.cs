﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCreamBullet : MonoBehaviour
{
    public float speed = 15f;
    public Rigidbody2D rb;
    public int damage = 40;
    public GameObject impactEffect;


    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        rb.rotation = 2f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HealthBar player = collision.GetComponent<HealthBar>();

        if (player != null)
            player.TakeDamage(damage);

        Instantiate(impactEffect, transform.position, transform.rotation);

        Destroy(gameObject);
    }
}
