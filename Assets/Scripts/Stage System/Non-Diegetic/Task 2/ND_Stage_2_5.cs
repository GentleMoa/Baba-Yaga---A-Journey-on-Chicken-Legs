using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ND_Stage_2_5 : Stage
{
    //Private Variables
    private bool _tutorialInitiated;
    private bool _advancemetBool;
    private bool _conditionMet;
    private ND_Highlighting _highlightingScript_L;
    private ND_Highlighting _highlightingScript_R;

    //Public Variables
    public ND_Stage_3_1 ND_stage_3_1;

    //Serialized Variables
    [SerializeField] private GameObject[] sticks;

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
            Invoke("UnhideUIPrompt", 3.0f);

            Invoke("ToggleStageAdvancingFlag", 8.0f);
        }

        if (_advancemetBool == true)
        {
            //Hide the UI Prompt
            uiPrompt.GetComponent<Animator>().SetTrigger("UI_Hide");
            uiPrompt.Invoke("DisableUI", 0.3f);

            Debug.Log("Task 2 Completed! Next Stage: " + ND_stage_3_1);
            return ND_stage_3_1;
        }
        else
        {
            Debug.Log("Task 2 Completed!");
            return this;
        }
    }

    public void ToggleStageAdvancingFlag()
    {
        if (_conditionMet == false)
        {
            _conditionMet = true;

            for (int i = 0; i < sticks.Length; i++)
            {
                //Activate Sticks
                sticks[i].SetActive(true);

                //Add Sticks to highlightedObjects List
                _highlightingScript_L.highlightedObjects.Add(sticks[i]);
                _highlightingScript_R.highlightedObjects.Add(sticks[i]);

                //If highlighting is currently active...
                if (_highlightingScript_L._highlightingActive || _highlightingScript_R._highlightingActive)
                {
                    //Enable highlighting effect for Sticks
                    sticks[i].GetComponentInChildren<ND_UI_Highlighter>(true).EnableHighlightingUI();
                    sticks[i].GetComponentInChildren<ND_UI_Highlighter>(true).GrowUISize();
                }
            }

            //Stage Advancing Flag
            _advancemetBool = true;
        }
    }

    private void UnhideUIPrompt()
    {
        uiPrompt.EnableUI();
        uiPrompt.GetComponent<Animator>().SetTrigger("UI_Show");
    }
}
