using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_1_3 : Stage
{
    //Private Variables
    private bool borageGathered;
    private bool _conditionMet;

    //Public Variables
    public Stage_1_4 stage_1_4;

    public override Stage RunCurrentStage()
    {
        if (borageGathered == true)
        {
            Debug.Log("Stage_1_3 completed! Next Stage: " + stage_1_4);
            return stage_1_4;
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

            //Stage Advancing Flag
            borageGathered = true;
        }
    }
}
