using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ND_Stage_2_4 : Stage
{
    //Private Variables
    private bool _allSeedsPlanted;
    private bool _conditionMet;

    //Public Variables
    public ND_Stage_2_5 ND_stage_2_5;
    public int plantedSeeds = 0;

    //Serialized Variables
    [SerializeField] private int owlVL_2_5_Length;

    public override Stage RunCurrentStage()
    {
        if (_allSeedsPlanted == true)
        {
            Debug.Log("Stage_2_4 completed! Next Stage: " + ND_stage_2_5);
            return ND_stage_2_5;
        }
        else
        {
            return this;
        }
    }

    public void ToggleStageAdvancingFlag()
    {
        //Causes
        //Start Owl Voice Commentary for next Stage 
        AudioManager.Instance.ShootAudioEvent_Owl_VL_2_5();

        //PLAY OWL COMMENTARY
        Invoke("StartTask3", owlVL_2_5_Length);

        //Stage Advancing Flag
        _allSeedsPlanted = true;
    }

    private void Update()
    {
        //if counter at 3 call ToggleStageAdvancingFlag() for Stage_2_4
        if (plantedSeeds == 3)
        {
            if (_conditionMet == false)
            {
                _conditionMet = true;

                ToggleStageAdvancingFlag();
            }
        }
    }

    private void StartTask3()
    {
        ND_stage_2_5.ToggleStageAdvancingFlag();
    }
}
