using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] int stars = 100;
    [SerializeField] TextMeshProUGUI starText;


    void Start()
    {
        starText = GetComponent<TextMeshProUGUI>();
        UpdateDisplay();
    }

    public bool HaveEnoughStars(int amount)
    {
        return stars >= amount;//when we are passing the amount do we have more than the amount and if so, return as true
    }

    private void UpdateDisplay()
    {
        starText.text = stars.ToString();
    }

    public void AddStars(int amount)
    {
        stars += amount;
        UpdateDisplay(); //call it here so that each time something happen, we update the number of stars on the screen
    }


    public void SpendStars (int amount)
    {
        if(stars >= amount)
        {
            stars -= amount;
            UpdateDisplay();
        }   
    }

}
