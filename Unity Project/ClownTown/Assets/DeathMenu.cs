using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DeathMenu : MonoBehaviour
{
    public GameObject deathMenuUI;
    public TextMeshProUGUI headerText;

    void Update()
    {
        if (PlayerPrefs.GetInt("Score1", 0) > PlayerPrefs.GetInt("Score2", 0))
        {
            headerText.text = "RIGHT CLOWN WINS!";
        }
        else if (PlayerPrefs.GetInt("Score1", 0) < PlayerPrefs.GetInt("Score2", 0))
        {
            headerText.text = "LEFT CLOWN WINS!";
        }
        else
        {
            headerText.text = "TIE!";
        }
    }

    public void RestartMatch()
    {
        Time.timeScale = 1f;
        //Scene currentScene = SceneManager.GetActiveScene();
        //SceneManager.LoadScene(currentScene.name);
        SceneManager.LoadScene(2);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
