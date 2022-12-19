using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ND_Stage_1_4 : Stage
{
    //Private Variables
    private bool _tutorialInitiated;
    private ND_Highlighting _highlightingScript_L;
    private ND_Highlighting _highlightingScript_R;

    //Public Variables
    public ND_Stage_1_5 ND_stage_1_5;

    //Serialized Variables
    [SerializeField] private ND_I_ItemSlots inventorySlotBorage;
    [SerializeField] private GameObject woolPlant;

    void Start()
    {
        //Find Reference to both ND_Highlighting scripts (Right & Left Hands)
        _highlightingScript_L = GameObject.FindGameObjectWithTag("LeftHand").GetComponent<ND_Highlighting>();
        _highlightingScript_R = GameObject.FindGameObjectWithTag("RightHand").GetComponent<ND_Highlighting>();
    }

    public override Stage RunCurrentStage()
    {
        //If tutorial hasn't started yet...
        if (_tutorialInitiated == false)
        {
            //Set Flag
            _tutorialInitiated = true;

            //Start tutorial
            Invoke("UnhideUIPrompt", 2.0f);
        }

        if (inventorySlotBorage.stashedItems.Count > 0)
        {
            //Add borage to highlightedObjects list
            _highlightingScript_L.highlightedObjects.Add(woolPlant);
            _highlightingScript_R.highlightedObjects.Add(woolPlant);

            //If highlighting is currently active...
            if (_highlightingScript_L._highlightingActive || _highlightingScript_R._highlightingActive)
            {
                //Enable highlighting effect for borage
                woolPlant.GetComponentInChildren<ND_UI_Highlighter>(true).EnableHighlightingUI();
                woolPlant.GetComponentInChildren<ND_UI_Highlighter>(true).GrowUISize();
            }

            //Hide the UI Prompt
            uiPrompt.GetComponent<Animator>().SetTrigger("UI_Hide");
            uiPrompt.Invoke("DisableUI", 0.3f);

            Debug.Log("Stage_1_4 completed! Next Stage: " + ND_stage_1_5);
            return ND_stage_1_5;
        }
        else
        {
            return this;
        }
    }

    private void UnhideUIPrompt()
    {
        uiPrompt.EnableUI();
        uiPrompt.GetComponent<Animator>().SetTrigger("UI_Show");
    }
}
