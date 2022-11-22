using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_1_2 : Stage
{
    //Private Variables
    private bool hatchedRemoved;
    private bool _conditionMet;

    //Public Variables
    public Stage_1_3 stage_1_3;

    public override Stage RunCurrentStage()
    {
        if (hatchedRemoved == true)
        {
            Debug.Log("Stage_1_2 completed! Next Stage: " + stage_1_3);
            return stage_1_3;
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
            hatchedRemoved = true;
            _conditionMet = true;
        }
    }
}
