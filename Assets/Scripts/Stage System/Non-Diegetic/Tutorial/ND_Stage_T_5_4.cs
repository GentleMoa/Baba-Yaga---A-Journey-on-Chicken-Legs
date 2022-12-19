using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ND_Stage_T_5_4 : Stage
{
    //Private Variables
    private bool _tutorialInitiated;
    private bool _advancementBool;
    private bool _conditionMet;

    //Public Variables
    public ND_Stage_1_1 ND_stage_1_1;

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

        if (_advancementBool)
        {
            //Hide the UI Prompt
            uiPrompt.GetComponent<Animator>().SetTrigger("UI_Hide");
            uiPrompt.Invoke("DisableUI", 0.3f);

            Debug.Log("Stage_T_5_4 completed! Next Stage: " + ND_stage_1_1);
            return ND_stage_1_1;
        }
        else
        {
            return this;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_conditionMet == false)
        {
            if (other.gameObject.tag == "Player")
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
