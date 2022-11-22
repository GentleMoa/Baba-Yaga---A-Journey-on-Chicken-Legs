using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_1_8 : Stage
{
    //Private Variables
    private bool bandageApplied;
    private bool _conditionMet;

    //Public Variables
    public Stage_1_9 stage_1_9;

    public override Stage RunCurrentStage()
    {
        if (bandageApplied == true)
        {
            Debug.Log("Stage_1_8 completed! Next Stage: " + stage_1_9);
            return stage_1_9;
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
            bandageApplied = true;
            _conditionMet = true;
        }
    }
}
