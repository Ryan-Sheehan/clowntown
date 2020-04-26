using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pieplayer2 : MonoBehaviour
{
    public bool isActive;

    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
            gameObject.SetActive(true);
    }
}
