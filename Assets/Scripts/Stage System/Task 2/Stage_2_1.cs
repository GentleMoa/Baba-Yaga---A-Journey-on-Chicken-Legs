using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_2_1 : Stage
{
    //Private Variables
    private bool _seedsGathered;
    private bool _conditionMet;

    //Public Variables
    //public Stage_2_2 stage_2_2;
    public Stage_2_3 stage_2_3;

    public override Stage RunCurrentStage()
    {
        if (_seedsGathered == true)
        {
            //SKIPPED DUE TO LACK OF INVENTORY SYSTEM AT THE TIME
            //Debug.Log("Stage_2_1 completed! Next Stage: " + stage_2_2);
            //return stage_2_2;

            Debug.Log("Stage_2_1 completed! Next Stage: " + stage_2_3 + ". This is due the inventory system not being implemented yet!");
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
            //Enable stage_2_3 Trigger Collider on Clearing
            stage_2_3.GetComponent<BoxCollider>().enabled = true;

            //Stage Advancing Flag
            _seedsGathered = true;
        }
    }
}
