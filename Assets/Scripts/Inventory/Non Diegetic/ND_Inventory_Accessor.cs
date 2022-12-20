using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ND_Inventory_Accessor : MonoBehaviour
{
    //Serialized Variables
    [SerializeField] private InputActionReference input_secondaryButton;
    [SerializeField] private ND_Inventory_Accessor oppositeHandScript;
    [SerializeField] private HandOccupationChecker handFullCheckerScript;
    [SerializeField] private GameObject NonDiegetic_Inventory;

    [SerializeField] private ND_I_ItemSlots[] itemSlots;

    //Public Variables
    [HideInInspector]
    public bool _inventoryOpen = false;

    //Private Variables
    private bool _secondaryButtonCooldown = false;
    public GameObject heldObject;
    private ND_Highlighting _highlightingHand_L;
    private ND_Highlighting _highlightingHand_R;
    private AudioSource _audioSource;
    private AudioClip _audioClip_AddItemToInventory;

    void Start()
    {
        //Grab reference to the parent's AudioSource
        _audioSource = GetComponent<AudioSource>();

        //Get AudioClips from ResourceManager
        _audioClip_AddItemToInventory = ResourceManager.Instance.audio_hat_inventory_stash;

        //Find Reference to both ND_Highlighting scripts (Right & Left Hands)
        _highlightingHand_L = GameObject.FindGameObjectWithTag("LeftHand").GetComponent<ND_Highlighting>();
        _highlightingHand_R = GameObject.FindGameObjectWithTag("RightHand").GetComponent<ND_Highlighting>();
    }

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
            //If this hand is holding an object and it is a stashable object (has the scripted object component of an item)
            if (handFullCheckerScript.handFull == true && heldObject.GetComponent<ItemController>() != null)
            {
                //ADD OBJECT TO INVENTORY
                Debug.Log("Adding item to Inventory: + " + heldObject.name);

                //Play Ding Audio
                _audioSource.clip = _audioClip_AddItemToInventory;
                _audioSource.Play();

                //Switch structure to trigger behavior depending on the Item.id of the enteredObject
                switch (heldObject.GetComponent<ItemController>().Item.id)
                {
                    case 1: //If the enteredObject is the "Borage" Item

                        //Debug.Log("BORAGE was added to the inventory");

                        //Cycle through the RingMenuSlot Scripts until finding the one that handles the "Borage" item(s)
                        for (int i = 0; i < itemSlots.Length; i++)
                        {
                            if (itemSlots[i].handledItem == ND_I_ItemSlots.HandledItem.Borage)
                            {
                                //Add the enteredObject aka the "Borage" item to the RingMenuSlot Scripts' List of stashed Items
                                itemSlots[i].stashedItems.Add(heldObject);

                                //Calling the UpdateItemQuantityDisplay Function to clear and update the 3D number displaying the respective item quantity
                                itemSlots[i].UpdateItemQuantityDisplay();
                            }
                        }

                        break;

                    case 2: //If the enteredObject is the "Wool Plant" Item
                            //Debug.Log("WOOL PLANT was added to the inventory");

                        //Cycle through the RingMenuSlot Scripts until finding the one that handles the "Wool Plant" item(s)
                        for (int i = 0; i < itemSlots.Length; i++)
                        {
                            if (itemSlots[i].handledItem == ND_I_ItemSlots.HandledItem.WoolPlant)
                            {
                                //Add the enteredObject aka the "Wool Plant" item to the RingMenuSlot Scripts' List of stashed Items
                                itemSlots[i].stashedItems.Add(heldObject);

                                //Calling the UpdateItemQuantityDisplay Function to clear and update the 3D number displaying the respective item quantity
                                itemSlots[i].UpdateItemQuantityDisplay();
                            }
                        }

                        break;

                    case 3: //If the enteredObject is the "Bandages" Item
                            //Debug.Log("BANDAGES was added to the inventory");

                        //Cycle through the RingMenuSlot Scripts until finding the one that handles the "Bandages" item(s)
                        for (int i = 0; i < itemSlots.Length; i++)
                        {
                            if (itemSlots[i].handledItem == ND_I_ItemSlots.HandledItem.Bandages)
                            {
                                //Add the enteredObject aka the "Bandages" item to the RingMenuSlot Scripts' List of stashed Items
                                itemSlots[i].stashedItems.Add(heldObject);

                                //Calling the UpdateItemQuantityDisplay Function to clear and update the 3D number displaying the respective item quantity
                                itemSlots[i].UpdateItemQuantityDisplay();
                            }
                        }

                        break;

                    case 4: //If the enteredObject is the "Wondersprout Seed" Item
                            //Debug.Log("WONDERSPROUT SEED was added to the inventory");

                        //Cycle through the RingMenuSlot Scripts until finding the one that handles the "Wondersprout Seed" item(s)
                        for (int i = 0; i < itemSlots.Length; i++)
                        {
                            if (itemSlots[i].handledItem == ND_I_ItemSlots.HandledItem.Seed)
                            {
                                //Add the enteredObject aka the "Wondersprout Seed" item to the RingMenuSlot Scripts' List of stashed Items
                                itemSlots[i].stashedItems.Add(heldObject);

                                //Calling the UpdateItemQuantityDisplay Function to clear and update the 3D number displaying the respective item quantity
                                itemSlots[i].UpdateItemQuantityDisplay();
                            }
                        }

                        break;

                    case 5: //If the enteredObject is the "Stick" Item
                            //Debug.Log("STICK was added to the inventory");

                        //Cycle through the RingMenuSlot Scripts until finding the one that handles the "Stick" item(s)
                        for (int i = 0; i < itemSlots.Length; i++)
                        {
                            if (itemSlots[i].handledItem == ND_I_ItemSlots.HandledItem.Stick)
                            {
                                //Add the enteredObject aka the "Stick" item to the RingMenuSlot Scripts' List of stashed Items
                                itemSlots[i].stashedItems.Add(heldObject);

                                //Calling the UpdateItemQuantityDisplay Function to clear and update the 3D number displaying the respective item quantity
                                itemSlots[i].UpdateItemQuantityDisplay();
                            }
                        }

                        break;

                    case 6: //If the enteredObject is the "Totem" Item
                            //Debug.Log("TOTEM was added to the inventory");

                        //Cycle through the RingMenuSlot Scripts until finding the one that handles the "Totem" item(s)
                        for (int i = 0; i < itemSlots.Length; i++)
                        {
                            if (itemSlots[i].handledItem == ND_I_ItemSlots.HandledItem.Totem)
                            {
                                //Add the enteredObject aka the "Totem" item to the RingMenuSlot Scripts' List of stashed Items
                                itemSlots[i].stashedItems.Add(heldObject);

                                //Calling the UpdateItemQuantityDisplay Function to clear and update the 3D number displaying the respective item quantity
                                itemSlots[i].UpdateItemQuantityDisplay();
                            }
                        }

                        break;
                }

                //Remove the held object from the highlighted objects list
                _highlightingHand_L.highlightedObjects.Remove(this.gameObject);
                _highlightingHand_R.highlightedObjects.Remove(this.gameObject);

                //Disable the held Object
                heldObject.SetActive(false);
                //Clear storage variable
                heldObject = null;
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
