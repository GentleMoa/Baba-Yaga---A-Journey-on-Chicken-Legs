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

    //Serialized Variables
    [SerializeField] DiegeticInventory_Button diegeticInventory_Button;

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

        //Stage Advancing Flag
        _inventoryOpened = true;
    }
}
