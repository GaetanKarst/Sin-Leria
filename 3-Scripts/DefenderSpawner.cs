using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;
    GameObject defenderParent;

    const string DEFENDER_PARENT_NAME = "Defenders";
    

    private void Start()
    {
        CreateDefenderParent();
    }

   

    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        //in case if there is an error or bug
        if (!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    public void OnMouseDown()
    {
        AttemptToPlaceDefenderAt(GetSquareClicked());//Methodception, as we need to know the cordinated of the world to place within the squares
    }

    public void SetSelectedDefender(Defender defenderToSelect)
    {
        defender = defenderToSelect;
    }

    private void AttemptToPlaceDefenderAt(Vector2 gridPos)
    {
        var starDisplay = FindObjectOfType<StarDisplay>();
        int defenderCost = defender.GetStarCost();
        if(starDisplay.HaveEnoughStars(defenderCost))
        {
            SpawnDefender(gridPos);
            starDisplay.SpendStars(defenderCost);
        }
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = SnapToGrid(worldPos);
        return gridPos;//return gridPos instead of worldPos
        
    }

    private Vector2 SnapToGrid(Vector2 rawWorldpos)
    {
        float newX = Mathf.RoundToInt(rawWorldpos.x);//Switches our float to int
        float newY = Mathf.RoundToInt(rawWorldpos.y);
        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector2 roundedPos) //passes the position in worldspace where the defender be placed
    {
        Defender newDefender = Instantiate(
           defender, roundedPos, Quaternion.identity) as Defender;
        newDefender.transform.parent = defenderParent.transform;//instantiate as a child of defenderParent in the hirarchy
    }
}
