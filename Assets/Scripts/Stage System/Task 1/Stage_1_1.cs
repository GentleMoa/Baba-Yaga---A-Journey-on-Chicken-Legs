using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_1_1 : Stage
{
    //Private Variables
    private bool _closeToTree;
    private bool _conditionMet;

    //Public Variables
    public Stage_1_2 stage_1_2;

    public override Stage RunCurrentStage()
    {
        if (_closeToTree == true)
        {
            Debug.Log("Stage_1_1 completed! Next Stage: " + stage_1_2);
            return stage_1_2;
        }
        else
        {
            return this;
        }
    }

    //Stage Advancing Condition is tested here
    private void OnTriggerEnter(Collider other)
    {
        if (_conditionMet == false)
        {
            if (other.gameObject.tag == "Player")
            {
                _conditionMet = true;

                //Causes
                //Start Owl Voice Commentary for next Stage 
                AudioManager.Instance.ShootAudioEvent_Owl_VL_1_2();

                //Stage Advancing Flag
                _closeToTree = true;
            }
        }
    }
}
