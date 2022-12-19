using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_3_3 : Stage
{
    //Private Variables
    private bool _initialCodeToRun;
    private bool _advancemetBool;
    private bool _conditionMet;

    //Public Variables
    public Stage_3_4 stage_3_4;

    //Serialized Variables
    [SerializeField] private CraftingSlot craftingSlot_R;

    public override Stage RunCurrentStage()
    {
        //Code to be executed in the beginning of this state
        if (_initialCodeToRun == false)
        {
            //Set Flag
            _initialCodeToRun = true;

            //Disable the right Craftin Slot to prevent crafting system from falling apart due to inproper ingred placement
            craftingSlot_R.gameObject.SetActive(false);
        }

        if (_advancemetBool == true)
        {
            Debug.Log("Stage_3_3 completed! Next Stage: " + stage_3_4);
            return stage_3_4;
        }
        else
        {
            return this;
        }
    }

    public void ToggleStageAdvancingFlag()
    {
        if (StageManager.Instance.currentStage == this.GetComponent<Stage_3_3>())
        {
            if (_conditionMet == false)
            {
                _conditionMet = true;

                //Causes
                //Start Owl Voice Commentary for next Stage 
                AudioManager.Instance.ShootAudioEvent_Owl_VL_3_4();

                //Stage Advancing Flag
                _advancemetBool = true;
            }
        }
    }
}
