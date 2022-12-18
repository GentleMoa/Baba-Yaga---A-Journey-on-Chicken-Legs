using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ND_Stage_T_1_1 : Stage
{
    //Private Variables
    private bool _tutorialInitiated;

    //Public Variables
    public ND_Stage_T_1_2 ND_stage_T_1_2;

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
            Invoke("ShowUIPrompt", 5.0f);
        }

        if (uiPrompt.advanceTouch == true && uiPrompt.coroutineAnimFinished == true)
        {
            //Hide the UI Prompt
            uiPrompt.ShrinkUISize();
            uiPrompt.Invoke("DisableUI", 0.3f);

            //Advance Stage
            Debug.Log("Stage_T_1_1 completed! Next Stage: " + ND_stage_T_1_2);
            return ND_stage_T_1_2;
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
