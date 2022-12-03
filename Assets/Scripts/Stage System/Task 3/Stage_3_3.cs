using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_3_3 : Stage
{
    //Private Variables
    private bool _advancemetBool;
    private bool _conditionMet;

    //Public Variables
    public Stage_3_4 stage_3_4;

    public override Stage RunCurrentStage()
    {
        if (_advancemetBool == true)
        {
            Debug.Log("Stage_3_3 completed! Next Stage: " + stage_3_4);
            return stage_3_4;
        }
        else
        {
            return this;
        }
    }

    public void ToggleStageAdvancingFlag()
    {
        if (StageManager.Instance.currentStage == this.GetComponent<Stage_3_3>())
        {
            if (_conditionMet == false)
            {
                _conditionMet = true;

                //Causes
                //Start Owl Voice Commentary for next Stage 
                AudioManager.Instance.ShootAudioEvent_Owl_VL_3_4();

                //Stage Advancing Flag
                _advancemetBool = true;
            }
        }
    }
}
