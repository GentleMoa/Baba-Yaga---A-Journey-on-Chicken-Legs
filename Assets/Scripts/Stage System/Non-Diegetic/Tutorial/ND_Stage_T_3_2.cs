using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ND_Stage_T_3_2 : Stage
{
    //Private Variables
    private bool _tutorialInitiated;
    private bool _conditionMet;

    //Public Variables
    public ND_Stage_T_4_1 ND_stage_T_4_1;

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

            //Advance Stage
            Debug.Log("Stage_T_3_2 completed! Next Stage: " + ND_stage_T_4_1);
            return ND_stage_T_4_1;
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
}
