using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ND_Stage_2_1 : Stage
{
    //Private Variables
    private bool _inventoryOpened;
    private bool _conditionMet;

    //Public Variables
    public ND_Stage_2_2 ND_stage_2_2;

    //Serialized Variables
    [SerializeField] DiegeticInventory_Button diegeticInventory_Button;

    public override Stage RunCurrentStage()
    {
        if (_inventoryOpened)
        {
            Debug.Log("Stage_2_1 completed! Next Stage: " + ND_stage_2_2);
            return ND_stage_2_2;
        }
        else
        {
            return this;
        }
    }

    private void Update()
    {
        if (StageManager.Instance.currentStage == this)
        {
            if (diegeticInventory_Button.inventoryOpen == true)
            {
                if (_conditionMet == false)
                {
                    _conditionMet = true;

                    ToggleStageAdvancingFlag();
                }
            }
        }
    }

    public void ToggleStageAdvancingFlag()
    {
        //Causes
        //Start Owl Voice Commentary for next Stage 
        AudioManager.Instance.ShootAudioEvent_Owl_VL_2_2();

        //Stage Advancing Flag
        _inventoryOpened = true;
    }
}
