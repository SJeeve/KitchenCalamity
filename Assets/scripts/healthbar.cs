using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour
{
    public Slider healthbarSlider;
    public Gradient grad;
    public Image fill;
    public void SetMaxHealth(int health)
    {
        healthbarSlider.maxValue = health;
        healthbarSlider.value = health;
        fill.color = grad.Evaluate(1f);
    }
    public void setHealth(int health)
    {
        healthbarSlider.value = health;
        fill.color = grad.Evaluate(healthbarSlider.normalizedValue);
    }
}
