using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Stage_T_2_2 : Stage
{
    //Private Variables
    private bool _advancementBool;
    private bool _conditionMet;

    //Public Variables
    public Stage_T_2_3 stage_T_2_3;

    //Serialized Variables
    [SerializeField] private InputActionReference continuousMoveInput;

    public override Stage RunCurrentStage()
    {
        if (StageManager.Instance.currentStage == this)
        {
            if (continuousMoveInput.action.ReadValue<Vector2>() != new Vector2(0.0f, 0.0f))
            {
                ToggleStageAdvancingFlag();
            }
        }

        if (_advancementBool)
        {
            Debug.Log("Stage_T_2_2 completed! Next Stage: " + stage_T_2_3);
            return stage_T_2_3;
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
            AudioManager.Instance.ShootAudioEvent_Owl_VL_T_2_3();

            //Stage Advancing Flag
            _advancementBool = true;
        }
    }
}
