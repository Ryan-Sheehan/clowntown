using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    public GameObject gameOverMenu;
    public GameObject clown1;
    public GameObject clown2;

    private HealthBar clown1HB;
    private HealthBar clown2HB;

    private void Start()
    {
        clown1HB = clown1.GetComponent<HealthBar>();
        clown2HB = clown2.GetComponent<HealthBar>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            clown1HB.Die();
        else if (collision.tag == "Player2")
            clown2HB.Die();
    }
}
