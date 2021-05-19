using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTime : MonoBehaviour
{
    public float lifeTime = 1.5f;
    
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }
}
