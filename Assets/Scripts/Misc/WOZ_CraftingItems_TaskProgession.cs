using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WOZ_CraftingItems_TaskProgession : MonoBehaviour
{
    //Serialized Variables
    [SerializeField] Stage_1_7 stage_1_7;
    [SerializeField] Stage_3_4 stage_3_4;

    private void OnEnable()
    {
        if (StageManager.Instance.currentStage == stage_1_7)
        {
            //Advance Task Stage_1_7 to Stage_1_8
            stage_1_7.ToggleStageAdvancingFlag();
        }

        if (StageManager.Instance.currentStage == stage_3_4)
        {
            //Advance Task Stage_3_4 to Stage_3_5
            stage_3_4.ToggleStageAdvancingFlag();
        }
    }
}
