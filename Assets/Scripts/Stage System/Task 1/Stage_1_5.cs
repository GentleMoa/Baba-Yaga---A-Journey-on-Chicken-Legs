using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_1_5 : Stage
{
    //Private Variables
    private bool woolPlantGathered;
    private bool _conditionMet;

    //Public Variables
    public Stage_1_6 stage_1_6;

    public override Stage RunCurrentStage()
    {
        if (woolPlantGathered == true)
        {
            Debug.Log("Stage_1_5 completed! Next Stage: " + stage_1_6);
            return stage_1_6;
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
            woolPlantGathered = true;
            _conditionMet = true;
        }
    }
}
