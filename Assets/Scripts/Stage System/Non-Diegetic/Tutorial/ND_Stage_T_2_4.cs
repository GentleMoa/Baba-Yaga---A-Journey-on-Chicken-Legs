using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ND_Stage_T_2_4 : Stage
{
    //Private Variables
    private bool _tutorialInitiated;

    //Public Variables
    public ND_Stage_T_3_1 ND_stage_T_3_1;

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

        if (uiPrompt.advanceTouch == true)
        {
            //Hide the UI Prompt
            uiPrompt.ShrinkUISize();
            uiPrompt.Invoke("DisableUI", 0.3f);

            //Advance Stage
            Debug.Log("Stage_T_2_4 completed! Next Stage: " + ND_stage_T_3_1);
            return ND_stage_T_3_1;
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
