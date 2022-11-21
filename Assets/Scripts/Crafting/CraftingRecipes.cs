using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingRecipes : MonoBehaviour
{
    //Public Variables
    public CraftingSlot _craftingSlot_1;
    public CraftingSlot _craftingSlot_2;

    public void Craft()
    {
        //ADD DELAY VIA COROUTINE?

        if (_craftingSlot_1.itemInSlot != null && _craftingSlot_2.itemInSlot != null)
        {
            //Bandage Recipe 1
            if (_craftingSlot_1.itemType.itemName == "Borage" && _craftingSlot_2.itemType.itemName == "Wool Plant")
            {
                //Destroy Crafting Ingredients
                _craftingSlot_1.DestroyItemInSlot();
                _craftingSlot_2.DestroyItemInSlot();

                //Craft Bandages
                Instantiate(ResourceManager.Instance.bandages, transform.position, transform.rotation);

                Debug.Log("Bandages have been crafted!");
            }
            if (_craftingSlot_2.itemType.itemName == "Borage" && _craftingSlot_1.itemType.itemName == "Wool Plant")
            {
                //Destroy Crafting Ingredients
                _craftingSlot_1.DestroyItemInSlot();
                _craftingSlot_2.DestroyItemInSlot();

                //Craft Bandages
                Instantiate(ResourceManager.Instance.bandages, transform.position, transform.rotation);

                Debug.Log("Bandages have been crafted!");
            }

            //Witch Totem Recipe


            Debug.Log("This combination of Crafting Ingredients does not work!");
        }

        Debug.Log("At least one Crafting Ingredient is missing!");
    }
}
