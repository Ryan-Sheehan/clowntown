using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class nextButton : MonoBehaviour
{

    public customize clown1;
    public customize clown2;

    public Text countdown;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        countdown.text = "";
    }

    private void Update()
    {
        if (Input.GetButtonDown("Ready"))
            clown1.Ready();

        if (Input.GetButtonDown("Ready2"))
            clown2.Ready();

        if (Input.GetButtonDown("Next"))
        {
            clown1.Next();
        } else if (Input.GetButtonDown("Prev"))
        {
            clown1.Prev();
        }
        else if (Input.GetButtonDown("Prev2"))
        {
            clown2.Prev();
        }
        else if (Input.GetButtonDown("Next2"))
        {
            clown2.Next();
        }

        if (clown1.ready && clown2.ready)
            SceneManager.LoadScene("Stage1");
    }

}
