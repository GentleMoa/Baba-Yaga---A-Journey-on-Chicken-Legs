using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_T_5_3 : Stage
{
    //Private Variables
    private bool _advancementBool;
    private bool _conditionMet;

    //Public Variables
    public Stage_T_5_4 stage_T_5_4;

    public override Stage RunCurrentStage()
    {
        if (_advancementBool)
        {
            Debug.Log("Stage_T_5_3 completed! Next Stage: " + stage_T_5_4);
            return stage_T_5_4;
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

                Invoke("DelayedFlagSetter_T_5_3", 3.0f);
                Invoke("DelayedFlagSetter_T_5_4", 6.0f);
            }
        }
    }

    private void DelayedFlagSetter_T_5_3()
    {
        //Stage Advancing Flag
        _advancementBool = true;
    }

    private void DelayedFlagSetter_T_5_4()
    {
        stage_T_5_4.ToggleStageAdvancingFlag();
    }
}
