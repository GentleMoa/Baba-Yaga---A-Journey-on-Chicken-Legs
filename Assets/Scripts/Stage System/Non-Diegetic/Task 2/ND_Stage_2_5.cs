using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ND_Stage_2_5 : Stage
{
    //Private Variables
    private bool _advancemetBool;
    private bool _conditionMet;
    private WitchSenses _witchSenses_R;
    private WitchSenses _witchSenses_L;

    //Public Variables
    public ND_Stage_3_1 ND_stage_3_1;

    //Serialized Variables
    [SerializeField] private GameObject[] sticks;

    public override Stage RunCurrentStage()
    {
        if (_advancemetBool == true)
        {
            Debug.Log("Task 2 Completed! Next Stage: " + ND_stage_3_1);
            return ND_stage_3_1;
        }
        else
        {
            Debug.Log("Task 2 Completed!");
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
            AudioManager.Instance.ShootAudioEvent_Owl_VL_3_1();

            for (int i = 0; i < sticks.Length; i++)
            {
                //Activate Sticks
                sticks[i].SetActive(true);

                //Add Sticks to highlightedObjects List
                _witchSenses_R.highlightedObjects.Add(sticks[i]);
                _witchSenses_L.highlightedObjects.Add(sticks[i]);

                //If witch senses are alreay active, enable emission keyword for freshly added quest items
                if (_witchSenses_R._witchSensesActive || _witchSenses_L._witchSensesActive)
                {
                    sticks[i].GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
                }
            }

            //Stage Advancing Flag
            _advancemetBool = true;
        }
    }

    private void Start()
    {
        //Find Reference to both WitchSenses script (Right & Left Hands)
        _witchSenses_R = GameObject.FindGameObjectWithTag("RightHand").GetComponent<WitchSenses>();
        _witchSenses_L = GameObject.FindGameObjectWithTag("LeftHand").GetComponent<WitchSenses>();
    }

}
