using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_1_4 : Stage
{
    //Private Variables
    private WitchSenses _witchSenses_R;
    private WitchSenses _witchSenses_L;

    //Public Variables
    public Stage_1_5 stage_1_5;

    //Serialized Variables
    [SerializeField] private RingMenuSlot inventorySlotBorage;
    [SerializeField] private GameObject woolPlant;

    public override Stage RunCurrentStage()
    {
        if (StageManager.Instance.currentStage == this && inventorySlotBorage.stashedItems.Count > 0)
        {
            //Causes
            //Start Owl Voice Commentary for next Stage 
            AudioManager.Instance.ShootAudioEvent_Owl_VL_1_5();

            //Toggle Highlight effects for Wool Plant // THIS WOULD NORMALLY BE IN STAGE_1_4 BUT WE SKIP THAT FOR NOW
            if (_witchSenses_R != null && _witchSenses_L != null)
            {
                _witchSenses_R.highlightedObjects.Add(woolPlant);
                _witchSenses_L.highlightedObjects.Add(woolPlant);

                //If witch senses are alreay active, enable emission keyword for freshly added quest items
                if (_witchSenses_R._witchSensesActive || _witchSenses_L._witchSensesActive)
                {
                    woolPlant.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
                }
            }

            Debug.Log("Stage_1_4 completed! Next Stage: " + stage_1_5);
            return stage_1_5;
        }
        else
        {
            return this;
        }
    }

    private void Start()
    {
        //Find Reference to both WitchSenses script (Right & Left Hands)
        _witchSenses_R = GameObject.FindGameObjectWithTag("RightHand").GetComponent<WitchSenses>();
        _witchSenses_L = GameObject.FindGameObjectWithTag("LeftHand").GetComponent<WitchSenses>();
    }
}
