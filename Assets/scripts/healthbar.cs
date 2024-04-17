using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour
{
    public Slider healthbarSlider;

    public void SetMaxHealth(int health)
    {
        healthbarSlider.maxValue = health;
        healthbarSlider.value = health;
    }
    public void setHealth(int health)
    {
        healthbarSlider.value = health;
    }
}
