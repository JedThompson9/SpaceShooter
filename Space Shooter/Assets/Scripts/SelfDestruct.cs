using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField]float destroyDelay = 3f;

    void Update() 
    {
        Destroy(gameObject, destroyDelay);    
    }
}
