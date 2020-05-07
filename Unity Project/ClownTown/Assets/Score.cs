using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI score1Text;
    public TextMeshProUGUI score2Text;

    // Start is called before the first frame update
    void Start()
    {
        if ((SceneManager.GetActiveScene()).name == "Stage1")
        {
            PlayerPrefs.SetInt("Score1", 0);
            PlayerPrefs.SetInt("Score2", 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        score1Text.text = PlayerPrefs.GetInt("Score1", 0).ToString();
        score2Text.text = PlayerPrefs.GetInt("Score2", 0).ToString();
    }
}
