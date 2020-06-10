using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowBolt : MonoBehaviour
{

    float lifeTime = 6f;

    private void Update()
    {
        Destroy(gameObject, lifeTime);
    }
}
