using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ND_Stage_2_4 : Stage
{
    //Private Variables
    private bool _tutorialInitiated;
    private bool _advancementBool;
    private bool _conditionMet;

    //Public Variables
    public ND_Stage_2_5 ND_stage_2_5;
    public int plantedSeeds = 0;

    public override Stage RunCurrentStage()
    {
        //If tutorial hasn't started yet...
        if (_tutorialInitiated == false)
        {
            //Set Flag
            _tutorialInitiated = true;

            //Start tutorial
            Invoke("UnhideUIPrompt", 3.0f);
        }

        if (_advancementBool == true)
        {
            //Hide the UI Prompt
            uiPrompt.GetComponent<Animator>().SetTrigger("UI_Hide");
            uiPrompt.Invoke("DisableUI", 0.3f);

            Debug.Log("Stage_2_4 completed! Next Stage: " + ND_stage_2_5);
            return ND_stage_2_5;
        }
        else
        {
            return this;
        }
    }

    private void Update()
    {
        //if counter at 3 call ToggleStageAdvancingFlag() for Stage_2_4
        if (plantedSeeds == 3)
        {
            if (_conditionMet == false)
            {
                _conditionMet = true;

                //Stage Advancing Flag
                _advancementBool = true;
            }
        }
    }

    private void UnhideUIPrompt()
    {
        uiPrompt.EnableUI();
        uiPrompt.GetComponent<Animator>().SetTrigger("UI_Show");
    }
}
