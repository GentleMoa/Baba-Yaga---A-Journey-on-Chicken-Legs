using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ND_Stage_1_3 : Stage
{
    //Private Variables
    private bool borageGathered;
    private bool _conditionMet;

    //Public Variables
    public ND_Stage_1_4 ND_stage_1_4;

    public override Stage RunCurrentStage()
    {
        if (borageGathered == true)
        {
            Debug.Log("Stage_1_3 completed! Next Stage: " + ND_stage_1_4);
            return ND_stage_1_4;
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
            AudioManager.Instance.ShootAudioEvent_Owl_VL_1_4();

            //Stage Advancing Flag
            borageGathered = true;
        }
    }
}
