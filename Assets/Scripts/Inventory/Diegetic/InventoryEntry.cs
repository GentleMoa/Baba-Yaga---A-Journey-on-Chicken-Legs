using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryEntry : MonoBehaviour
{
    //Public Variables
    public GameObject enteredObject;

    //Serialized Variables
    [SerializeField] private RingMenuSlot[] slots;

    private void OnTriggerEnter(Collider other)
    {
        //Check if object has ItemController component
        if (other.gameObject.GetComponent<ItemController>() != null)
        {
            //Assigning the object entering the trigger collider to the enteredObject varible
            enteredObject = other.gameObject;

            //Deactivate the enteredObject or it's renderer
            enteredObject.SetActive(false);

            //Switch structure to trigger behavior depending on the Item.id of the enteredObject
            switch (enteredObject.GetComponent<ItemController>().Item.id)
            {
                case 1: //If the enteredObject is the "Borage" Item

                    Debug.Log("BORAGE was added to the inventory");

                    //Cycle through the RingMenuSlot Scripts until finding the one that handles the "Borage" item(s)
                    for (int i = 0; i < slots.Length; i++)
                    {
                        if (slots[i].handledItem == RingMenuSlot.HandledItem.Borage)
                        {
                            //Add the enteredObject aka the "Borage" item to the RingMenuSlot Scripts' List of stashed Items
                            slots[i].stashedItems.Add(enteredObject);

                            //Calling the UpdateItemQuantityDisplay Function to clear and update the 3D number displaying the respective item quantity
                            slots[i].UpdateItemQuantityDisplay();
                        }
                    }

                    break;

                case 2: //If the enteredObject is the "Wool Plant" Item
                    Debug.Log("WOOL PLANT was added to the inventory");

                    //Cycle through the RingMenuSlot Scripts until finding the one that handles the "Wool Plant" item(s)
                    for (int i = 0; i < slots.Length; i++)
                    {
                        if (slots[i].handledItem == RingMenuSlot.HandledItem.WoolPlant)
                        {
                            //Add the enteredObject aka the "Wool Plant" item to the RingMenuSlot Scripts' List of stashed Items
                            slots[i].stashedItems.Add(enteredObject);

                            //Calling the UpdateItemQuantityDisplay Function to clear and update the 3D number displaying the respective item quantity
                            slots[i].UpdateItemQuantityDisplay();
                        }
                    }

                    break;

                case 3: //If the enteredObject is the "Bandages" Item
                    Debug.Log("BANDAGES was added to the inventory");

                    //Cycle through the RingMenuSlot Scripts until finding the one that handles the "Bandages" item(s)
                    for (int i = 0; i < slots.Length; i++)
                    {
                        if (slots[i].handledItem == RingMenuSlot.HandledItem.Bandages)
                        {
                            //Add the enteredObject aka the "Bandages" item to the RingMenuSlot Scripts' List of stashed Items
                            slots[i].stashedItems.Add(enteredObject);

                            //Calling the UpdateItemQuantityDisplay Function to clear and update the 3D number displaying the respective item quantity
                            slots[i].UpdateItemQuantityDisplay();
                        }
                    }

                    break;

                case 4: //If the enteredObject is the "Wondersprout Seed" Item
                    Debug.Log("WONDERSPROUT SEED was added to the inventory");

                    //Cycle through the RingMenuSlot Scripts until finding the one that handles the "Wondersprout Seed" item(s)
                    for (int i = 0; i < slots.Length; i++)
                    {
                        if (slots[i].handledItem == RingMenuSlot.HandledItem.Seed)
                        {
                            //Add the enteredObject aka the "Wondersprout Seed" item to the RingMenuSlot Scripts' List of stashed Items
                            slots[i].stashedItems.Add(enteredObject);

                            //Calling the UpdateItemQuantityDisplay Function to clear and update the 3D number displaying the respective item quantity
                            slots[i].UpdateItemQuantityDisplay();
                        }
                    }

                    break;

                case 5: //If the enteredObject is the "Stick" Item
                    Debug.Log("STICK was added to the inventory");

                    //Cycle through the RingMenuSlot Scripts until finding the one that handles the "Stick" item(s)
                    for (int i = 0; i < slots.Length; i++)
                    {
                        if (slots[i].handledItem == RingMenuSlot.HandledItem.Stick)
                        {
                            //Add the enteredObject aka the "Stick" item to the RingMenuSlot Scripts' List of stashed Items
                            slots[i].stashedItems.Add(enteredObject);

                            //Calling the UpdateItemQuantityDisplay Function to clear and update the 3D number displaying the respective item quantity
                            slots[i].UpdateItemQuantityDisplay();
                        }
                    }

                    break;

                case 6: //If the enteredObject is the "Totem" Item
                    Debug.Log("TOTEM was added to the inventory");

                    //Cycle through the RingMenuSlot Scripts until finding the one that handles the "Totem" item(s)
                    for (int i = 0; i < slots.Length; i++)
                    {
                        if (slots[i].handledItem == RingMenuSlot.HandledItem.Totem)
                        {
                            //Add the enteredObject aka the "Totem" item to the RingMenuSlot Scripts' List of stashed Items
                            slots[i].stashedItems.Add(enteredObject);

                            //Calling the UpdateItemQuantityDisplay Function to clear and update the 3D number displaying the respective item quantity
                            slots[i].UpdateItemQuantityDisplay();
                        }
                    }

                    break;
            }
        }

        Debug.Log(other.gameObject.name + " doesn't have the ItemController component --> It is no stashable Item!");
    }
}
