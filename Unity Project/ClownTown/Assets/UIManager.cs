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

    // Start is called before the first frame update
    void Start()
    {
        mgr = FindObjectsOfType<FeatureManager>()[0];
        mgr2 = FindObjectsOfType<FeatureManager>()[1];
        //descText = transform.Find("Navigation").Find("Description").GetComponent<Text>();
        
        transform.Find("Navigation1").Find("Previous").GetComponent<Button>().onClick.AddListener(() => PreviousClown1());
        transform.Find("Navigation1").Find("Next").GetComponent<Button>().onClick.AddListener(() => NextClown1());
        //transform.Find("Navigation-Feet").Find("Previous").GetComponent<Button>().onClick.AddListener(() => mgr.SetCurrent(5));
        //transform.Find("Navigation-Feet").Find("Next").GetComponent<Button>().onClick.AddListener(() => mgr.SetCurrent(5));
        
        transform.Find("Navigation2").Find("Previous").GetComponent<Button>().onClick.AddListener(() => PreviousClown2());
        transform.Find("Navigation2").Find("Next").GetComponent<Button>().onClick.AddListener(() => NextClown2());
        //transform.Find("Navigation-Torso").Find("Previous").GetComponent<Button>().onClick.AddListener(() => mgr.SetCurrent(4));
        //transform.Find("Navigation-Torso").Find("Next").GetComponent<Button>().onClick.AddListener(() => mgr.SetCurrent(4));
        

        //transform.Find("Navigation-Ears").Find("Previous").GetComponent<Button>().onClick.AddListener(() => PreviousClown());
        //transform.Find("Navigation-Ears").Find("Next").GetComponent<Button>().onClick.AddListener(() => NextClown());
        //transform.Find("Navigation-Ears").Find("Previous").GetComponent<Button>().onClick.AddListener(() => mgr.SetCurrent(3));
        //transform.Find("Navigation-Ears").Find("Next").GetComponent<Button>().onClick.AddListener(() => mgr.SetCurrent(3));
        
        //transform.Find("Navigation-FaceFeatures").Find("Previous").GetComponent<Button>().onClick.AddListener(() => PreviousClown());
        //transform.Find("Navigation-FaceFeatures").Find("Next").GetComponent<Button>().onClick.AddListener(() => NextClown());
        //transform.Find("Navigation-FaceFeatures").Find("Previous").GetComponent<Button>().onClick.AddListener(() => mgr.SetCurrent(2));
        //transform.Find("Navigation-FaceFeatures").Find("Next").GetComponent<Button>().onClick.AddListener(() => mgr.SetCurrent(2));
        

        //transform.Find("Navigation-Hat").Find("Previous").GetComponent<Button>().onClick.AddListener(() => PreviousClown());
        //transform.Find("Navigation-Hat").Find("Next").GetComponent<Button>().onClick.AddListener(() => NextClown());
        //transform.Find("Navigation-Hat").Find("Previous").GetComponent<Button>().onClick.AddListener(() => mgr.SetCurrent(1));
        //transform.Find("Navigation-Hat").Find("Next").GetComponent<Button>().onClick.AddListener(() => mgr.SetCurrent(1));
        
        //transform.Find("Navigation-FaceColor").Find("Previous").GetComponent<Button>().onClick.AddListener(() => PreviousClown());
        //transform.Find("Navigation-FaceColor").Find("Next").GetComponent<Button>().onClick.AddListener(() => NextClown());
        //transform.Find("Navigation-FaceColor").Find("Previous").GetComponent<Button>().onClick.AddListener(() => mgr.SetCurrent(0));
        //transform.Find("Navigation-FaceColor").Find("Next").GetComponent<Button>().onClick.AddListener(() => mgr.SetCurrent(0));
        
        //InitializeFeatureButtons();
        transform.Find("NextLevel").GetComponent<Button>().onClick.AddListener(() => nextLevel("Stage1"));
    }

    private void nextLevel(string level)
    {
        SceneManager.LoadScene(level);
    }

    void InitializeFeatureButtons()
    {
        buttons = new List<Button>();
        buttons2 = new List<Button>();
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
        for (int i = 0; i < mgr.features.Count; i++)
        {
            RectTransform temp = Instantiate<RectTransform>(btnPrefab);
            temp.name = i.ToString();
            temp.SetParent(transform.Find("Features2").GetComponent<RectTransform>());
            temp.localScale = new Vector3(1, 1, 1);
            temp.localPosition = new Vector3(0, 0, 0);
            temp.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0, width);
            temp.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, i * height, height);

            Button b = temp.GetComponent<Button>();
            b.onClick.AddListener(() => mgr.SetCurrent(int.Parse(temp.name)));
            buttons2.Add(b);
           
        }
    }

    void UpdateFeatureButtons()
    {
        for (int i = 0; i < mgr.features.Count; i++)
        {
            buttons[i].transform.Find("FeatureImg").GetComponent<Image>().sprite = mgr.features[i].renderer.sprite;
            buttons2[i].transform.Find("FeatureImg").GetComponent<Image>().sprite = mgr2.features[i].renderer.sprite;
        }
    }

    void NextClown1()
    {
        for (int i = 0; i < 6; i++)
        {
            mgr.SetCurrent(i);
            mgr.NextChoice();     
        }
    }
    void PreviousClown1()
    {
        for (int i = 0; i < 6; i++)
        {
            mgr.SetCurrent(i);
            mgr.PreviousChoice(); 
        }
    }
    void NextClown2()
    {
        for (int i = 0; i < 6; i++)
        { 
            mgr2.SetCurrent(i);
            mgr2.NextChoice();    
        }
    }
    void PreviousClown2()
    {
        for (int i = 0; i < 6; i++)
        {
            mgr2.SetCurrent(i);
            mgr2.PreviousChoice(); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        //UpdateFeatureButtons();
        EventSystem.current.SetSelectedGameObject(buttons[mgr.currFeature].gameObject);
        EventSystem.current.SetSelectedGameObject(buttons2[mgr2.currFeature].gameObject);
        //descText.text = mgr.features[mgr.currFeature].ID + " #" + (mgr.features[mgr.currFeature].currIndex + 1).ToString();
    }
}
