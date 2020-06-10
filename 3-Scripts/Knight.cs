using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D Collid)
    {
        GameObject collidObject = Collid.gameObject;
        if (collidObject.GetComponent<Slow>())
        {
            GetComponent<Animator>().SetTrigger("jumpTrigger");
        }
        else if (collidObject.GetComponent<Defender>())
        {
            GetComponent<Attacker>().Target(collidObject);
        }
    }
}
