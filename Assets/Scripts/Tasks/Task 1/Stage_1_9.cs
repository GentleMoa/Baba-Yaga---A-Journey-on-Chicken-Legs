using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_1_9 : Stage
{
    //Private Variables
    private bool owlCommentFinished;
    private bool _conditionMet;
    private WitchSenses _witchSenses_R;
    private WitchSenses _witchSenses_L;

    //Public Variables
    public Stage_2_1 stage_2_1;

    //Serialized Variables
    [SerializeField] private GameObject[] wondersproutSeeds;

    public override Stage RunCurrentStage()
    {
        if (owlCommentFinished == true)
        {
            Debug.Log("Task 1 Completed!");
            return stage_2_1;
        }
        else
        {
            return this;
        }

        //Debug.Log("Task 1 Completed!");
        //return this;
    }

    public void ToggleStageAdvancingFlag()
    {
        if (_conditionMet == false)
        {
            _conditionMet = true;

            //Enable Wondersprout Seeds
            for (int i = 0; i < wondersproutSeeds.Length; i++)
            {
                wondersproutSeeds[i].SetActive(true);
                _witchSenses_L.highlightedObjects.Add(wondersproutSeeds[i]);
                _witchSenses_R.highlightedObjects.Add(wondersproutSeeds[i]);
            }

            //Set Advancement Flag
            owlCommentFinished = true;
        }
    }

    private void Start()
    {
        //Find Reference to both WitchSenses script (Right & Left Hands)
        _witchSenses_R = GameObject.FindGameObjectWithTag("RightHand").GetComponent<WitchSenses>();
        _witchSenses_L = GameObject.FindGameObjectWithTag("LeftHand").GetComponent<WitchSenses>();
    }
}
