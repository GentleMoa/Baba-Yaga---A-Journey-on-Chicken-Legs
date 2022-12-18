using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ND_Stage_T_4_1 : Stage
{
    //Private Variables
    private bool _tutorialInitiated;
    private bool _advancementBool;
    private bool _conditionMet;

    //Public Variables
    public ND_Stage_T_4_2 ND_stage_T_4_2;

    //Serialized Variables
    //[SerializeField] private TextPromptAnimated uiPrompt;

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

        if (_advancementBool)
        {
            //Hide the UI Prompt
            uiPrompt.ShrinkUISize();
            uiPrompt.Invoke("DisableUI", 0.3f);

            //Advance Stage
            Debug.Log("Stage_T_4_1 completed! Next Stage: " + ND_stage_T_4_2);
            return ND_stage_T_4_2;
        }
        else
        {
            return this;
        }
    }

    public void ToggleStageAdvancingFlag()
    {
        if (StageManager.Instance.currentStage == this)
        {
            if (_conditionMet == false)
            {
                _conditionMet = true;

                //Stage Advancing Flag
                _advancementBool = true;
            }
        }
    }

    private void ShowUIPrompt()
    {
        uiPrompt.EnableUI();
        uiPrompt.GrowUISize();
    }
}
