using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ND_Stage_2_2 : Stage
{
    //Private Variables
    private bool _tutorialInitiated;
    private bool _advancementBool;
    private bool _conditionMet;

    //Public Variables
    public ND_Stage_2_3 ND_stage_2_3;

    //Serialized Variables
    [SerializeField] private ND_SeedPlanting[] ND_seedPlantingScripts;

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

        if (_advancementBool == true)
        {
            //Hide the UI Prompt
            uiPrompt.GetComponent<Animator>().SetTrigger("UI_Hide");
            uiPrompt.Invoke("DisableUI", 0.3f);

            Debug.Log("Stage_2_2 completed! Next Stage: " + ND_stage_2_3);
            return ND_stage_2_3;
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

                //Enable Planting Counter script
                for (int i = 0; i < ND_seedPlantingScripts.Length; i++)
                {
                    ND_seedPlantingScripts[i].plantingActivated = true;
                }

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
