using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSwitch : MonoBehaviour
{
    public Animator animator;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        animator.SetTrigger("FadeOut");
    }
}
