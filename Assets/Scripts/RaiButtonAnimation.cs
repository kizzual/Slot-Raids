using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiButtonAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void StartAnimation()
    {
        animator.SetTrigger("Press");
    }
}
