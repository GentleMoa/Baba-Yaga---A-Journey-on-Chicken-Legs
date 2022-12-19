using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ND_Stage_3_5 : Stage
{
    //Private Variables
    private bool _tutorialInitiated;
    private bool _advancemetBool;
    private bool _conditionMet;

    //Public Variables
    public ND_Stage_3_6 ND_stage_3_6;

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

        if (_advancemetBool == true)
        {
            //Hide the UI Prompt
            uiPrompt.GetComponent<Animator>().SetTrigger("UI_Hide");
            uiPrompt.Invoke("DisableUI", 0.3f);

            Debug.Log("ND_Stage_3_5 completed! Next Stage: " + ND_stage_3_6);
            return ND_stage_3_6;
        }
        else
        {
            return this;
        }
    }

    //Triggered by hanging 1 Totem on a tree on the clearing
    public void ToggleStageAdvancingFlag()
    {
        if (_conditionMet == false)
        {
            _conditionMet = true;

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
