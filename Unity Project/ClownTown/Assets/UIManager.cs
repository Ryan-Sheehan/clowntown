using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public RectTransform btnPrefab;

    private FeatureManager mgr;
    private FeatureManager mgr2;
    private Text descText;
    private List<Button> buttons;
    private List<Button> buttons2;

    public SpriteRenderer clown1;
    public SpriteRenderer clown2;

    public Sprite[] choices;
    public int curr = 0;

    // Start is called before the first frame update
    void Start()
    {
        mgr = FindObjectsOfType<FeatureManager>()[0];
        mgr2 = FindObjectsOfType<FeatureManager>()[1];
        
        transform.Find("Navigation1").Find("Previous").GetComponent<Button>().onClick.AddListener(() => PreviousClown1());
        transform.Find("Navigation1").Find("Next").GetComponent<Button>().onClick.AddListener(() => NextClown1());
        
        transform.Find("Navigation2").Find("Previous").GetComponent<Button>().onClick.AddListener(() => PreviousClown2());
        transform.Find("Navigation2").Find("Next").GetComponent<Button>().onClick.AddListener(() => NextClown2());
        
        //InitializeFeatureButtons();
        transform.Find("NextLevel").GetComponent<Button>().onClick.AddListener(() => nextLevel("Stage1"));
    }

    private void nextLevel(string level)
    {
        SceneManager.LoadScene(level);
    }


    void NextClown1()
    {
        Debug.Log("here");
        curr = (curr + 1) % 3;
        clown1.sprite = choices[curr];
    }
    void PreviousClown1()
    {
        curr = (curr - 1) % 3;
        clown1.sprite = choices[curr];
    }
    void NextClown2()
    {
        curr = (curr + 1) % 3;
        clown2.sprite = choices[curr];
    }
    void PreviousClown2()
    {
        curr = (curr + 1) % 3;
        clown2.sprite = choices[curr];
    }

}
