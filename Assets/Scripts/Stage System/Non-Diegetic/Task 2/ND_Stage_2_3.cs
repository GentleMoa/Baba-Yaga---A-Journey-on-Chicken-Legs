using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ND_Stage_2_3 : Stage
{
    //Private Variables
    private bool _seedOnePlanted;
    private bool _conditionMet;

    //Public Variables
    public ND_Stage_2_4 ND_stage_2_4;
    public int plantedSeeds = 0;

    public override Stage RunCurrentStage()
    {
        if (_seedOnePlanted == true)
        {
            Debug.Log("Stage_2_3 completed! Next Stage: " + ND_stage_2_4);
            return ND_stage_2_4;
        }
        else
        {
            return this;
        }
    }

    public void ToggleStageAdvancingFlag()
    {
        //Causes
        //Start Owl Voice Commentary for next Stage 
        AudioManager.Instance.ShootAudioEvent_Owl_VL_2_4();

        //Stage Advancing Flag
        _seedOnePlanted = true;
    }

    private void Update()
    {
        if (plantedSeeds == 1)
        {
            if (_conditionMet == false)
            {
                _conditionMet = true;

                ToggleStageAdvancingFlag();
            }
        }
    }
}
