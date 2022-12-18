using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ND_Stage_1_5 : Stage
{
    //Private Variables
    private bool woolPlantGathered;
    private bool _conditionMet;

    //Public Variables
    public ND_Stage_1_6 ND_stage_1_6;

    public override Stage RunCurrentStage()
    {
        if (woolPlantGathered == true)
        {
            Debug.Log("Stage_1_5 completed! Next Stage: " + ND_stage_1_6);
            return ND_stage_1_6;
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
            AudioManager.Instance.ShootAudioEvent_Owl_VL_1_6();

            woolPlantGathered = true;
        }
    }
}
