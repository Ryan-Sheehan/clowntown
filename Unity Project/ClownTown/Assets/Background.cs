using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{


    public Texture2D[] frames; 
    
    float framesPerSecond = 10.0f;

    void Update() 
    { 
        int index = (int) (Time.time * framesPerSecond); 
        index = index % frames.Length;
        GetComponent<Renderer>().material.mainTexture = frames[index]; 
    }
}
