using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandOccupationChecker : MonoBehaviour
{
    //Public Variables
    public bool handFull;

    private void OnTriggerStay(Collider other)
    {
        //If Interactable object is in reach of hand
        if (other.gameObject.GetComponentInParent<XRGrabInteractable>() != null)
        {
            //If User is pressing the Select/Grab Button
            if (GetComponent<ActionBasedController>().selectAction.action.ReadValue<float>() > 0)
            {
                //Toggle handFull Flag
                if (handFull == false)
                {
                    handFull = true;
                    //Debug.Log("handFull = " + handFull);
                }
            }
            //If User is NOT pressing the Select/Grab Button
            else if (GetComponentInParent<ActionBasedController>().selectAction.action.ReadValue<float>() == 0)
            {
                //Toggle handFull Flag
                if (handFull == true)
                {
                    handFull = false;
                    //Debug.Log("handFull = " + handFull);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //If Interactable object is leaving the reach of hand
        if (other.gameObject.GetComponentInParent<XRGrabInteractable>() != null)
        {
            //Toggle handFull Flag
            if (handFull == true)
            {
                handFull = false;
                //Debug.Log("handFull = " + handFull);
            }
        }
    }
}
