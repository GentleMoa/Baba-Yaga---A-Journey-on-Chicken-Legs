using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class HandOccupationChecker : MonoBehaviour
{
    //Serialized Variables
    [SerializeField] private InputActionReference input_grabButton;

    //Private Variables
    private bool objectCloseToHand;

    //Public Variables
    //[HideInInspector]
    public bool handFull = false;
    public GameObject storedObject;

    //If object is entering the range of the hand...
    private void OnTriggerEnter(Collider other)
    {
        //If object is an XR Grab Interactable and there was NO object close to it before... 
        if (other.gameObject.GetComponent<XRGrabInteractable>() != null && objectCloseToHand == false)
        {
            //Toggle the Flag
            objectCloseToHand = true;

            //Save reference to the held Item
            storedObject = other.gameObject;
        }
    }

    void Update()
    {
        //If there is an object close to the hand...
        if (objectCloseToHand == true)
        {
            //If the grab button is being pressed and the hand was NOT marked as full before...
            if (input_grabButton.action.ReadValue<float>() > 0 && handFull == false)
            {
                //Toggle the Flag
                handFull = true;
            }
        }

        //If the grab button is NOT being pressed and the hand was marked as full before...
        if (input_grabButton.action.ReadValue<float>() == 0 && handFull == true)
        {
            //Toggle the Flag
            handFull = false;
        }
    }

    public void ClearStorageVariable()
    {
        //Clear the storage variable
        storedObject = null;
    }

    private void OnTriggerExit(Collider other)
    {
        //If object is an XR Grab Interactable and there was NO object close to it before... 
        if (other.gameObject.GetComponent<XRGrabInteractable>() != null && objectCloseToHand == true)
        {
            //Toggle the Flag
            objectCloseToHand = false;
        }
    }



























    ////Public Variables
    //public bool handFull;
    //
    //private void OnTriggerStay(Collider other)
    //{
    //    //If Interactable object is in reach of hand
    //    if (other.gameObject.GetComponentInParent<XRGrabInteractable>() != null)
    //    {
    //        //If User is pressing the Select/Grab Button
    //        if (GetComponent<ActionBasedController>().selectAction.action.ReadValue<float>() > 0)
    //        {
    //            //Toggle handFull Flag
    //            if (handFull == false)
    //            {
    //                handFull = true;
    //                //Debug.Log("handFull = " + handFull);
    //            }
    //        }
    //        //If User is NOT pressing the Select/Grab Button
    //        else if (GetComponentInParent<ActionBasedController>().selectAction.action.ReadValue<float>() == 0)
    //        {
    //            //Toggle handFull Flag
    //            if (handFull == true)
    //            {
    //                handFull = false;
    //                //Debug.Log("handFull = " + handFull);
    //            }
    //        }
    //    }
    //}
    //
    //private void OnTriggerExit(Collider other)
    //{
    //    //If Interactable object is leaving the reach of hand
    //    if (other.gameObject.GetComponentInParent<XRGrabInteractable>() != null)
    //    {
    //        //Toggle handFull Flag
    //        if (handFull == true)
    //        {
    //            handFull = false;
    //            //Debug.Log("handFull = " + handFull);
    //        }
    //    }
    //}
}
