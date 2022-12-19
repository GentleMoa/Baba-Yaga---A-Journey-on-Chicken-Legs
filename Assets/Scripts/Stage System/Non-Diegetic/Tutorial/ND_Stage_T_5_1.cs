using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ND_Stage_T_5_1 : Stage
{
    //Private Variables
    private bool _tutorialInitiated;
    private bool _advancementBool;
    private bool _conditionMet;

    //Public Variables
    public ND_Stage_T_5_2 ND_stage_T_5_2;

    //Serialized Variables
    [SerializeField] private Animator houseAnimator;
    [SerializeField] private RigidbodyInPlaceHolder rbStatisScript;

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

        if (_advancementBool)
        {
            //Hide the UI Prompt
            uiPrompt.GetComponent<Animator>().SetTrigger("UI_Hide");
            uiPrompt.Invoke("DisableUI", 0.3f);

            Debug.Log("Stage_T_5_1 completed! Next Stage: " + ND_stage_T_5_2);
            return ND_stage_T_5_2;
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

            //Causes
            GetComponent<Collider>().enabled = false;

            //Start House Animation
            houseAnimator.SetTrigger("BowDown");

            //Disable Rigidbody Stasis of interactables inside the house after the anim is finished
            rbStatisScript.Invoke("DisableRigidbodyStasis", 29.0f);

            Invoke("DelayedAdvancementFlagToggle", 20.0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (StageManager.Instance.currentStage == this)
            {
                ToggleStageAdvancingFlag();
            }
        }
    }

    private void DelayedAdvancementFlagToggle()
    {
        //Stage Advancing Flag
        _advancementBool = true;
    }

    private void UnhideUIPrompt()
    {
        uiPrompt.EnableUI();
        uiPrompt.GetComponent<Animator>().SetTrigger("UI_Show");
    }
}
