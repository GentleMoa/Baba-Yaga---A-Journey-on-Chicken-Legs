using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingRecipes : MonoBehaviour
{
    //Public Variables
    public CraftingSlot _craftingSlot_1;
    public CraftingSlot _craftingSlot_2;
    public bool bandagesCrafted;

    //Serialized Variables
    [SerializeField] private Stage_1_7 stage_1_7;
    [SerializeField] private Stage_3_4 stage_3_4;
    private WitchSenses _witchSenses_R;
    private WitchSenses _witchSenses_L;

    //Events
    public event Action DestroyCraftingIngredient;

    public void Craft()
    {
        //ADD DELAY VIA COROUTINE?

        if (_craftingSlot_1.itemInSlot != null && _craftingSlot_2.itemInSlot != null)
        {
            //Bandage Recipe 1
            if (_craftingSlot_1.itemType.id == 1 && _craftingSlot_2.itemType.id == 2)
            {
                //Remove Crafting Ingredients from WitcHand's highlighted Object List
                _witchSenses_R.highlightedObjects.Remove(_craftingSlot_1.itemInSlot);
                _witchSenses_L.highlightedObjects.Remove(_craftingSlot_1.itemInSlot);
                _witchSenses_R.highlightedObjects.Remove(_craftingSlot_2.itemInSlot);
                _witchSenses_L.highlightedObjects.Remove(_craftingSlot_2.itemInSlot);

                //Set Flag to initiate Ingredient Destruction after Crafting
                bandagesCrafted = true;

                //Craft Bandages
                Instantiate(ResourceManager.Instance.bandages, transform.position, transform.rotation);

                //Advance Task Stage_1_7 to Stage_1_8
                stage_1_7.ToggleStageAdvancingFlag();

                Debug.Log("Bandages have been crafted!");
            }
            //Bandage Recipe 2
            else if (_craftingSlot_2.itemType.id == 2 && _craftingSlot_1.itemType.id == 1)
            {
                //Remove Crafting Ingredients from WitcHand's highlighted Object List
                _witchSenses_R.highlightedObjects.Remove(_craftingSlot_1.itemInSlot);
                _witchSenses_L.highlightedObjects.Remove(_craftingSlot_1.itemInSlot);
                _witchSenses_R.highlightedObjects.Remove(_craftingSlot_2.itemInSlot);
                _witchSenses_L.highlightedObjects.Remove(_craftingSlot_2.itemInSlot);

                //Set Flag to initiate Ingredient Destruction after Crafting
                bandagesCrafted = true;

                //Craft Bandages
                Instantiate(ResourceManager.Instance.bandages, transform.position, transform.rotation);

                //Advance Task Stage_1_7 to Stage_1_8
                stage_1_7.ToggleStageAdvancingFlag();

                Debug.Log("Bandages have been crafted!");
            }
            //Witch Totem Recipe
            else if (_craftingSlot_2.itemType.id == 5 && _craftingSlot_1.itemType.id == 5)
            {
                //Remove Crafting Ingredients from WitcHand's highlighted Object List
                _witchSenses_R.highlightedObjects.Remove(_craftingSlot_1.itemInSlot);
                _witchSenses_L.highlightedObjects.Remove(_craftingSlot_1.itemInSlot);
                _witchSenses_R.highlightedObjects.Remove(_craftingSlot_2.itemInSlot);
                _witchSenses_L.highlightedObjects.Remove(_craftingSlot_2.itemInSlot);

                stage_3_4.totemsCrafted += 1;

                //Craft Totem
                Instantiate(ResourceManager.Instance.witchTotems[stage_3_4.totemsCrafted - 1], transform.position, transform.rotation);

                //Advance Stage_3_4
                if (StageManager.Instance.currentStage == stage_3_4)
                {
                    stage_3_4.ToggleStageAdvancingFlag();
                }

                Debug.Log("Totem has been crafted!");
            }


            Debug.Log("This combination of Crafting Ingredients does not work!");
        }

        Debug.Log("At least one Crafting Ingredient is missing!");
    }

    public void PostCraftingIngredDestruction()
    {
        if (bandagesCrafted == true)
        {
            //Fire "DestroyCraftingIngredients" Event
            DestroyCraftingIngredient();

            //Reset Flag
            bandagesCrafted = false;
        }
    }

    private void Start()
    {
        //Find Reference to both WitchSenses script (Right & Left Hands)
        _witchSenses_R = GameObject.FindGameObjectWithTag("RightHand").GetComponent<WitchSenses>();
        _witchSenses_L = GameObject.FindGameObjectWithTag("LeftHand").GetComponent<WitchSenses>();
    }
}
