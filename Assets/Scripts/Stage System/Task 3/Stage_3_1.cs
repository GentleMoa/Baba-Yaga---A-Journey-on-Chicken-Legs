using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_3_1 : Stage
{
    //Private Variables
    private bool _advancemetBool;
    private bool _conditionMet;

    //Public Variables
    public Stage_3_2 stage_3_2;
    public Stage_3_3 stage_3_3;

    public override Stage RunCurrentStage()
    {
        if (_advancemetBool == true)
        {
            //Debug.Log("Stage_3_1 completed! Next Stage: " + stage_3_2);
            //return stage_3_2;

            Debug.Log("Stage_3_1 completed! Next Stage: " + stage_3_3 + " due to lack of inventory system, stage_3_2 is being skipped for now!");
            return stage_3_3;
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
            _advancemetBool = true;
        }
    }
}
