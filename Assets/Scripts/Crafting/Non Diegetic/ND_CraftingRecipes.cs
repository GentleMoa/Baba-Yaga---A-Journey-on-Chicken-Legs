using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ND_CraftingRecipes : MonoBehaviour
{
    //Serialized Variables
    [SerializeField] private ND_CraftingSlot ND_craftingSlot_L;
    [SerializeField] private ND_CraftingSlot ND_craftingSlot_R;
    [SerializeField] private ND_Stage_1_7 ND_stage_1_7;
    [SerializeField] private ND_Stage_3_4 ND_stage_3_4;
    [SerializeField] private FadeTransitions fadeScript;

    //Public Variables
    public bool craftingOngoing;

    //Private Variables
    private ND_Highlighting _highlightingScript_L;
    private ND_Highlighting _highlightingScript_R;
    private AudioSource _audioSource;
    private AudioClip _audioClip_CraftingBandages;
    private AudioClip _audioClip_CraftingTotems;

    //Events
    public event Action RefreshSocketInteractors;

    private void Start()
    {
        //Find Reference to both ND_Highlighting scripts (Right & Left Hands)
        _highlightingScript_L = GameObject.FindGameObjectWithTag("LeftHand").GetComponent<ND_Highlighting>();
        _highlightingScript_R = GameObject.FindGameObjectWithTag("RightHand").GetComponent<ND_Highlighting>();

        //Grab a reference to the audio source
        _audioSource = GetComponent<AudioSource>();

        //Assign the correct audio clips from the ResourceManagers
        _audioClip_CraftingBandages = ResourceManager.Instance.audio_crafting_bandages;
        _audioClip_CraftingTotems = ResourceManager.Instance.audio_crafting_totems;

        //Disabling the right crafting slot in the beginning to avoid the crafting system breaking by placing an ingred in the right slot first
        ND_craftingSlot_R.gameObject.SetActive(false);
    }


    private void Update()
    {
        //if the left slot is filled...
        if (ND_craftingSlot_L.craftingReady == true && ND_craftingSlot_R.gameObject.activeInHierarchy == false)
        {
            //enable the right slot as well
            ND_craftingSlot_R.gameObject.SetActive(true);
        }

        //Checking if both crafting slots are occupied and ready
        if (ND_craftingSlot_L.craftingReady && ND_craftingSlot_R.craftingReady)
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
        if (ND_craftingSlot_L.craftingItem != null && ND_craftingSlot_R.craftingItem != null)
        {
            //Checking for ingredient item property & recipes
            //Recipe - BANDAGE 1
            if (ND_craftingSlot_L.craftingItem.GetComponent<ItemController>().Item.id == 1 &&
                ND_craftingSlot_R.craftingItem.GetComponent<ItemController>().Item.id == 2)
            {
                //DEBUGGING
                Debug.Log("REMOVING FROM HIGHLIGHTED LIST - STARTED");

                //Remove Ingredients from Witch Senses List
                _highlightingScript_L.highlightedObjects.Remove(ND_craftingSlot_L.craftingItem);
                _highlightingScript_L.highlightedObjects.Remove(ND_craftingSlot_R.craftingItem);
                _highlightingScript_R.highlightedObjects.Remove(ND_craftingSlot_R.craftingItem);
                _highlightingScript_R.highlightedObjects.Remove(ND_craftingSlot_L.craftingItem);

                //DEBUGGING
                Debug.Log("REMOVING FROM HIGHLIGHTED LIST - FINISHED");

                //If highlighting is currently active...
                //if (_highlightingScript_L._highlightingActive || _highlightingScript_R._highlightingActive)
                //{
                //    //Disable highlighting effect for tree
                //    ND_craftingSlot_L.craftingItem.GetComponentInChildren<ND_UI_Highlighter>(true).ShrinkUISize();
                //    ND_craftingSlot_R.craftingItem.GetComponentInChildren<ND_UI_Highlighter>(true).Invoke("DisableHighlightingUI", 0.3f);
                //}

                //Clear and Destroy Ingredients from both slots
                ND_craftingSlot_L.craftingReady = false;
                ND_craftingSlot_R.craftingReady = false;

                ND_craftingSlot_L.GetComponent<XRSocketInteractor>().enabled = false;
                ND_craftingSlot_R.GetComponent<XRSocketInteractor>().enabled = false;

                Destroy(ND_craftingSlot_L.craftingItem);
                Destroy(ND_craftingSlot_R.craftingItem);

                ND_craftingSlot_L.craftingItem = null;
                ND_craftingSlot_R.craftingItem = null;

                ND_craftingSlot_L.GetComponent<XRSocketInteractor>().enabled = true;
                ND_craftingSlot_R.GetComponent<XRSocketInteractor>().enabled = true;

                Debug.Log("Crafting Ingredient successfully cleared and destroyed!");

                //Disabling the right crafting slot again until the left one is filled
                ND_craftingSlot_R.gameObject.SetActive(false);

                //Fade screen to black
                fadeScript.Fade(true);
                //Start Crafting Sequence
                Invoke("NestedCraftingFunction_Bandages_0", 2.0f);
            }
            //Recipe - BANDAGE 2
            else if (ND_craftingSlot_L.craftingItem.GetComponent<ItemController>().Item.id == 2 &&
                    ND_craftingSlot_R.craftingItem.GetComponent<ItemController>().Item.id == 1)
            {
                //Remove Ingredients from Witch Senses List
                _highlightingScript_L.highlightedObjects.Remove(ND_craftingSlot_L.craftingItem);
                _highlightingScript_L.highlightedObjects.Remove(ND_craftingSlot_R.craftingItem);
                _highlightingScript_R.highlightedObjects.Remove(ND_craftingSlot_R.craftingItem);
                _highlightingScript_R.highlightedObjects.Remove(ND_craftingSlot_L.craftingItem);

                //If highlighting is currently active...
                //if (_highlightingScript_L._highlightingActive || _highlightingScript_R._highlightingActive)
                //{
                //    //Disable highlighting effect for tree
                //    ND_craftingSlot_L.craftingItem.GetComponentInChildren<ND_UI_Highlighter>(true).ShrinkUISize();
                //    ND_craftingSlot_R.craftingItem.GetComponentInChildren<ND_UI_Highlighter>(true).Invoke("DisableHighlightingUI", 0.3f);
                //}

                //Clear and Destroy Ingredients from both slots
                ND_craftingSlot_L.craftingReady = false;
                ND_craftingSlot_R.craftingReady = false;

                ND_craftingSlot_L.GetComponent<XRSocketInteractor>().enabled = false;
                ND_craftingSlot_R.GetComponent<XRSocketInteractor>().enabled = false;

                Destroy(ND_craftingSlot_L.craftingItem);
                Destroy(ND_craftingSlot_R.craftingItem);

                ND_craftingSlot_L.craftingItem = null;
                ND_craftingSlot_R.craftingItem = null;

                ND_craftingSlot_L.GetComponent<XRSocketInteractor>().enabled = true;
                ND_craftingSlot_R.GetComponent<XRSocketInteractor>().enabled = true;

                Debug.Log("Crafting Ingredient successfully cleared and destroyed!");

                //Disabling the righ crafting slot again until the left one is filled
                ND_craftingSlot_R.gameObject.SetActive(false);

                //Fade screen to black
                fadeScript.Fade(true);
                //Start Crafting Sequence
                Invoke("NestedCraftingFunction_Bandages_0", 2.0f);

            }
            //Recipe - TOTEM
            else if (ND_craftingSlot_L.craftingItem.GetComponent<ItemController>().Item.id == 5 &&
                    ND_craftingSlot_R.craftingItem.GetComponent<ItemController>().Item.id == 5)
            {
                //Remove Ingredients from Witch Senses List
                _highlightingScript_L.highlightedObjects.Remove(ND_craftingSlot_L.craftingItem);
                _highlightingScript_L.highlightedObjects.Remove(ND_craftingSlot_R.craftingItem);
                _highlightingScript_R.highlightedObjects.Remove(ND_craftingSlot_R.craftingItem);
                _highlightingScript_R.highlightedObjects.Remove(ND_craftingSlot_L.craftingItem);

                //If highlighting is currently active...
                //if (_highlightingScript_L._highlightingActive || _highlightingScript_R._highlightingActive)
                //{
                //    //Disable highlighting effect for tree
                //    ND_craftingSlot_L.craftingItem.GetComponentInChildren<ND_UI_Highlighter>(true).ShrinkUISize();
                //    ND_craftingSlot_R.craftingItem.GetComponentInChildren<ND_UI_Highlighter>(true).Invoke("DisableHighlightingUI", 0.3f);
                //}

                //Clear and Destroy Ingredients from both slots
                ND_craftingSlot_L.craftingReady = false;
                ND_craftingSlot_R.craftingReady = false;

                ND_craftingSlot_L.GetComponent<XRSocketInteractor>().enabled = false;
                ND_craftingSlot_R.GetComponent<XRSocketInteractor>().enabled = false;

                Destroy(ND_craftingSlot_L.craftingItem);
                Destroy(ND_craftingSlot_R.craftingItem);

                ND_craftingSlot_L.craftingItem = null;
                ND_craftingSlot_R.craftingItem = null;

                ND_craftingSlot_L.GetComponent<XRSocketInteractor>().enabled = true;
                ND_craftingSlot_R.GetComponent<XRSocketInteractor>().enabled = true;

                Debug.Log("Crafting Ingredient successfully cleared and destroyed!");

                //Disabling the righ crafting slot again until the left one is filled
                ND_craftingSlot_R.gameObject.SetActive(false);

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
        Instantiate(ResourceManager.Instance.ND_bandages, transform.position, transform.rotation);

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
        ND_stage_1_7.ToggleStageAdvancingFlag();
    }

    private void NestedCraftingFunction_Totems_0()
    {
        //Advance Stage_3_4 counter
        ND_stage_3_4.totemsCrafted += 1;

        //Craft Totem
        Instantiate(ResourceManager.Instance.ND_witchTotems[ND_stage_3_4.totemsCrafted - 1], transform.position, transform.rotation);

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
        if (StageManager.Instance.currentStage == ND_stage_3_4)
        {
            ND_stage_3_4.ToggleStageAdvancingFlag();
        }
    }
}
