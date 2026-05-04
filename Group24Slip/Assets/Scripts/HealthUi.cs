using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class HealthUi : MonoBehaviour
{
    public Image Bar;
    public Sprite Fullhealthbar, Emptyhealthbar;

    private List<Image> healthBar = new List<Image>();

    public void SetMaxHealth(int maxBars)
    {
        foreach (Image Bar in healthBar)
        {
            Destroy(Bar.gameObject);
        }

        healthBar.Clear();

        for (int i = 0; i < maxBars; i++)
        {
            Image newBar = Instantiate(Bar, transform);
            newBar.sprite = Fullhealthbar;
            healthBar.Add(newBar);
        }
    }

    public void UpdateBars(int currentBars)
    {
        for (int i = 0; i < healthBar.Count; i++) 
        { 
            if (i < currentBars)
            {
                healthBar[i].sprite = Fullhealthbar;
            }
            else
            {
                healthBar[i].sprite = Emptyhealthbar;
            }
        }
    }






}
