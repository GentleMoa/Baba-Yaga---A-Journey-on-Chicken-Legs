using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ND_WOZ_CraftingItems_TaskProgession : MonoBehaviour
{
    //Serialized Variables
    [SerializeField] ND_Stage_1_7 ND_stage_1_7;
    [SerializeField] ND_Stage_3_4 ND_stage_3_4;

    private void OnEnable()
    {
        if (StageManager.Instance.currentStage == ND_stage_1_7)
        {
            //Advance Task Stage_1_7 to Stage_1_8
            ND_stage_1_7.ToggleStageAdvancingFlag();
        }

        if (StageManager.Instance.currentStage == ND_stage_3_4)
        {
            //Advance Task Stage_3_4 to Stage_3_5
            ND_stage_3_4.ToggleStageAdvancingFlag();
        }
    }
}
