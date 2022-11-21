using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingSlot : MonoBehaviour
{
    //Public Variables
    public GameObject itemInSlot;
    public Item itemType;

    private void OnTriggerEnter(Collider other)
    {
        itemInSlot = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        itemInSlot = null;
    }

    public void AccessItemData()
    {
        //Access the Item's Data from it's Scriptable Object
        if (itemInSlot.GetComponent<ItemController>() != null)
        {
            itemType = itemInSlot.GetComponent<ItemController>().Item;
        }
    }

    public void DestroyItemInSlot()
    {
        Destroy(itemInSlot);
    }
}
