using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Stage_T_3_1 : Stage
{
    //Private Variables
    private bool _advancementBool;
    private bool _conditionMet;

    //Public Variables
    public Stage_T_3_2 stage_T_3_2;

    //Serialized Variables
    [SerializeField] private InputActionReference highlightingButton_L;
    [SerializeField] private InputActionReference highlightingButton_R;

    public override Stage RunCurrentStage()
    {
        if (StageManager.Instance.currentStage == this)
        {
            if (highlightingButton_L.action.ReadValue<float>() != 0.0f || highlightingButton_R.action.ReadValue<float>() != 0.0f)
            {
                Invoke("ToggleStageAdvancingFlag", 0.25f);
            }
        }

        if (_advancementBool)
        {
            Debug.Log("Stage_T_3_1 completed! Next Stage: " + stage_T_3_2);
            return stage_T_3_2;
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

            //Causes
            //Start Owl Voice Commentary for next Stage 
            AudioManager.Instance.ShootAudioEvent_Owl_VL_T_3_2();

            //Stage Advancing Flag
            _advancementBool = true;
        }
    }
}
