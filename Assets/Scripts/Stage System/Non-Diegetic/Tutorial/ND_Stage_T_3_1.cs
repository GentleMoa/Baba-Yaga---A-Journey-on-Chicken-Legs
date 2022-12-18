using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ND_Stage_T_3_1 : Stage
{
    //Private Variables
    private bool _tutorialInitiated;
    private bool _conditionMet;
    private bool _advancementBool;

    //Public Variables
    public ND_Stage_T_3_2 ND_stage_T_3_2;

    //Serialized Variables
    //[SerializeField] private TextPromptAnimated uiPrompt;
    [SerializeField] private InputActionReference highlightingButton_L;
    [SerializeField] private InputActionReference highlightingButton_R;

    public override Stage RunCurrentStage()
    {
        //If tutorial hasn't started yet...
        if (_tutorialInitiated == false)
        {
            //Set Flag
            _tutorialInitiated = true;

            //Start tutorial
            Invoke("ShowUIPrompt", 2.0f);
        }

        //Same as writing: if (highlightingButton_L.action.ReadValue<float>() != 0.0f || highlightingButton_R.action.ReadValue<float>() != 0.0f && _conditionMet == false)
        if (highlightingButton_L.action.ReadValue<float>() != 0.0f || highlightingButton_R.action.ReadValue<float>() != 0.0f && _conditionMet == false)
        {
            //Set Flag
            _conditionMet = true;

            //Hide the UI Prompt
            uiPrompt.ShrinkUISize();
            uiPrompt.Invoke("DisableUI", 0.3f);

            //Set the _advancementBool Flag with a delay to avoid immediately skipping the next stage as well
            Invoke("AdvanceStage", 0.35f);
        }

        if (_advancementBool == true)
        {
            //Advance Stage
            Debug.Log("Stage_T_3_1 completed! Next Stage: " + ND_stage_T_3_2);
            return ND_stage_T_3_2;
        }
        else
        {
            return this;
        }
    }

    private void ShowUIPrompt()
    {
        uiPrompt.EnableUI();
        uiPrompt.GrowUISize();
    }

    private void AdvanceStage()
    {
        if (_advancementBool == false)
        {
            _advancementBool = true;
        }
    }
}
