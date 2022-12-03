using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_1_2 : Stage
{
    //Private Variables
    private bool hatchedRemoved;
    private bool _conditionMet;
    private WitchSenses _witchSenses_R;
    private WitchSenses _witchSenses_L;

    //Public Variables
    public Stage_1_3 stage_1_3;

    //Serialized Variables
    [SerializeField] private GameObject borage;
    [SerializeField] private GameObject hatchet;

    public override Stage RunCurrentStage()
    {
        if (hatchedRemoved == true)
        {
            Debug.Log("Stage_1_2 completed! Next Stage: " + stage_1_3);
            return stage_1_3;
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
            AudioManager.Instance.ShootAudioEvent_Owl_VL_1_3();

            if (_witchSenses_R != null && _witchSenses_L != null)
            {
                //Enable Highlight effect for Borage
                _witchSenses_R.highlightedObjects.Add(borage);
                _witchSenses_L.highlightedObjects.Add(borage);
                //Disable Highlight effect for Hatchet
                _witchSenses_R.highlightedObjects.Remove(hatchet);
                _witchSenses_L.highlightedObjects.Remove(hatchet);
                //Disable Emission effect for Hatchet
                hatchet.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
            }



            //Stage Advancing Flag
            hatchedRemoved = true;
        }
    }

    private void Start()
    {
        //Find Reference to both WitchSenses script (Right & Left Hands)
        _witchSenses_R = GameObject.FindGameObjectWithTag("RightHand").GetComponent<WitchSenses>();
        _witchSenses_L = GameObject.FindGameObjectWithTag("LeftHand").GetComponent<WitchSenses>();
    }
}
