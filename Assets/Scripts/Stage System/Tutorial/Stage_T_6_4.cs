using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_T_6_4 : Stage
{
    //Private Variables
    private bool _advancementBool;
    private bool _conditionMet;

    //Public Variables
    public Stage_T_6_5 stage_T_6_5;

    //Serialized Variables
    [SerializeField] private RingMenuSlot inventorySlotSeeds;

    public override Stage RunCurrentStage()
    {
        if (StageManager.Instance.currentStage == this && inventorySlotSeeds.stashedItems.Count < 3)
        {
            //Causes
            //Start Owl Voice Commentary for next Stage 
            AudioManager.Instance.ShootAudioEvent_Owl_VL_T_6_5();

            Debug.Log("Stage_T_6_4 completed! Next Stage: " + stage_T_6_5);
            return stage_T_6_5;
        }
        else
        {
            return this;
        }
    }
}
