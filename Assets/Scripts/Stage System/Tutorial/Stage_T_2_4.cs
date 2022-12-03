using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_T_2_4 : Stage
{
    //Private Variables
    private bool _advancementBool;
    private bool _tutorialInitiated;

    //Public Variables
    public Stage_T_3_1 stage_T_3_1;

    //Serialized Variables
    [SerializeField] private int owlVLLength;

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
            Debug.Log("Stage_T_2_4 completed! Next Stage: " + stage_T_3_1);
            return stage_T_3_1;
        }
        else
        {
            return this;
        }
    }

    private void OwlCommentary()
    {
        //Start Owl Voice Commentary
        AudioManager.Instance.ShootAudioEvent_Owl_VL_T_2_4();

        //Start delay Coroutine to toggle the stage advancing flag when the voice commentary has finished
        StartCoroutine(ToggleStageAdvancingFlag(owlVLLength));
    }

    IEnumerator ToggleStageAdvancingFlag(float waitSeconds)
    {
        yield return new WaitForSeconds(waitSeconds);

        //Causes
        //Start Owl Voice Commentary for next Stage 
        AudioManager.Instance.ShootAudioEvent_Owl_VL_T_3_1();

        _advancementBool = true;
    }
}
