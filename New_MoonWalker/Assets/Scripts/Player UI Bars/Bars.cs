using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bars : MonoBehaviour
{
    public Slider slider;

    public void SetMaxValue(float bar)
    {
        slider.maxValue = bar;
        slider.value = bar;
    }

    public void SetValue(float bar)
    {
        slider.value = bar;
    }
}
