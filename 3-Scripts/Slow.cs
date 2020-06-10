using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow : MonoBehaviour
{
    [SerializeField] float reducedSpeed = 0f;
    Attacker attacker;


    /*private void OnTriggerStay2D(Collider2D otherCollider)
    {
        Attacker attacker = otherCollider.GetComponent<Attacker>();
        if (attacker)
        {
            //Time.timeScale = 0.2f; 
        }
    }*/

}
