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
    [SerializeField] private FadeTransitions fadeScript;

    //Public Variables
    public bool craftingOngoing;

    //Private Variables
    private WitchSenses _witchSenses_L;
    private WitchSenses _witchSenses_R;
    private AudioSource _audioSource;
    private AudioClip _audioClip_CraftingBandages;
    private AudioClip _audioClip_CraftingTotems;

    //Events
    public event Action DestroyCraftingIngredients;
    public event Action RefreshSocketInteractors;

    private void Start()
    {
        //Find Reference to both WitchSenses script (Right & Left Hands)
        _witchSenses_L = GameObject.FindGameObjectWithTag("LeftHand").GetComponent<WitchSenses>();
        _witchSenses_R = GameObject.FindGameObjectWithTag("RightHand").GetComponent<WitchSenses>();

        //Grab a reference to the audio source
        _audioSource = GetComponent<AudioSource>();

        //Assign the correct audio clips from the ResourceManagers
        _audioClip_CraftingBandages = ResourceManager.Instance.audio_crafting_bandages;
        _audioClip_CraftingTotems = ResourceManager.Instance.audio_crafting_totems;

        //Disabling the right crafting slot in the beginning to avoid the crafting system breaking by placing an ingred in the right slot first
        craftingSlot_R.gameObject.SetActive(false);
    }


    private void Update()
    {
        //if the left slot is filled...
        if (craftingSlot_L.craftingReady == true && craftingSlot_R.gameObject.activeInHierarchy == false)
        {
            //enable the right slot as well
            craftingSlot_R.gameObject.SetActive(true);
        }

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
                //Fade screen to black
                fadeScript.Fade(true);
                //Start Crafting Sequence
                Invoke("NestedCraftingFunction_Bandages_0", 2.0f);
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
                //Fade screen to black
                fadeScript.Fade(true);
                //Start Crafting Sequence
                Invoke("NestedCraftingFunction_Bandages_0", 2.0f);

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
                //Fade screen to black
                fadeScript.Fade(true);
                //Start Crafting Sequence
                Invoke("NestedCraftingFunction_Totems_0", 2.0f);
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

    //Nested functions for sequenced fades / audio / stage advancing
    private void NestedCraftingFunction_Bandages_0()
    {
        Debug.Log("Item Crafted: Bandages");

        //Instantiate Bandages
        Instantiate(ResourceManager.Instance.bandages, transform.position, transform.rotation);

        //Play Audio
        _audioSource.clip = _audioClip_CraftingBandages;
        _audioSource.Play();

        //Invoke next nested crafting sequence function
        Invoke("NestedCraftingFunction_Bandages_1", 7.0f);
    }

    private void NestedCraftingFunction_Bandages_1()
    {
        //Screen fades from black
        fadeScript.Fade(false);

        //Invoke next nested crafting sequence function
        Invoke("NestedCraftingFunction_Bandages_2", 2.0f);
    }

    private void NestedCraftingFunction_Bandages_2()
    {
        //Advance Task Stage_1_7 to Stage_1_8
        stage_1_7.ToggleStageAdvancingFlag();
    }

    private void NestedCraftingFunction_Totems_0()
    {
        //Advance Stage_3_4 counter
        stage_3_4.totemsCrafted += 1;

        //Craft Totem
        Instantiate(ResourceManager.Instance.witchTotems[stage_3_4.totemsCrafted - 1], transform.position, transform.rotation);

        Debug.Log("Item Crafted: Witch Totem");

        //Play Audio
        _audioSource.clip = _audioClip_CraftingTotems;
        _audioSource.Play();

        //Invoke next nested crafting sequence function
        Invoke("NestedCraftingFunction_Totems_1", 4.0f);
    }

    private void NestedCraftingFunction_Totems_1()
    {
        //Screen fades from black
        fadeScript.Fade(false);

        //Invoke next nested crafting sequence function
        Invoke("NestedCraftingFunction_Totems_2", 2.0f);
    }

    private void NestedCraftingFunction_Totems_2()
    {
        //Advance Stage_3_4
        if (StageManager.Instance.currentStage == stage_3_4)
        {
            stage_3_4.ToggleStageAdvancingFlag();
        }
    }

}
