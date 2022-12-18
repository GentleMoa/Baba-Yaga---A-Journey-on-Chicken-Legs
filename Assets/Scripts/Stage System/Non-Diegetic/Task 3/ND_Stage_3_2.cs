using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ND_Stage_3_2 : Stage
{
    //Public Variables
    public ND_Stage_3_3 ND_stage_3_3;

    //Serialized Variables
    [SerializeField] private RingMenuSlot inventorySlotSticks;

    public override Stage RunCurrentStage()
    {
        if (StageManager.Instance.currentStage == this && inventorySlotSticks.stashedItems.Count > 3)
        {
            //Causes
            //Start Owl Voice Commentary for next Stage 
            AudioManager.Instance.ShootAudioEvent_Owl_VL_3_3();

            Debug.Log("Stage_3_2 completed! Next Stage: " + ND_stage_3_3);
            return ND_stage_3_3;
        }
        else
        {
            return this;
        }
    }
}
