using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Runtime.InteropServices;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    

    public void SetSliderValue(float value)
    {
        slider.value = value;
        fill.color = gradient.Evaluate(value);
    }
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        SetSliderValue(slider.value);
    }
    public void SetHealth(int health)
    {
        
        slider.value = health;
        SetSliderValue(slider.value);
    }
}
