using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_3_4 : Stage
{
    //Private Variables
    private bool _advancemetBool;
    private bool _conditionMet;

    //Public Variables
    public Stage_3_5 stage_3_5;
    public int totemsCrafted = 0;

    public override Stage RunCurrentStage()
    {
        if (_advancemetBool == true)
        {
            Debug.Log("Stage_3_4 completed! Next Stage: " + stage_3_5);
            return stage_3_5;
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
