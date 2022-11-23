using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_2_3 : Stage
{
    //Private Variables
    private bool _arrivedAtClearing;
    private bool _conditionMet;

    //Public Variables
    public Stage_2_4 stage_2_4;

    //Serialized Variables
    [SerializeField] private SeedPlanting[] seedPlantingScripts;

    public override Stage RunCurrentStage()
    {
        if (_arrivedAtClearing == true)
        {
            Debug.Log("Stage_2_3 completed! Next Stage: " + stage_2_4);
            return stage_2_4;
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
            //Disable Trigger Collider
            GetComponent<BoxCollider>().enabled = false;
            //Enable Planting Counter script
            for (int i = 0; i < seedPlantingScripts.Length; i++)
            {
                seedPlantingScripts[i].plantingActivated = true;
            }

            //Stage Advancing Flag
            _arrivedAtClearing = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ToggleStageAdvancingFlag();
        }
    }

}
