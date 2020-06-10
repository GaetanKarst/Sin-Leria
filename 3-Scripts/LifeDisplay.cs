using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LifeDisplay : MonoBehaviour
{
    [SerializeField] float playerLife;
    [SerializeField] int damages;

    TextMeshProUGUI lifeText;

    // Start is called before the first frame update
    void Start()
    {
        lifeText = GetComponent<TextMeshProUGUI>();
        UpdateDisplay();
        GameDifficulty();
    }

    private void UpdateDisplay()
    {
        lifeText.text = playerLife.ToString();
    }

    public void TakeLife()//TO IMPROVE: if some attacker withdraw more than some others we need to pass the damage amout in
    {
        playerLife -= damages;
        UpdateDisplay();

        if(playerLife <= 0)
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();
            damages = 0;
        }
    }

    public void GameDifficulty()
    {
        var gameDifficulty = PlayerPrefsController.GetMasterDifficulty();
        Debug.Log("Difficulty set to" + gameDifficulty);

        //Easy Mode
        if (gameDifficulty == 0f)
        {
            damages = 25;
        }
        //Normal Mode
        else if (gameDifficulty == 1f) 
        {
            damages = 35;
        }
        //Hard Mode
        else if (gameDifficulty == 2f)
        {
            damages = 50;
        }
    }
}
