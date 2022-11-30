using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_T_1_3 : Stage
{
    //Private Variables
    private bool _advancementBool;
    private bool _tutorialInitiated;

    //Public Variables
    public Stage_T_2_1 stage_T_2_1;

    public override Stage RunCurrentStage()
    {
        //If tutorial hasn't started yet...
        if (_tutorialInitiated == false)
        {
            //Set Flag
            _tutorialInitiated = true;

            //Start tutorial
            OwlCommentary();
        }

        if (_advancementBool)
        {
            Debug.Log("Stage_T_1_3 completed! Next Stage: " + stage_T_2_1);
            return stage_T_2_1;
        }
        else
        {
            return this;
        }
    }

    private void OwlCommentary()
    {
        //Start Owl Voice Commentary

        //Start delay Coroutine to toggle the stage advancing flag when the voice commentary has finished
        StartCoroutine(ToggleStageAdvancingFlag(3.0f)); //3 secs as a default value
    }

    IEnumerator ToggleStageAdvancingFlag(float waitSeconds)
    {
        yield return new WaitForSeconds(waitSeconds);

        _advancementBool = true;
    }
}
