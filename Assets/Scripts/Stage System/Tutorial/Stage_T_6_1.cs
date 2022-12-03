using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_T_6_1 : Stage
{
    //Private Variables
    private bool _advancementBool;
    private bool _conditionMet;

    //Public Variables
    public Stage_T_6_2 stage_T_6_2;

    public override Stage RunCurrentStage()
    {
        if (_advancementBool)
        {
            Debug.Log("Stage_T_6_1 completed! Next Stage: " + stage_T_6_2);
            return stage_T_6_2;
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

                //Causes
                //Start Owl Voice Commentary for next Stage 
                AudioManager.Instance.ShootAudioEvent_Owl_VL_T_6_2();

                //Stage Advancing Flag
                _advancementBool = true;
            }
        }
    }
}
