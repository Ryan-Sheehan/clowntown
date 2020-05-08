using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class customize : MonoBehaviour
{
    public Sprite[] choices;
    public int curr = 0;

    public Text text;
    public Text readyText;

    public bool clown1;
    public bool ready;

    string oldText;

    string[] texts = { "Good all around!", "Slow, but strong!", "Fast, but weak!" };

    private void Start()
    {
        ready = false;
        if (clown1)
            PlayerPrefs.SetInt("clown1", curr);
        else
            PlayerPrefs.SetInt("clown2", curr);

        text.text = texts[curr];
        oldText = readyText.text;
    }

    public void Ready()
    {
        ready = !ready;
        if (ready)
            readyText.text = "Ready";
        else
            readyText.text = oldText;
    }

    public void Next()
    {
        curr = (curr + 1) % 3;
        gameObject.GetComponent<SpriteRenderer>().sprite = choices[curr];

        if (clown1)
            PlayerPrefs.SetInt("clown1", curr);
        else
            PlayerPrefs.SetInt("clown2", curr);

        text.text = texts[curr];

    }
    public void Prev()
    {
        curr = (curr - 1);

        if (curr < 0)
            curr = 2;

        gameObject.GetComponent<SpriteRenderer>().sprite = choices[curr];

        if (clown1)
            PlayerPrefs.SetInt("clown1", curr);
        else
            PlayerPrefs.SetInt("clown2", curr);
        text.text = texts[curr];
    }
}
