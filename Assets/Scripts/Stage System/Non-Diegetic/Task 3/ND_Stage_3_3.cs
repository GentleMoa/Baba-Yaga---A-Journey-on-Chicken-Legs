using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ND_Stage_3_3 : Stage
{
    //Private Variables
    private bool _tutorialInitiated;
    private bool _advancemetBool;
    private bool _conditionMet;

    //Public Variables
    public ND_Stage_3_4 ND_stage_3_4;

    //Serialized Variables
    [SerializeField] private ND_CraftingSlot craftingSlot_R;

    public override Stage RunCurrentStage()
    {
        //If tutorial hasn't started yet...
        if (_tutorialInitiated == false)
        {
            //Set Flag
            _tutorialInitiated = true;

            //Start tutorial
            Invoke("UnhideUIPrompt", 2.0f);

            //Disable the right Craftin Slot to prevent crafting system from falling apart due to inproper ingred placement
            craftingSlot_R.gameObject.SetActive(false);
        }

        if (_advancemetBool == true)
        {
            //Hide the UI Prompt
            uiPrompt.GetComponent<Animator>().SetTrigger("UI_Hide");
            uiPrompt.Invoke("DisableUI", 0.3f);

            Debug.Log("Stage_3_3 completed! Next Stage: " + ND_stage_3_4);
            return ND_stage_3_4;
        }
        else
        {
            return this;
        }
    }

    public void ToggleStageAdvancingFlag()
    {
        if (_conditionMet == false)
        {
            _conditionMet = true;

            //Stage Advancing Flag
            _advancemetBool = true;
        }
    }

    private void UnhideUIPrompt()
    {
        uiPrompt.EnableUI();
        uiPrompt.GetComponent<Animator>().SetTrigger("UI_Show");
    }
}
