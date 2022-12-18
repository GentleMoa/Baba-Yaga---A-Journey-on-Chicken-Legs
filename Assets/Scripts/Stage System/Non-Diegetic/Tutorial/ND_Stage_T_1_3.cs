using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ND_Stage_T_1_3 : Stage
{
    //Private Variables
    private bool _tutorialInitiated;

    //Public Variables
    public ND_Stage_T_2_1 ND_stage_T_2_1;

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

        if (uiPrompt.advanceTouch == true && uiPrompt.coroutineAnimFinished == true)
        {
            //Hide the UI Prompt
            uiPrompt.ShrinkUISize();
            uiPrompt.Invoke("DisableUI", 0.3f);

            //Advance Stage
            Debug.Log("Stage_T_1_3 completed! Next Stage: " + ND_stage_T_2_1);
            return ND_stage_T_2_1;
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
