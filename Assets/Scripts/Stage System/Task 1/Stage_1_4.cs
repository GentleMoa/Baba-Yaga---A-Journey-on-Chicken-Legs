using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_1_4 : Stage
{
    //SKIPPED UNTIL INVENTORY SYSTEM IS IMPLEMENTED

    //Private Variables
    private bool borageStored;
    private bool _conditionMet;

    //Public Variables
    public Stage_1_5 stage_1_5;

    public override Stage RunCurrentStage()
    {
        if (borageStored == true)
        {
            Debug.Log("Stage_1_4 completed! Next Stage: " + stage_1_5);
            return stage_1_5;
        }
        else
        {
            return this;
        }
    }
}
