using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ND_Stage_T_5_4 : Stage
{
    //Private Variables
    private bool _advancementBool;
    private bool _conditionMet;

    //Public Variables
    public ND_Stage_1_1 ND_stage_1_1;

    public override Stage RunCurrentStage()
    {
        if (_advancementBool)
        {
            Debug.Log("Stage_T_5_4 completed! Next Stage: " + ND_stage_1_1);
            return ND_stage_1_1;
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
                AudioManager.Instance.ShootAudioEvent_Owl_VL_1_1();

                //Stage Advancing Flag
                _advancementBool = true;
            }
        }
    }
}
