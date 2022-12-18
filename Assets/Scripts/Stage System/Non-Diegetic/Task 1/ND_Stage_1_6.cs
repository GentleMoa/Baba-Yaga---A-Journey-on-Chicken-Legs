using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ND_Stage_1_6 : Stage
{
    //Private Variables
    private bool arrivedAtHouse;
    private bool _conditionMet;

    //Public Variables
    public ND_Stage_1_7 ND_stage_1_7;

    public override Stage RunCurrentStage()
    {
        if (arrivedAtHouse == true)
        {
            Debug.Log("Stage_1_6 completed! Next Stage: " + ND_stage_1_7);
            return ND_stage_1_7;
        }
        else
        {
            return this;
        }
    }

    public void ToggleStageAdvancingFlag()
    {
        if (StageManager.Instance.currentStage == GetComponent<Stage_1_6>())
        {
            if (_conditionMet == false)
            {
                _conditionMet = true;

                //Causes
                //Start Owl Voice Commentary for next Stage 
                AudioManager.Instance.ShootAudioEvent_Owl_VL_1_7();

                //Later, add a delay here to account for the polished and longer-lasting ladder climbing!
                arrivedAtHouse = true;
            }
        }
    }
}
