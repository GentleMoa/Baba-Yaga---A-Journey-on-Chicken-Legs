using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ND_Inventory_Accessor : MonoBehaviour
{
    //Serialized Variables
    [SerializeField] private InputActionReference input_secondaryButton;
    [SerializeField] private ND_Inventory_Accessor oppositeHandScript;
    [SerializeField] private HandOccupationChecker handFullCheckerScript;
    [SerializeField] private GameObject NonDiegetic_Inventory;

    [SerializeField] private GameObject heldObject;

    //Public Variables
    [HideInInspector]
    public bool _inventoryOpen = false;

    //Private Variables
    private bool _secondaryButtonCooldown = false;

    void Update()
    {
        //Resetting the button cooldown, when the button is not pressed
        if (input_secondaryButton.action.ReadValue<float>() == 0)
        {
            //Resetting the _secondaryButtonCooldown
            _secondaryButtonCooldown = false;
        }

        //On button press...
        if (input_secondaryButton.action.ReadValue<float>() > 0 && _secondaryButtonCooldown == false)
        {
            //If this hand is holding an object
            if (handFullCheckerScript.handFull == true)
            {
                //ADD OBJECT TO INVENTORY
                Debug.Log("Adding item to Inventory: + " + heldObject.name);
            }
            //If this hand is NOT holding an object
            else if (handFullCheckerScript.handFull == false)
            {
                //OPEN/CLOSE INVENTORY
                //If inventory is not open yet (neither by this or the opposite hand script)...
                if (_inventoryOpen == false || oppositeHandScript._inventoryOpen == false)
                {
                    //Notify this script and the oppsite hands one that the inventory has now been opened
                    _inventoryOpen = true;
                    oppositeHandScript._inventoryOpen = true;

                    //OPEN INVENTORY
                    Debug.Log("Opening Inventory!");
                    NonDiegetic_Inventory.SetActive(true);
                }
                //Else if the inventory is already open...
                else if (_inventoryOpen == true)
                {
                    //Notify this script and the oppsite hands one that the inventory has now been closed
                    _inventoryOpen = false;
                    oppositeHandScript._inventoryOpen = false;

                    //CLOSE INVENTORY
                    Debug.Log("Closing Inventory!");
                    NonDiegetic_Inventory.SetActive(false);
                }
            }

            //Activating the _secondaryButtonCooldown
            _secondaryButtonCooldown = true;
        }
    }

    public void SaveReferenceOfHeldObject()
    {
        Debug.Log("Reference saved: " + handFullCheckerScript.storedObject);
        heldObject = handFullCheckerScript.storedObject;
    }

    public void DeleteReferenceOfHeldObject()
    {
        Debug.Log("Reference deleted: " + heldObject);
        heldObject = null;
    }
}
