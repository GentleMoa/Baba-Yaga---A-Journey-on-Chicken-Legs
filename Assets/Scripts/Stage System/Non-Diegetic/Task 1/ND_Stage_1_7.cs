using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ND_Stage_1_7 : Stage
{
    //Private Variables
    private bool craftingComplete;
    private bool _conditionMet;

    //Public Variables
    public ND_Stage_1_8 ND_stage_1_8;

    public override Stage RunCurrentStage()
    {
        if (craftingComplete == true)
        {
            Debug.Log("Stage_1_7 completed! Next Stage: " + ND_stage_1_8);
            return ND_stage_1_8;
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
            AudioManager.Instance.ShootAudioEvent_Owl_VL_1_8();

            craftingComplete = true;
        }
    }
}
