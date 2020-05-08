using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class prevButton : MonoBehaviour
{
    public customize clown;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() => PrevClown());
    }
    void PrevClown()
    {
        clown.Prev();
    }
}
