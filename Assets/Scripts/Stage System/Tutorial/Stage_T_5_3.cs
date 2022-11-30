using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_T_5_3 : Stage
{
    //Private Variables
    private bool _advancementBool;
    private bool _conditionMet;

    //Public Variables
    public Stage_1_1 stage_1_1;

    public override Stage RunCurrentStage()
    {
        if (_advancementBool)
        {
            Debug.Log("Stage_T_5_3 completed! Next Stage: " + stage_1_1);
            return stage_1_1;
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

                Invoke("DelayedFlagSetter", 3.0f);
            }
        }
    }

    private void DelayedFlagSetter()
    {
        //Stage Advancing Flag
        _advancementBool = true;
    }
}
