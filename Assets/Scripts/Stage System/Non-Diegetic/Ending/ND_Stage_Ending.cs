using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ND_Stage_Ending : Stage
{
    //Private Variables
    private bool _tutorialInitiated;
    private bool _experienceCompleted;
    private bool _conditionMet;

    public override Stage RunCurrentStage()
    {
        //If tutorial hasn't started yet...
        if (_tutorialInitiated == false)
        {
            //Set Flag
            _tutorialInitiated = true;

            //Start tutorial
            Invoke("UnhideUIPrompt", 2.0f);

            Invoke("DelayedAdvancementFlagToggle", 6.0f);
        }

        if (_experienceCompleted == true)
        {
            Debug.Log("Congratulations! You have finished the experience! Thank you for playing!");
            return this;
        }
        else
        {
            return this;
        }
    }

    public void DelayedAdvancementFlagToggle()
    {
        if (_conditionMet == false)
        {
            _conditionMet = true;

            uiPrompt.GetComponent<Animator>().SetTrigger("UI_Hide");
            uiPrompt.Invoke("DisableUI", 0.3f);

            //Stage Advancing Flag
            _experienceCompleted = true;
        }
    }

    private void UnhideUIPrompt()
    {
        uiPrompt.EnableUI();
        uiPrompt.GetComponent<Animator>().SetTrigger("UI_Show");
    }
}
