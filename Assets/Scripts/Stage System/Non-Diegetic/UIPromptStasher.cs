using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class UIPromptStasher : MonoBehaviour
{
    //Privat Variables
    private StageManager _stageManager;

    //Serialized Variables
    [SerializeField] private Stage currentlyActiveStage;

    void Start()
    {
        //Grab reference to the Stage
        _stageManager = StageManager.Instance;
        
        //Subscribe to Event
        _stageManager.SS_OnStageSwitched += CheckForUITextPromptWithAnimator;
    }

    private void OnTriggerEnter(Collider other)
    {
        //If either hand of the user is touching this trigger collider
        if (other.gameObject.GetComponent<ActionBasedController>() != null)
        {
            //If there is an currently active stage with an animator
            if (currentlyActiveStage != null)
            {
                //Play the Show UI Animations
                currentlyActiveStage.uiPrompt.GetComponent<Animator>().SetTrigger("UI_Show");
            }
        }
    }

    private void CheckForUITextPromptWithAnimator()
    {
        //If the current stage has an assigned UI Prompt...
        if (_stageManager.currentStage.uiPrompt != null)
        {
            //If that UI Prompt has an Animator component...
            if (_stageManager.currentStage.uiPrompt.GetComponent<Animator>() != null)
            {
                currentlyActiveStage = _stageManager.currentStage;
            }
        }
    }

    private void OnDisable()
    {
        //Unsubscribe from Event
        _stageManager.SS_OnStageSwitched -= CheckForUITextPromptWithAnimator;
    }
}
