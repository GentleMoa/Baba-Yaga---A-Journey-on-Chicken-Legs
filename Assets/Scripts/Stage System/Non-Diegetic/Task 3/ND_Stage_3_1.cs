using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ND_Stage_3_1 : Stage
{
    //Private Variables
    private bool _advancemetBool;
    private bool _conditionMet;

    //Public Variables
    public ND_Stage_3_2 ND_stage_3_2;

    public override Stage RunCurrentStage()
    {
        if (_advancemetBool == true)
        {
            Debug.Log("Stage_3_1 completed! Next Stage: " + ND_stage_3_2);
            return ND_stage_3_2;
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
            AudioManager.Instance.ShootAudioEvent_Owl_VL_3_2();

            //Stage Advancing Flag
            _advancemetBool = true;
        }
    }
}
