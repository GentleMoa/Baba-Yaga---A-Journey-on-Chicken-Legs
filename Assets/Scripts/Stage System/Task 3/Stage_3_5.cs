using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_3_5 : Stage
{
    //Private Variables
    private bool _advancemetBool;
    private bool _conditionMet;

    //Public Variables
    public Stage_3_6 stage_3_6;

    //Serialized Variables
    [SerializeField] private int owlVL_3_6_Length;

    public override Stage RunCurrentStage()
    {
        if (_advancemetBool == true)
        {
            Debug.Log("Stage_3_5 completed! Next Stage: " + stage_3_6);
            return stage_3_6;
        }
        else
        {
            return this;
        }
    }

    //Triggered by hanging 1 Totem on a tree on the clearing
    public void ToggleStageAdvancingFlag()
    {
        if (_conditionMet == false)
        {
            _conditionMet = true;

            //Causes
            //Start Owl Voice Commentary for next Stage 
            AudioManager.Instance.ShootAudioEvent_Owl_VL_3_6();


            Invoke("BeginEnding", owlVL_3_6_Length);

            //Stage Advancing Flag
            _advancemetBool = true;
        }
    }

    private void BeginEnding()
    {
        stage_3_6.ToggleStageAdvancingFlag();
    }
}
