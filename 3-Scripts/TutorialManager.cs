using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] GameObject popUps;


    // Update is called once per frame
    void Awake()
    {
        Time.timeScale = 0.2f;
        popUps.SetActive(true);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            popUps.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
