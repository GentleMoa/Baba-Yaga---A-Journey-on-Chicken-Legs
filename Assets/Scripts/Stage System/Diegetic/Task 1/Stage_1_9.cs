using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_1_9 : Stage
{
    //Private Variables
    private bool owlCommentFinished;
    private bool _conditionMet;

    //Public Variables
    public Stage_2_1 stage_2_1;

    public override Stage RunCurrentStage()
    {
        if (owlCommentFinished == true)
        {
            Debug.Log("Task 1 Completed! Next Stage: " + stage_2_1);
            return stage_2_1;
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
            //Start Owl Voice Commentary for next Stage 
            AudioManager.Instance.ShootAudioEvent_Owl_VL_2_1();

            Invoke("StartTask2", 17.0f);
        }
    }

    private void StartTask2()
    {
        //Set Advancement Flag
        owlCommentFinished = true;
    }
}
