using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_1_8 : Stage
{
    //Private Variables
    private bool bandageApplied;
    private bool _conditionMet;
    private WitchSenses _witchSenses_R;
    private WitchSenses _witchSenses_L;

    //Public Variables
    public Stage_1_9 stage_1_9;

    //Serialized Variables
    [SerializeField] private GameObject tree;
    [SerializeField] private int owlVL_1_9_Length;

    public override Stage RunCurrentStage()
    {
        if (bandageApplied == true)
        {
            Debug.Log("Stage_1_8 completed! Next Stage: " + stage_1_9);
            return stage_1_9;
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
            AudioManager.Instance.ShootAudioEvent_Owl_VL_1_9();

            if (_witchSenses_R != null && _witchSenses_L != null)
            {
                //Disable Highlight effect for Tree
                _witchSenses_R.highlightedObjects.Remove(tree);
                _witchSenses_L.highlightedObjects.Remove(tree);
                //Disable Emmission effect for Tree
                tree.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
            }

            //START STAGE_1_9 OWL DIALOGUE HERE
            Invoke("StartTask2", owlVL_1_9_Length);

            //Stage Advancing Flag
            bandageApplied = true;
        }
    }

    private void Start()
    {
        //Find Reference to both WitchSenses script (Right & Left Hands)
        _witchSenses_R = GameObject.FindGameObjectWithTag("RightHand").GetComponent<WitchSenses>();
        _witchSenses_L = GameObject.FindGameObjectWithTag("LeftHand").GetComponent<WitchSenses>();
    }

    //Timed Function here
    private void StartTask2()
    {
        stage_1_9.ToggleStageAdvancingFlag();
    }
}
