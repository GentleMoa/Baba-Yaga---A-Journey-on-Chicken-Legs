using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwlNav_StartingIdling : MonoBehaviour
{
    //Private Variables
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();

        _animator.SetTrigger("Bool_SittingIdle");
    }
}
