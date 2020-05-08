using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nextButton : MonoBehaviour
{

    public customize clown;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() => NextClown());
        
    }

    // Update is called once per frame
    void NextClown()
    {
        clown.Next();

    }
}
