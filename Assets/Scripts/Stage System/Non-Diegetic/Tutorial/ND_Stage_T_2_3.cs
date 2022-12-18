using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ND_Stage_T_2_3 : Stage
{
    //Private Variables
    private bool _tutorialInitiated;

    //Public Variables
    public ND_Stage_T_2_4 ND_stage_T_2_4;

    //Serialized Variables
    [SerializeField] private TextPromptAnimated uiPrompt;
    [SerializeField] private InputActionReference teleportInput_L;
    [SerializeField] private InputActionReference teleportInput_R;

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

        if (teleportInput_L.action.ReadValue<float>() != 0.0f || teleportInput_R.action.ReadValue<float>() != 0.0f)
        {
            //Hide the UI Prompt
            uiPrompt.ShrinkUISize();
            uiPrompt.Invoke("DisableUI", 0.3f);

            //Advance Stage
            Debug.Log("Stage_T_2_3 completed! Next Stage: " + ND_stage_T_2_4);
            return ND_stage_T_2_4;
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
