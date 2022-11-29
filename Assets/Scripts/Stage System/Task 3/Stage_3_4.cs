using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_3_4 : Stage
{
    //Private Variables
    private bool _advancemetBool;
    private bool _conditionMet;
    private WitchSenses _witchSenses_L;
    private WitchSenses _witchSenses_R;

    //Public Variables
    public Stage_3_5 stage_3_5;
    public int totemsCrafted = 0;

    //Serialized Variables
    [SerializeField] private GameObject[] TotemSocketInteractors;

    public override Stage RunCurrentStage()
    {
        if (_advancemetBool == true)
        {
            Debug.Log("Stage_3_4 completed! Next Stage: " + stage_3_5);
            return stage_3_5;
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
            //Enable all Totem Socket Interactors at the clearing
            for (int i = 0; i < TotemSocketInteractors.Length; i++)
            {
                TotemSocketInteractors[i].SetActive(true);
            }

            //Add all Totem Socket Interactors to the Witch Senses List
            for (int i = 0; i < TotemSocketInteractors.Length; i++)
            {
                _witchSenses_L.highlightedSockets.Add(TotemSocketInteractors[i]);
                _witchSenses_R.highlightedSockets.Add(TotemSocketInteractors[i]);
            }

            //Stage Advancing Flag
            _advancemetBool = true;
        }
    }

    private void Start()
    {
        //Find Reference to both WitchSenses script (Right & Left Hands)
        _witchSenses_L = GameObject.FindGameObjectWithTag("LeftHand").GetComponent<WitchSenses>();
        _witchSenses_R = GameObject.FindGameObjectWithTag("RightHand").GetComponent<WitchSenses>();
    }
}
