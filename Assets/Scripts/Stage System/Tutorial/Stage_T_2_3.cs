using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Stage_T_2_3 : Stage
{
    //Private Variables
    private bool _advancementBool;
    private bool _conditionMet;

    //Public Variables
    public Stage_T_2_4 stage_T_2_4;

    //Serialized Variables
    [SerializeField] private InputActionReference teleportInput_L;
    [SerializeField] private InputActionReference teleportInput_R;

    public override Stage RunCurrentStage()
    {
        if (StageManager.Instance.currentStage == this)
        {
            if (teleportInput_L.action.ReadValue<float>() != 0.0f || teleportInput_R.action.ReadValue<float>() != 0.0f)
            {
                Invoke("ToggleStageAdvancingFlag", 0.1f);
            }
        }

        if (_advancementBool)
        {
            Debug.Log("Stage_T_2_3 completed! Next Stage: " + stage_T_2_4);
            return stage_T_2_4;
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

            //Stage Advancing Flag
            _advancementBool = true;
        }
    }
}
