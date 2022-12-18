using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ND_Stage_3_6 : Stage
{
    //Private Variables
    private bool _advancemetBool;
    private bool _conditionMet;

    //Public Variables
    public ND_Stage_Ending ND_stage_ending;

    public override Stage RunCurrentStage()
    {
        if (_advancemetBool == true)
        {
            //Debug.Log("Task 3 Completed!");
            //return this;

            Debug.Log("Task 3 Completed! Next Stage: " + ND_stage_ending);
            return ND_stage_ending;
        }
        else
        {
            Debug.Log("Task 3 Completed!");
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
            AudioManager.Instance.ShootAudioEvent_Owl_VL_Ending();

            //Stage Advancing Flag
            _advancemetBool = true;
        }
    }
}
