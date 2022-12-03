using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_2_2 : Stage
{
    //Private Variables
    private bool _seedGrabbed;
    private bool _conditionMet;

    //Public Variables
    public Stage_2_3 stage_2_3;

    //Serialized Variables
    [SerializeField] private SeedPlanting[] seedPlantingScripts;

    public override Stage RunCurrentStage()
    {
        if (_seedGrabbed == true)
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
        if (StageManager.Instance.currentStage == this)
        {
            if (_conditionMet == false)
            {
                _conditionMet = true;

                //Causes
                //Start Owl Voice Commentary for next Stage 
                AudioManager.Instance.ShootAudioEvent_Owl_VL_2_3();

                //Enable Planting Counter script
                for (int i = 0; i < seedPlantingScripts.Length; i++)
                {
                    seedPlantingScripts[i].plantingActivated = true;
                }

                //Stage Advancing Flag
                _seedGrabbed = true;
            }
        }

    }

}
