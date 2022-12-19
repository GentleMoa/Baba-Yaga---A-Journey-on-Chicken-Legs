using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ND_Stage_T_6_5 : Stage
{
    //Private Variables
    private bool _tutorialInitiated;
    private ND_Inventory_Accessor _inventoryScript_L;

    //Public Variables
    public ND_Stage_T_5_3 ND_stage_T_5_3;

    //Serialized Variables
    [SerializeField] private ND_I_ItemSlots inventorySlotSeeds;
    [SerializeField] private InputActionReference inventoryButton_L;
    [SerializeField] private InputActionReference inventoryButton_R;

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

        if (_inventoryScript_L._inventoryOpen == true && inventorySlotSeeds.stashedItems.Count == 3)
        {
            //Hide the UI Prompt
            uiPrompt.GetComponent<Animator>().SetTrigger("UI_Hide");
            uiPrompt.Invoke("DisableUI", 0.3f);

            Debug.Log("Stage_T_6_5 completed! Next Stage: " + ND_stage_T_5_3);
            return ND_stage_T_5_3;
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
