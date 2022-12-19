using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ND_Stage_2_1 : Stage
{
    //Private Variables
    private bool _tutorialInitiated;
    private ND_Inventory_Accessor _inventoryScript_L;

    //Public Variables
    public ND_Stage_2_2 ND_stage_2_2;

    void Start()
    {
        //Find Reference to both ND_Highlighting scripts (Right & Left Hands)
        _inventoryScript_L = GameObject.FindGameObjectWithTag("LeftHand").GetComponent<ND_Inventory_Accessor>();
    }

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

        if (_inventoryScript_L._inventoryOpen == true)
        {
            //Hide the UI Prompt
            uiPrompt.GetComponent<Animator>().SetTrigger("UI_Hide");
            uiPrompt.Invoke("DisableUI", 0.3f);

            Debug.Log("Stage_2_1 completed! Next Stage: " + ND_stage_2_2);
            return ND_stage_2_2;
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
