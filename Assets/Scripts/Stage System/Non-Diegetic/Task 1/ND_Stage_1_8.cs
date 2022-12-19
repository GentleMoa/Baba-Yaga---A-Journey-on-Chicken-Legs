using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ND_Stage_1_8 : Stage
{
    //Private Variables
    private bool _tutorialInitiated;
    private bool _advancementBool;
    private bool _conditionMet;
    private ND_Highlighting _highlightingScript_L;
    private ND_Highlighting _highlightingScript_R;

    //Public Variables
    public ND_Stage_1_9 ND_stage_1_9;

    //Serialized Variables
    [SerializeField] private GameObject tree;

    private void Start()
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

        if (_advancementBool == true)
        {
            //Hide the UI Prompt
            uiPrompt.GetComponent<Animator>().SetTrigger("UI_Hide");
            uiPrompt.Invoke("DisableUI", 0.3f);

            Debug.Log("Stage_1_8 completed! Next Stage: " + ND_stage_1_9);
            return ND_stage_1_9;
        }
        else
        {
            return this;
        }
    }

    public void ToggleStageAdvancingFlag()
    {
        if (_conditionMet == false)
        {
            _conditionMet = true;

            //Remove Ingredients from highlightedObjects List
            _highlightingScript_L.highlightedObjects.Remove(tree);
            _highlightingScript_R.highlightedObjects.Remove(tree);

            //If highlighting is currently active...
            if (_highlightingScript_L._highlightingActive || _highlightingScript_R._highlightingActive)
            {
                //Disable highlighting effect for tree
                tree.GetComponentInChildren<ND_UI_Highlighter>(true).ShrinkUISize();
                tree.GetComponentInChildren<ND_UI_Highlighter>(true).Invoke("DisableHighlightingUI", 0.3f);
            }

            Invoke("DelayedAdvancementFlagToggle", 4.0f);
        }
    }

    private void DelayedAdvancementFlagToggle()
    {
        //Stage Advancing Flag
        _advancementBool = true;
    }

    private void UnhideUIPrompt()
    {
        uiPrompt.EnableUI();
        uiPrompt.GetComponent<Animator>().SetTrigger("UI_Show");
    }
}
