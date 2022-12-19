using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ND_Stage_T_6_2B : Stage
{
    //Private Variables
    private bool _tutorialInitiated;

    //Public Variables
    public ND_Stage_T_6_3 ND_stage_T_6_3;

    //Serialized Variables
    [SerializeField] private ND_I_ItemSlots inventorySlotSeeds;

    public override Stage RunCurrentStage()
    {
        //If tutorial hasn't started yet...
        if (_tutorialInitiated == false)
        {
            //Set Flag
            _tutorialInitiated = true;

            //Start tutorial
            Invoke("UnhideUIPrompt", 2.0f);
        }

        if (StageManager.Instance.currentStage == this && inventorySlotSeeds.stashedItems.Count == 1)
        {
            //Hide the UI Prompt
            uiPrompt.GetComponent<Animator>().SetTrigger("UI_Hide");
            uiPrompt.Invoke("DisableUI", 0.3f);

            Debug.Log("Stage_T_6_2 completed! Next Stage: " + ND_stage_T_6_3);
            return ND_stage_T_6_3;
        }
        else
        {
            return this;
        }
    }

    private void UnhideUIPrompt()
    {
        uiPrompt.EnableUI();
        uiPrompt.GetComponent<Animator>().SetTrigger("UI_Show");
    }
}
