using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_T_6_5 : Stage
{
    //Private Variables
    private bool _advancementBool;
    private bool _conditionMet;

    //Public Variables
    public Stage_T_5_3 stage_T_5_3;

    //Serialized Variables
    [SerializeField] private RingMenuSlot inventorySlotSeeds;

    public override Stage RunCurrentStage()
    {
        if (_advancementBool && inventorySlotSeeds.stashedItems.Count == 3)
        {
            Debug.Log("Stage_T_6_5 completed! Next Stage: " + stage_T_5_3);
            return stage_T_5_3;
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
                AudioManager.Instance.ShootAudioEvent_Owl_VL_T_5_3();

                //Stage Advancing Flag
                _advancementBool = true;
            }
        }
    }
}
