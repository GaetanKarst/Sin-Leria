using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Defender : MonoBehaviour
{
    [SerializeField] int starCost = 100;

    public void AddStar(int amount)
    {
        FindObjectOfType<StarDisplay>().AddStars(amount);
    }

    public int GetStarCost()
    {
        return starCost;
    }
}
