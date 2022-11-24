using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_1_6 : Stage
{
    //Private Variables
    private bool arrivedAtHouse;
    private bool _conditionMet;

    //Public Variables
    public Stage_1_7 stage_1_7;

    public override Stage RunCurrentStage()
    {
        if (arrivedAtHouse == true)
        {
            Debug.Log("Stage_1_6 completed! Next Stage: " + stage_1_7);
            return stage_1_7;
        }
        else
        {
            return this;
        }
    }

    public void ToggleStageAdvancingFlag()
    {
        if (StageManager.Instance.currentStage == GetComponent<Stage_1_6>())
        {
            if (_conditionMet == false)
            {
                //Later, add a delay here to account for the polished and longer-lasting ladder climbing!

                arrivedAtHouse = true;
                _conditionMet = true;
            }
        }
    }
}
