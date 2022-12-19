using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ND_CraftingSlot : MonoBehaviour
{
    //Serialized Variables
    [SerializeField] private ND_CraftingRecipes ND_craftingRecipeScript;

    //Public Variables
    public GameObject craftingItem;
    public bool craftingReady;

    private void Start()
    {
        //Subscribe function to craftingRecipeScript's event
        ND_craftingRecipeScript.DestroyCraftingIngredients += ClearAndDestroyIngredient;
        ND_craftingRecipeScript.RefreshSocketInteractors += ResetSocketInteractor;
    }

    private void OnTriggerEnter(Collider other)
    {
        //If the object entering the crafting slot is an interactable task item
        if (other.gameObject.GetComponent<ItemController>() != null)
        {
            //If that item is either a "Borage" || "Wool Plant" || "Stick"
            if (other.gameObject.GetComponent<ItemController>().Item.id == 1 ||
                other.gameObject.GetComponent<ItemController>().Item.id == 2 ||
                other.gameObject.GetComponent<ItemController>().Item.id == 5)
            {
                //If the storage Variables is empty
                if (craftingItem == null)
                {
                    //Saving this item into a storage variable
                    craftingItem = other.gameObject;
                    Debug.Log(gameObject.name + ", craftingItem:" + craftingItem.name);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //If the object leaving the crafting slot is an interactable task item
        if (other.gameObject.GetComponent<ItemController>() != null)
        {
            //If that item is either a "Borage" || "Wool Plant" || "Stick"
            if (other.gameObject.GetComponent<ItemController>().Item.id == 1 ||
                other.gameObject.GetComponent<ItemController>().Item.id == 2 ||
                other.gameObject.GetComponent<ItemController>().Item.id == 5)
            {
                //If the storage Variables is already occupied
                if (craftingItem != null)
                {
                    //Clear the storage variable
                    craftingItem = null;

                    Debug.Log("craftingItem cleared!");
                }
            }
        }
    }

    public void IndicateCraftingState (bool ready)
    {
        //Set flag to indicate readiness for crafting procedure in craftingRecipeScript
        craftingReady = ready;
        Debug.Log(gameObject.name + ", craftingReady: " + ready);
    }

    private void ClearAndDestroyIngredient()
    {
        //Set flag to indicate readiness for crafting procedure in craftingRecipeScript
        craftingReady = false;

        //Disabling the XR Socket Interactor component
        GetComponent<XRSocketInteractor>().enabled = false;

        //Destroying the crafting Ingredient
        Destroy(craftingItem);

        //Clear the storage variable
        craftingItem = null;

        //Re-enabling the XR Socket Interactor component
        GetComponent<XRSocketInteractor>().enabled = true;

        Debug.Log("Crafting Ingredient successfully cleared and destroyed!");
    }

    private void ResetSocketInteractor()
    {
        //Disabling the XR Socket Interactor component
        GetComponent<XRSocketInteractor>().enabled = false;

        //Re-enabling the XR Socket Interactor component
        GetComponent<XRSocketInteractor>().enabled = true;
    }

    private void OnDisable()
    {
        //Unsubscribe function from craftingRecipeScript's event
        ND_craftingRecipeScript.DestroyCraftingIngredients -= ClearAndDestroyIngredient;
        ND_craftingRecipeScript.RefreshSocketInteractors -= ResetSocketInteractor;
    }


























    ////Public Variables
    //public GameObject itemInSlot;
    //public Item itemType;
    //public bool craftingInitiated;
    //public bool readyForCrafting;
    //
    ////Serialized Variables
    //[SerializeField] private CraftingRecipes craftingRecipes;
    //[SerializeField] private CraftingSlot oppositeCraftingSlot;
    //
    ////Private Variables
    //private bool itemDestroyed;
    //
    //private void Start()
    //{
    //    //Subscribing to the CraftingRecipes' Event
    //    craftingRecipes.DestroyCraftingIngredient += DisableItemInSlot;
    //}
    //
    //private void OnTriggerEnter(Collider other)
    //{
    //    //Save Item reference that enters the trigger collider to a variable
    //    if (other.gameObject.GetComponent<ItemController>() != null)
    //    {
    //        if (other.gameObject.GetComponent<ItemController>().Item.id == 1 ||
    //            other.gameObject.GetComponent<ItemController>().Item.id == 2 ||
    //            other.gameObject.GetComponent<ItemController>().Item.id == 5)
    //        {
    //            itemInSlot = other.gameObject;
    //
    //            Debug.Log(gameObject.name + ", Item in Slot: " + itemInSlot.name);
    //
    //            //Call AccessItemData function
    //            AccessItemData();
    //            //Call FakeSocketInteractor function
    //            FakeSocketInteractor();
    //
    //            readyForCrafting = true;
    //        }
    //    }
    //}
    //
    //private void OnTriggerStay(Collider other)
    //{
    //    ////If both slots are filled with items
    //    //if (itemInSlot != null && oppositeCraftingSlot.itemInSlot != null)
    //    //{
    //    //    if (craftingInitiated == false)
    //    //    {
    //    //        //Call crafting function in CraftingRecipes
    //    //        craftingRecipes.Craft();
    //    //
    //    //        //Set Flag
    //    //        craftingInitiated = true;
    //    //    }
    //    //}
    //}
    //
    //private void OnTriggerExit(Collider other)
    //{
    //    if (itemInSlot != null)
    //    {
    //        //Enable rigidbody
    //        itemInSlot.GetComponent<Rigidbody>().isKinematic = false;
    //
    //        //Free up storage variables again
    //        itemType = null;
    //        itemInSlot = null;
    //
    //        readyForCrafting = false;
    //    }
    //}
    //
    //public void AccessItemData()
    //{
    //    //Access the Item's Data from it's Scriptable Object
    //    if (itemInSlot.GetComponent<ItemController>() != null)
    //    {
    //        itemType = itemInSlot.GetComponent<ItemController>().Item;
    //
    //        itemDestroyed = false;
    //
    //        Debug.Log(gameObject.name + ", Data of " + itemInSlot + " successfully accessed!");
    //    }
    //}
    //
    //private void FakeSocketInteractor()
    //{
    //    //Disable rigidbody
    //    itemInSlot.GetComponent<Rigidbody>().isKinematic = true;
    //    //Set position to the fake socket
    //    itemInSlot.transform.position = transform.position;
    //
    //    //Change rotation based on item
    //    switch (itemInSlot.GetComponent<ItemController>().Item.id)
    //    {
    //        case 1: //Borage
    //            itemInSlot.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);
    //            break;
    //
    //        case 2: //Wool Plant
    //            //No rotation required
    //            break;
    //
    //        case 3: //Stick
    //            itemInSlot.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);
    //            break;
    //    }
    //}
    //
    //public void DisableItemInSlot()
    //{
    //    if (itemDestroyed == false)
    //    {
    //        itemDestroyed = true;
    //    
    //        Debug.Log(gameObject.name + ", " + itemInSlot.name + " is now destroyed!");
    //    
    //        //Destroy the itemInSlot of this Socket Interactor
    //        itemInSlot.SetActive(false);
    //
    //        //Reset Flag
    //        craftingInitiated = false;
    //
    //        //Free up storage variables again
    //        itemType = null;
    //        itemInSlot = null;
    //    }
    //}
    //
    //private void OnDisable()
    //{
    //    //Unsubscribing from the CraftingRecipes' Event
    //    craftingRecipes.DestroyCraftingIngredient -= DisableItemInSlot;
    //}
}
