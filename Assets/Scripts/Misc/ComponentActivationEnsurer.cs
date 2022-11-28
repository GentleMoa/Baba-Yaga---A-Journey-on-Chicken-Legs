using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentActivationEnsurer : MonoBehaviour
{
    //Serialized Variables
    [SerializeField] private Animator animator;

    void Start()
    {
        animator.enabled = true;
    }
}
