using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class WitchHandAnimating : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] InputActionReference inputGrip;
    [SerializeField] InputActionReference inputTeleport;

    private const string _animParameter_Grip = "Grip";
    private const string _animParameter_Teleport = "Teleport";

    void Update()
    {
        if (inputGrip.action.ReadValue<float>() > 0)
        {
            animator.SetFloat(_animParameter_Grip, inputGrip.action.ReadValue<float>());
        }

        if (inputTeleport.action.ReadValue<float>() > 0)
        {
            animator.SetFloat(_animParameter_Teleport, inputTeleport.action.ReadValue<float>());
        }
    }
}
