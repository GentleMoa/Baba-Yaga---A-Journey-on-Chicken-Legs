using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ND_ObjectToggler : MonoBehaviour
{
    //Serialized Variables
    [SerializeField] private ND_ClimbDownLadder ND_climbDownLadder;
    [SerializeField] private ND_ClimbUpLadder[] ND_climbUpLadder;

    [Header("Objects to be toggled")]
    [SerializeField] private GameObject[] interiorToggleObjects;
    [SerializeField] private GameObject[] exteriorToggleObjects;
    

    private void Start()
    {
        //Subscribe to ClimbUpLadder/ClimbDownLadder Signifier Events
        ND_climbDownLadder.ClimbingLadderDown += Enable_EX_Objects;
        ND_climbDownLadder.ClimbingLadderDown += Disable_IN_Objects;

        for (int i = 0; i < ND_climbUpLadder.Length; i++)
        {
            ND_climbUpLadder[i].ClimbingLadderUp += Enable_IN_Objects;
            ND_climbUpLadder[i].ClimbingLadderUp += Disable_EX_Objects;
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
        ND_climbDownLadder.ClimbingLadderDown -= Enable_EX_Objects;
        ND_climbDownLadder.ClimbingLadderDown -= Disable_IN_Objects;

        for (int i = 0; i < ND_climbUpLadder.Length; i++)
        {
            ND_climbUpLadder[i].ClimbingLadderUp -= Enable_IN_Objects;
            ND_climbUpLadder[i].ClimbingLadderUp -= Disable_EX_Objects;
        }
    }
}
