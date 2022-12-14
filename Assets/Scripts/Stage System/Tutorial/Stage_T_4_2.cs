using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Stage_T_4_2 : Stage
{
    //Private Variables
    private bool _advancementBool;
    private bool _conditionMet;

    //Public Variables
    public Stage_T_5_1 stage_T_5_1;

    //Serialized Variables
    [SerializeField] private OwlNavigation owlNavScript;
    [SerializeField] private NavMeshAgent owlNavMeshAgent;

    public override Stage RunCurrentStage()
    {
        if (_advancementBool)
        {
            Debug.Log("Stage_T_4_2 completed! Next Stage: " + stage_T_5_1);
            return stage_T_5_1;
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
                AudioManager.Instance.ShootAudioEvent_Owl_VL_T_5_1();

                //Enable Owl Companion Follower Behavior by enabling the Owl Navigation Script
                owlNavScript.enabled = true;
                //Enable Owl Companion Follower Behavior by enabling the Owl Nav Mesh Agent
                owlNavMeshAgent.enabled = true;

                //Stage Advancing Flag
                _advancementBool = true;
            }
        }
    }
}
