﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public RectTransform btnPrefab;

    private FeatureManager mgr;
    private Text descText;
    private List<Button> buttons;

    // Start is called before the first frame update
    void Start()
    {
        mgr = FindObjectOfType<FeatureManager>();
        //descText = transform.Find("Navigation").Find("Description").GetComponent<Text>();
        
        transform.Find("Navigation-Feet").Find("Previous").GetComponent<Button>().onClick.AddListener(() => mgr.PreviousChoice());
        transform.Find("Navigation-Feet").Find("Next").GetComponent<Button>().onClick.AddListener(() => mgr.NextChoice());
        transform.Find("Navigation-Feet").Find("Previous").GetComponent<Button>().onClick.AddListener(() => mgr.SetCurrent(5));
        transform.Find("Navigation-Feet").Find("Next").GetComponent<Button>().onClick.AddListener(() => mgr.SetCurrent(5));
        
        transform.Find("Navigation-Torso").Find("Previous").GetComponent<Button>().onClick.AddListener(() => mgr.NextChoice());
        transform.Find("Navigation-Torso").Find("Next").GetComponent<Button>().onClick.AddListener(() => mgr.NextChoice());
        transform.Find("Navigation-Torso").Find("Previous").GetComponent<Button>().onClick.AddListener(() => mgr.SetCurrent(4));
        transform.Find("Navigation-Torso").Find("Next").GetComponent<Button>().onClick.AddListener(() => mgr.SetCurrent(4));
        

        transform.Find("Navigation-Ears").Find("Previous").GetComponent<Button>().onClick.AddListener(() => mgr.PreviousChoice());
        transform.Find("Navigation-Ears").Find("Next").GetComponent<Button>().onClick.AddListener(() => mgr.NextChoice());
        transform.Find("Navigation-Ears").Find("Previous").GetComponent<Button>().onClick.AddListener(() => mgr.SetCurrent(3));
        transform.Find("Navigation-Ears").Find("Next").GetComponent<Button>().onClick.AddListener(() => mgr.SetCurrent(3));
        
        transform.Find("Navigation-FaceFeatures").Find("Previous").GetComponent<Button>().onClick.AddListener(() => mgr.PreviousChoice());
        transform.Find("Navigation-FaceFeatures").Find("Next").GetComponent<Button>().onClick.AddListener(() => mgr.NextChoice());
        transform.Find("Navigation-FaceFeatures").Find("Previous").GetComponent<Button>().onClick.AddListener(() => mgr.SetCurrent(2));
        transform.Find("Navigation-FaceFeatures").Find("Next").GetComponent<Button>().onClick.AddListener(() => mgr.SetCurrent(2));
        

        transform.Find("Navigation-Hat").Find("Previous").GetComponent<Button>().onClick.AddListener(() => mgr.PreviousChoice());
        transform.Find("Navigation-Hat").Find("Next").GetComponent<Button>().onClick.AddListener(() => mgr.NextChoice());
        transform.Find("Navigation-Hat").Find("Previous").GetComponent<Button>().onClick.AddListener(() => mgr.SetCurrent(1));
        transform.Find("Navigation-Hat").Find("Next").GetComponent<Button>().onClick.AddListener(() => mgr.SetCurrent(1));
        
        transform.Find("Navigation-FaceColor").Find("Previous").GetComponent<Button>().onClick.AddListener(() => mgr.PreviousChoice());
        transform.Find("Navigation-FaceColor").Find("Next").GetComponent<Button>().onClick.AddListener(() => mgr.NextChoice());
        transform.Find("Navigation-FaceColor").Find("Previous").GetComponent<Button>().onClick.AddListener(() => mgr.SetCurrent(0));
        transform.Find("Navigation-FaceColor").Find("Next").GetComponent<Button>().onClick.AddListener(() => mgr.SetCurrent(0));
        
        InitializeFeatureButtons();
        transform.Find("NextLevel").GetComponent<Button>().onClick.AddListener(() => nextLevel("Stage1"));
    }

    private void nextLevel(string level)
    {
        SceneManager.LoadScene(level);
    }

    void InitializeFeatureButtons()
    {
        buttons = new List<Button>();
        float height = btnPrefab.rect.height;
        float width = btnPrefab.rect.width;

        for (int i = 0; i < mgr.features.Count; i++)
        {
            RectTransform temp = Instantiate<RectTransform>(btnPrefab);
            temp.name = i.ToString();
            temp.SetParent(transform.Find("Features").GetComponent<RectTransform>());
            temp.localScale = new Vector3(1, 1, 1);
            temp.localPosition = new Vector3(0, 0, 0);
            temp.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0, width);
            temp.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, i * height, height);

            Button b = temp.GetComponent<Button>();
            b.onClick.AddListener(() => mgr.SetCurrent(int.Parse(temp.name)));
            buttons.Add(b);
        }
    }

    void UpdateFeatureButtons()
    {
        for (int i = 0; i < mgr.features.Count; i++)
        {
            buttons[i].transform.Find("FeatureImg").GetComponent<Image>().sprite = mgr.features[i].renderer.sprite;
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateFeatureButtons();
        EventSystem.current.SetSelectedGameObject(buttons[mgr.currFeature].gameObject);
        //descText.text = mgr.features[mgr.currFeature].ID + " #" + (mgr.features[mgr.currFeature].currIndex + 1).ToString();
    }
}
