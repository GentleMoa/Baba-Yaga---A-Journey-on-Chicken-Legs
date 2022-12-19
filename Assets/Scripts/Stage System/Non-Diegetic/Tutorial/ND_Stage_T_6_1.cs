using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ND_Stage_T_6_1 : Stage
{
    //Private Variables
    private bool _tutorialInitiated;
    private bool _conditionMet;

    //Public Variables
    public ND_Stage_T_6_2A ND_stage_T_6_2A;

    //Serialized Variables
    [SerializeField] private InputActionReference inventoryButton_L;
    [SerializeField] private InputActionReference inventoryButton_R;

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

        if (inventoryButton_L.action.ReadValue<float>() != 0.0f || inventoryButton_R.action.ReadValue<float>() != 0.0f && _conditionMet == false)
        {
            //Set Flag
            _conditionMet = true;

            //Hide the UI Prompt
            uiPrompt.GetComponent<Animator>().SetTrigger("UI_Hide");
            uiPrompt.Invoke("DisableUI", 0.3f);

            Debug.Log("Stage_T_6_1 completed! Next Stage: " + ND_stage_T_6_2A);
            return ND_stage_T_6_2A;
        }
        else
        {
            return this;
        }
    }

    private void UnhideUIPrompt()
    {
        uiPrompt.EnableUI();
        uiPrompt.GetComponent<Animator>().SetTrigger("UI_Show");
    }
}
