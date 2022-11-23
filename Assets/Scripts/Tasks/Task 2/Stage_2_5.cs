using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_2_5 : Stage
{
    //Private Variables
    private bool _advancemetBool;
    private bool _conditionMet;

    //Public Variables
    //public Stage_3_1 stage_3_1;

    public override Stage RunCurrentStage()
    {
        if (_advancemetBool == true)
        {
            Debug.Log("Task 2 Completed!");
            return this;

            //Debug.Log("Stage_2_5 completed! Next Stage: " + stage_3_1);
            //return stage_3_1;
        }
        else
        {
            Debug.Log("Task 2 Completed!");
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
