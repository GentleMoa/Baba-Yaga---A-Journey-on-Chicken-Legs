using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_T_5_2 : Stage
{
    //Private Variables
    private bool _advancementBool;
    private bool _conditionMet;

    //Public Variables
    public Stage_T_6_1 stage_T_6_1;

    public override Stage RunCurrentStage()
    {
        if (_advancementBool)
        {
            Debug.Log("Stage_T_5_2 completed! Next Stage: " + stage_T_6_1);
            return stage_T_6_1;
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

                //Stage Advancing Flag
                _advancementBool = true;
            }
        }
    }
}
