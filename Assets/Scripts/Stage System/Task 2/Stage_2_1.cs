using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_2_1 : Stage
{
    //Private Variables
    private bool _inventoryOpened;
    private bool _conditionMet;

    //Public Variables
    public Stage_2_2 stage_2_2;

    public override Stage RunCurrentStage()
    {
        if (_inventoryOpened)
        {
            Debug.Log("Stage_2_1 completed! Next Stage: " + stage_2_2);
            return stage_2_2;
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

                //Stage Advancing Flag
                _inventoryOpened = true;
            }
        }
    }
}
