using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    public SpriteRenderer sr;
    public Sprite s;
    // Start is called before the first frame update
    void Start()
    {
        sr = transform.Find("Head").GetComponent<SpriteRenderer>();
        s = Resources.LoadAll<Sprite>("Textures/Heads")[2];
        //sr.sprite = s;
        Debug.Log("running");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
