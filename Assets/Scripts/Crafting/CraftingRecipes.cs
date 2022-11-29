using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingRecipes : MonoBehaviour
{
    //Serialized Variables
    [SerializeField] private CraftingSlot craftingSlot_L;
    [SerializeField] private CraftingSlot craftingSlot_R;
    [SerializeField] private Stage_1_7 stage_1_7;
    [SerializeField] private Stage_3_4 stage_3_4;

    //Public Variables
    public bool craftingOngoing;

    //Private Variables
    private WitchSenses _witchSenses_L;
    private WitchSenses _witchSenses_R;

    //Events
    public event Action DestroyCraftingIngredients;
    public event Action RefreshSocketInteractors;

    private void Start()
    {
        //Find Reference to both WitchSenses script (Right & Left Hands)
        _witchSenses_L = GameObject.FindGameObjectWithTag("LeftHand").GetComponent<WitchSenses>();
        _witchSenses_R = GameObject.FindGameObjectWithTag("RightHand").GetComponent<WitchSenses>();
    }


    private void Update()
    {
        //Checking if both crafting slots are occupied and ready
        if (craftingSlot_L.craftingReady && craftingSlot_R.craftingReady)
        {
            //If crafting is not alreay ongoing
            if (craftingOngoing == false)
            {
                //Mark crafting as ongoing
                craftingOngoing = true;

                //Begin the crafting process
                StartCoroutine(CraftingProcess(0.25f));
            }
        }
    }

    private IEnumerator CraftingProcess(float waitSeconds)
    {
        yield return new WaitForSeconds(waitSeconds);

        Debug.Log("NOW CRAFTING!...");

        //If both slots are filled with an ingredietn
        if (craftingSlot_L.craftingItem != null && craftingSlot_R.craftingItem != null)
        {
            //Checking for ingredient item property & recipes
            //Recipe - BANDAGE 1
            if (craftingSlot_L.craftingItem.GetComponent<ItemController>().Item.id == 1 &&
                craftingSlot_R.craftingItem.GetComponent<ItemController>().Item.id == 2)
            {
                //Remove Ingredients from Witch Senses List
                _witchSenses_L.highlightedObjects.Remove(craftingSlot_L.craftingItem);
                _witchSenses_L.highlightedObjects.Remove(craftingSlot_R.craftingItem);
                _witchSenses_R.highlightedObjects.Remove(craftingSlot_R.craftingItem);
                _witchSenses_R.highlightedObjects.Remove(craftingSlot_L.craftingItem);

                //Destroy Ingredients (via Event)
                DestroyCraftingIngredients();

                Debug.Log("Item Crafted: Bandages");

                //Instantiate Bandages
                Instantiate(ResourceManager.Instance.bandages, transform.position, transform.rotation);

                //Advance Task Stage_1_7 to Stage_1_8
                stage_1_7.ToggleStageAdvancingFlag();

            }
            //Recipe - BANDAGE 2
            else if (craftingSlot_L.craftingItem.GetComponent<ItemController>().Item.id == 2 &&
                    craftingSlot_R.craftingItem.GetComponent<ItemController>().Item.id == 1)
            {
                //Remove Ingredients from Witch Senses List
                _witchSenses_L.highlightedObjects.Remove(craftingSlot_L.craftingItem);
                _witchSenses_L.highlightedObjects.Remove(craftingSlot_R.craftingItem);
                _witchSenses_R.highlightedObjects.Remove(craftingSlot_R.craftingItem);
                _witchSenses_R.highlightedObjects.Remove(craftingSlot_L.craftingItem);

                //Destroy Ingredients (via Event)
                DestroyCraftingIngredients();

                Debug.Log("Item Crafted: Bandages");

                //Instantiate Bandages
                Instantiate(ResourceManager.Instance.bandages, transform.position, transform.rotation);

                //Advance Task Stage_1_7 to Stage_1_8
                stage_1_7.ToggleStageAdvancingFlag();

            }
            //Recipe - TOTEM
            else if (craftingSlot_L.craftingItem.GetComponent<ItemController>().Item.id == 5 &&
                    craftingSlot_R.craftingItem.GetComponent<ItemController>().Item.id == 5)
            {
                //Remove Ingredients from Witch Senses List
                _witchSenses_L.highlightedObjects.Remove(craftingSlot_L.craftingItem);
                _witchSenses_L.highlightedObjects.Remove(craftingSlot_R.craftingItem);
                _witchSenses_R.highlightedObjects.Remove(craftingSlot_R.craftingItem);
                _witchSenses_R.highlightedObjects.Remove(craftingSlot_L.craftingItem);

                //Destroy Ingredients (via Event)
                DestroyCraftingIngredients();

                //Advance Stage_3_4 counter
                stage_3_4.totemsCrafted += 1;

                //Craft Totem
                Instantiate(ResourceManager.Instance.witchTotems[stage_3_4.totemsCrafted - 1], transform.position, transform.rotation);

                Debug.Log("Item Crafted: Witch Totem");

                //Advance Stage_3_4
                if (StageManager.Instance.currentStage == stage_3_4)
                {
                    stage_3_4.ToggleStageAdvancingFlag();
                }

            }
            //Recipe - UNDEFINED
            else
            {
                Debug.Log("UNDEFINED RECIPE, THIS IS NOT ALLOWED!");
            }

            //Mark crafting as finished
            craftingOngoing = false;

            Debug.Log("...CRAFTING FINISHED!");
        }
        else
        {
            Debug.Log("One crafting slot is empty!");
            RefreshSocketInteractors();
        }
    }


























    ////Public Variables
    //public CraftingSlot _craftingSlot_1;
    //public CraftingSlot _craftingSlot_2;
    //
    ////Serialized Variables
    //[SerializeField] private Stage_1_7 stage_1_7;
    //[SerializeField] private Stage_3_4 stage_3_4;
    //private WitchSenses _witchSenses_R;
    //private WitchSenses _witchSenses_L;
    //private bool _craftingOngoig;
    //
    ////Events
    //public event Action DestroyCraftingIngredient;
    //
    //private void Update()
    //{
    //    if (_craftingSlot_1.readyForCrafting == true && _craftingSlot_2.readyForCrafting)
    //    {
    //        if (_craftingOngoig == false)
    //        {
    //            _craftingOngoig = true;
    //            Craft();
    //        }
    //    }
    //}
    //
    //public void Craft()
    //{
    //    Debug.Log("Crafting Function was called!");
    //
    //    //Bandage Recipe 1
    //    if (_craftingSlot_1.itemType.id == 1 && _craftingSlot_2.itemType.id == 2 
    //        && _craftingSlot_1.itemInSlot != _craftingSlot_2.itemInSlot)
    //    {
    //        //Remove Crafting Ingredients from WitcHand's highlighted Object List
    //        _witchSenses_R.highlightedObjects.Remove(_craftingSlot_1.itemInSlot);
    //        _witchSenses_L.highlightedObjects.Remove(_craftingSlot_1.itemInSlot);
    //        _witchSenses_R.highlightedObjects.Remove(_craftingSlot_2.itemInSlot);
    //        _witchSenses_L.highlightedObjects.Remove(_craftingSlot_2.itemInSlot);
    //
    //        //Fire Ingredient Destroy Event
    //        DestroyCraftingIngredient();
    //
    //        //Craft Bandages
    //        Instantiate(ResourceManager.Instance.bandages, transform.position, transform.rotation);
    //    
    //        //Advance Task Stage_1_7 to Stage_1_8
    //        stage_1_7.ToggleStageAdvancingFlag();
    //    
    //        Debug.Log("Bandages have been crafted!");
    //        _craftingOngoig = false;
    //    }
    //    //Bandage Recipe 2
    //    else if (_craftingSlot_2.itemType.id == 2 && _craftingSlot_1.itemType.id == 1 &&
    //        _craftingSlot_1.itemInSlot != _craftingSlot_2.itemInSlot)
    //    {
    //        //Remove Crafting Ingredients from WitcHand's highlighted Object List
    //        _witchSenses_R.highlightedObjects.Remove(_craftingSlot_1.itemInSlot);
    //        _witchSenses_L.highlightedObjects.Remove(_craftingSlot_1.itemInSlot);
    //        _witchSenses_R.highlightedObjects.Remove(_craftingSlot_2.itemInSlot);
    //        _witchSenses_L.highlightedObjects.Remove(_craftingSlot_2.itemInSlot);
    //
    //        //Fire Ingredient Destroy Event
    //        DestroyCraftingIngredient();
    //
    //        //Craft Bandages
    //        Instantiate(ResourceManager.Instance.bandages, transform.position, transform.rotation);
    //    
    //        //Advance Task Stage_1_7 to Stage_1_8
    //        stage_1_7.ToggleStageAdvancingFlag();
    //    
    //        Debug.Log("Bandages have been crafted!");
    //        _craftingOngoig = false;
    //    }
    //    //Witch Totem Recipe
    //    else if (_craftingSlot_2.itemType.id == 5 && _craftingSlot_1.itemType.id == 5 && 
    //        _craftingSlot_1.itemInSlot != _craftingSlot_2.itemInSlot)
    //    {
    //        //Remove Crafting Ingredients from WitcHand's highlighted Object List
    //        _witchSenses_R.highlightedObjects.Remove(_craftingSlot_1.itemInSlot);
    //        _witchSenses_L.highlightedObjects.Remove(_craftingSlot_1.itemInSlot);
    //        _witchSenses_R.highlightedObjects.Remove(_craftingSlot_2.itemInSlot);
    //        _witchSenses_L.highlightedObjects.Remove(_craftingSlot_2.itemInSlot);
    //
    //        //Fire Ingredient Destroy Event
    //        DestroyCraftingIngredient();
    //
    //        stage_3_4.totemsCrafted += 1;
    //    
    //        //Craft Totem
    //        Instantiate(ResourceManager.Instance.witchTotems[stage_3_4.totemsCrafted - 1], transform.position, transform.rotation);
    //    
    //        //Advance Stage_3_4
    //        if (StageManager.Instance.currentStage == stage_3_4)
    //        {
    //            stage_3_4.ToggleStageAdvancingFlag();
    //        }
    //    
    //        Debug.Log("Totem has been crafted!");
    //        _craftingOngoig = false;
    //    }
    //}
    //
    //private void Start()
    //{
    //    //Find Reference to both WitchSenses script (Right & Left Hands)
    //    _witchSenses_R = GameObject.FindGameObjectWithTag("RightHand").GetComponent<WitchSenses>();
    //    _witchSenses_L = GameObject.FindGameObjectWithTag("LeftHand").GetComponent<WitchSenses>();
    //}
}
