using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectToggler : MonoBehaviour
{
    //Serialized Variables
    [SerializeField] private ClimbDownLadder _climbDownLadder;
    [SerializeField] private ClimbUpLadder[] _climbUpLadder;

    [Header("Objects to be toggled")]
    [SerializeField] private GameObject[] interiorToggleObjects;
    [SerializeField] private GameObject[] exteriorToggleObjects;
    

    void Start()
    {
        //Subscribe to ClimbUpLadder/ClimbDownLadder Signifier Events
        _climbDownLadder.ClimbingLadderDown += Enable_EX_Objects;
        _climbDownLadder.ClimbingLadderDown += Disable_IN_Objects;

        for (int i = 0; i < _climbUpLadder.Length; i++)
        {
            _climbUpLadder[i].ClimbingLadderUp += Enable_IN_Objects;
            _climbUpLadder[i].ClimbingLadderUp += Disable_EX_Objects;
        }
    }

    //Toggle Functions
    private void Enable_EX_Objects()
    {
        //Debug.Log("Enabling Exterior Toggle Objects!");

        for (int i = 0; i < exteriorToggleObjects.Length; i++)
        {
            exteriorToggleObjects[i].SetActive(true);
        }
    }

    private void Disable_EX_Objects()
    {
        //Debug.Log("Disabling Exterior Toggle Objects!");

        for (int i = 0; i < exteriorToggleObjects.Length; i++)
        {
            exteriorToggleObjects[i].SetActive(false);
        }
    }

    private void Enable_IN_Objects()
    {
        //Debug.Log("Enabling Interior Toggle Objects!");

        for (int i = 0; i < interiorToggleObjects.Length; i++)
        {
            interiorToggleObjects[i].SetActive(true);
        }
    }

    private void Disable_IN_Objects()
    {
        //Debug.Log("Disabling Interior Toggle Objects!");

        for (int i = 0; i < interiorToggleObjects.Length; i++)
        {
            interiorToggleObjects[i].SetActive(false);
        }
    }

    private void OnDisable()
    {
        //Unsubscribe from ClimbUpLadder/ClimbDownLadder Signifier Events
        _climbDownLadder.ClimbingLadderDown -= Enable_EX_Objects;
        _climbDownLadder.ClimbingLadderDown -= Disable_IN_Objects;

        for (int i = 0; i < _climbUpLadder.Length; i++)
        {
            _climbUpLadder[i].ClimbingLadderUp -= Enable_IN_Objects;
            _climbUpLadder[i].ClimbingLadderUp -= Disable_EX_Objects;
        }
    }
}
