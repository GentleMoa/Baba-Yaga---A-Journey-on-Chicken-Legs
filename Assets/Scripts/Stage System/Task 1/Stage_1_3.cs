using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_1_3 : Stage
{
    //Private Variables
    private bool borageGathered;
    private bool _conditionMet;
    private WitchSenses _witchSenses_R;
    private WitchSenses _witchSenses_L;

    //Public Variables
    public Stage_1_4 stage_1_4;
    public Stage_1_5 stage_1_5;

    //Serialized Variables
    [SerializeField] private GameObject woolPlant;

    public override Stage RunCurrentStage()
    {
        if (borageGathered == true)
        {
            //Debug.Log("Stage_1_3 completed! Next Stage: " + stage_1_4);
            //return stage_1_4;

            Debug.Log("Stage_1_3 completed! Next Stage: " + stage_1_5 + ". This is due the inventory system not being implemented yet!");
            return stage_1_5;
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

            //Toggle Highlight effects for Wool Plant // THIS WOULD NORMALLY BE IN STAGE_1_4 BUT WE SKIP THAT FOR NOW
            if (_witchSenses_R != null && _witchSenses_L != null)
            {
                _witchSenses_R.highlightedObjects.Add(woolPlant);
                _witchSenses_L.highlightedObjects.Add(woolPlant);
            }

            //Stage Advancing Flag
            borageGathered = true;
        }
    }

    private void Start()
    {
        //Find Reference to both WitchSenses script (Right & Left Hands)
        _witchSenses_R = GameObject.FindGameObjectWithTag("RightHand").GetComponent<WitchSenses>();
        _witchSenses_L = GameObject.FindGameObjectWithTag("LeftHand").GetComponent<WitchSenses>();
    }
}
