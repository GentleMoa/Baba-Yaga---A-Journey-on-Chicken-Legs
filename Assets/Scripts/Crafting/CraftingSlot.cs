using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingSlot : MonoBehaviour
{
    //Public Variables
    public GameObject itemInSlot;
    public Item itemType;

    //Serialized Variables
    [SerializeField] private CraftingRecipes craftingRecipes;
    [SerializeField] private CraftingSlot oppositeCraftingSlot;

    //Private Variables
    private bool itemDestroyed;

    private void Start()
    {
        //Subscribing to the CraftingRecipes' Event
        craftingRecipes.DestroyCraftingIngredient += DisableItemInSlot;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Save Item reference that enters the trigger collider to a variable
        itemInSlot = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        //Free up itemInSlot variable again
        itemInSlot = null;
    }

    public void AccessItemData()
    {
        //Access the Item's Data from it's Scriptable Object
        if (itemInSlot.GetComponent<ItemController>() != null)
        {
            itemType = itemInSlot.GetComponent<ItemController>().Item;

            itemDestroyed = false;
        }
    }

    public void DisableItemInSlot()
    {
        if (itemDestroyed == false)
        {
            itemDestroyed = true;

            Debug.Log(itemInSlot.name + " is now destroyed!");

            //Destroy the itemInSlot of this Socket Interactor
            itemInSlot.SetActive(false);
            //Destroy the itemInSlot of the opposite Socket Interactor
            oppositeCraftingSlot.DisableItemInSlot();

            //Free up itemInSlot variable again
            itemInSlot = null;
        }
    }

    private void OnDisable()
    {
        //Unsubscribing from the CraftingRecipes' Event
        craftingRecipes.DestroyCraftingIngredient -= DisableItemInSlot;
    }
}
