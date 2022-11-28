using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiegeticInventory_Button : MonoBehaviour
{
    //Private Variables
    private bool _inventoryOpen;
    private Vector3 _buttonDefaultPosition;

    //Serialized Variables
    [SerializeField] private Animator ringMenuAnimator;
    [SerializeField] private Transform buttonDefaultTransform;

    public void TriggerDIAnim()
    {
        if (_inventoryOpen == false)
        {
            //Trigger Animation DI_Open
            ringMenuAnimator.SetTrigger("DI_Open");

            //Set inventoryOpen Flag
            _inventoryOpen = true;
        }
        else if (_inventoryOpen == true)
        {
            //Trigger Animation DI_Close
            ringMenuAnimator.SetTrigger("DI_Close");

            //Set inventoryOpen Flag
            _inventoryOpen = false;
        }
    }

    private void Update()
    {
        //Setting the default button pos to the buttonDefaultTransform.position
        _buttonDefaultPosition = buttonDefaultTransform.position;
    }


    public void ResetButtonPosition()
    {
        //Resetting the transforms to the original values
        this.gameObject.transform.position = _buttonDefaultPosition;
    }
}
