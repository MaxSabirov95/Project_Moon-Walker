using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XpBar : MonoBehaviour
{
    public Slider slider;
    public PlayerStats playerStats;

    private void Start()
    {
        slider.maxValue = playerStats.maxPlayerXP;
    }

    public void SetXp(float xp)
    {
        slider.value = xp;
    }
}
