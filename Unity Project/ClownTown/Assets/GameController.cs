using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    // Update is called once per frame

    public static bool IsInputEnabled = false;

    public float timeLeft = 3.0f;
    public Text startText; // used for showing countdown from 3, 2, 1 

    void Start()
    {
        IsInputEnabled = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        startText.text = (timeLeft).ToString("0");
        if (timeLeft < 0)
        {
            IsInputEnabled = true;
            startText.text = "";

        }
    }

}
