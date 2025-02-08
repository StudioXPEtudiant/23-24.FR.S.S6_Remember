using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHealth(int health) 
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health) // Méthode à appeler quand le joueur se prend un dégât ou se soigne
    {
        slider.value = health;
    }
}
