using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ND_Stage_1_9 : Stage
{
    //Private Variables
    private bool _tutorialInitiated;
    private bool _advancementBool;
    private bool _conditionMet;

    //Public Variables
    public ND_Stage_2_1 ND_stage_2_1;

    public override Stage RunCurrentStage()
    {
        //If tutorial hasn't started yet...
        if (_tutorialInitiated == false)
        {
            //Set Flag
            _tutorialInitiated = true;

            //Start tutorial
            Invoke("UnhideUIPrompt", 2.0f);

            Invoke("ToggleStageAdvancingFlag", 7.0f);
        }

        if (_advancementBool == true)
        {
            //Hide the UI Prompt
            uiPrompt.GetComponent<Animator>().SetTrigger("UI_Hide");
            uiPrompt.Invoke("DisableUI", 0.3f);

            Debug.Log("Task 1 Completed! Next Stage: " + ND_stage_2_1);
            return ND_stage_2_1;
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

            //Set Advancement Flag
            _advancementBool = true;
        }
    }

    private void UnhideUIPrompt()
    {
        uiPrompt.EnableUI();
        uiPrompt.GetComponent<Animator>().SetTrigger("UI_Show");
    }
}
