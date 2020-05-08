using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class customize : MonoBehaviour
{
    public Sprite[] choices;
    public int curr = 0;

    public Text text;

    public bool clown1;

    string[] texts = { "Good all around!", "Slow, but strong!", "Fast, but weak!" };

    private void Start()
    {
        if (clown1)
            PlayerPrefs.SetInt("clown1", curr);
        else
            PlayerPrefs.SetInt("clown2", curr);

        text.text = texts[curr];
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
        curr = (curr - 1) % 3;
        gameObject.GetComponent<SpriteRenderer>().sprite = choices[curr];

        if (clown1)
            PlayerPrefs.SetInt("clown1", curr);
        else
            PlayerPrefs.SetInt("clown2", curr);
        text.text = texts[curr];
    }
}
