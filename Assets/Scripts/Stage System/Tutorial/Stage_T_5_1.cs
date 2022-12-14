using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_T_5_1 : Stage
{
    //Private Variables
    private bool _advancementBool;
    private bool _conditionMet;

    //Public Variables
    public Stage_T_5_2 stage_T_5_2;

    //Serialized Variables
    [SerializeField] private Animator houseAnimator;
    [SerializeField] private RigidbodyInPlaceHolder rbStatisScript;

    public override Stage RunCurrentStage()
    {
        if (_advancementBool)
        {
            Debug.Log("Stage_T_5_1 completed! Next Stage: " + stage_T_5_2);
            return stage_T_5_2;
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

            //Start Owl Voice Commentary for next Stage 
            Invoke("StartOwlVoiceCommentaryForNextStage", 6.0f);

            //Start House Animation
            houseAnimator.SetTrigger("BowDown");

            //Disable Rigidbody Stasis of interactables inside the house
            rbStatisScript.Invoke("DisableRigidbodyStasis", 29.0f);

            //Stage Advancing Flag
            _advancementBool = true;
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

    private void StartOwlVoiceCommentaryForNextStage()
    {
        //Start Owl Voice Commentary for next Stage 
        AudioManager.Instance.ShootAudioEvent_Owl_VL_T_5_2();
    }
}
