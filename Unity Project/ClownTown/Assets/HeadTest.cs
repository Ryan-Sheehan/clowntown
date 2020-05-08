using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadTest : MonoBehaviour
{

    public Sprite[] heads;
    public bool clown1;
    public PlayerMovement player1Movement;
    public Player2Movement player2Movement;

    public int index = 0;


    void Start()
    {
        SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
        if (clown1)
        {
            index = PlayerPrefs.GetInt("clown1");
            renderer.sprite = heads[index];
            player1Movement.Modify(index);
        } else
        {
            index = PlayerPrefs.GetInt("clown2");
            renderer.sprite = heads[index];
            player2Movement.Modify(index);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
