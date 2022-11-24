using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_2_2 : Stage
{
    //Private Variables
    private bool _seedsStashed;
    private bool _conditionMet;

    //Public Variables
    public Stage_2_3 stage_2_3;

    public override Stage RunCurrentStage()
    {
        if (_seedsStashed == true)
        {
            Debug.Log("Stage_2_2 completed! Next Stage: " + stage_2_3);
            return stage_2_3;
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

            //Causes

            //Stage Advancing Flag
            _seedsStashed = true;
        }
    }

}
