using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void SetActive(bool isActive) 
    {
        if (isActive) 
        {
            animator.SetTrigger("PlayAnimation");
        }
    }
}
