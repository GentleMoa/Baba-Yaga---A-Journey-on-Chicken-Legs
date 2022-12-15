using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThumbStickDataReader_TEST : MonoBehaviour
{
    //Serialized Variables
    [SerializeField] private InputActionReference input_leftThumbstick;

    // Update is called once per frame
    void Update()
    {
        Debug.Log(input_leftThumbstick.action.ReadValue<Vector2>());
    }
}
