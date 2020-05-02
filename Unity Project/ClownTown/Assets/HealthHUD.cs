using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthHUD : MonoBehaviour
{
    public Slider slider;
    public GameObject clown;
    // Update is called once per frame
    void Update()
    {
        int HP = clown.GetComponent<HealthBar>().currentHealth;
        slider.value = HP;
    }
}
