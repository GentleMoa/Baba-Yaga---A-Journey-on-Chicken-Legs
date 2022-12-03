using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_T_5_3 : Stage
{
    //Private Variables
    private bool _advancementBool;
    private bool _conditionMet;

    //Public Variables
    public Stage_T_5_4 stage_T_5_4;

    //Serialized Variables
    [SerializeField] private int owlVL_T_5_4_Length;
    [SerializeField] private int owlVL_1_1_Length;

    public override Stage RunCurrentStage()
    {
        if (_advancementBool)
        {
            Debug.Log("Stage_T_5_3 completed! Next Stage: " + stage_T_5_4);
            return stage_T_5_4;
        }
        else
        {
            return this;
        }
    }

    public void ToggleStageAdvancingFlag()
    {
        if (StageManager.Instance.currentStage == this)
        {
            if (_conditionMet == false)
            {
                _conditionMet = true;

                //Causes
                //Start Owl Voice Commentary for next Stage 
                AudioManager.Instance.ShootAudioEvent_Owl_VL_T_5_4();

                Invoke("DelayedFlagSetter_T_5_3", owlVL_T_5_4_Length);
            }
        }
    }

    private void DelayedFlagSetter_T_5_3()
    {
        Invoke("DelayedFlagSetter_T_5_4", owlVL_1_1_Length);

        //Stage Advancing Flag
        _advancementBool = true;
    }

    private void DelayedFlagSetter_T_5_4()
    {
        stage_T_5_4.ToggleStageAdvancingFlag();
    }
}
