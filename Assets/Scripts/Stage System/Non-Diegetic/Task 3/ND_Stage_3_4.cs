using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ND_Stage_3_4 : Stage
{
    //Private Variables
    private bool _tutorialInitiated;
    private bool _advancemetBool;
    private bool _conditionMet;
    private ND_Highlighting _highlightingScript_L;
    private ND_Highlighting _highlightingScript_R;

    //Public Variables
    public ND_Stage_3_5 ND_stage_3_5;
    public int totemsCrafted = 0;

    //Serialized Variables
    [SerializeField] private GameObject[] TotemSocketInteractors;

    void Start()
    {
        //Find Reference to both ND_Highlighting scripts (Right & Left Hands)
        _highlightingScript_L = GameObject.FindGameObjectWithTag("LeftHand").GetComponent<ND_Highlighting>();
        _highlightingScript_R = GameObject.FindGameObjectWithTag("RightHand").GetComponent<ND_Highlighting>();
    }

    public override Stage RunCurrentStage()
    {
        //If tutorial hasn't started yet...
        if (_tutorialInitiated == false)
        {
            //Set Flag
            _tutorialInitiated = true;

            //Start tutorial
            Invoke("UnhideUIPrompt", 2.0f);
        }

        if (_advancemetBool == true)
        {
            //Hide the UI Prompt
            uiPrompt.GetComponent<Animator>().SetTrigger("UI_Hide");
            uiPrompt.Invoke("DisableUI", 0.3f);

            Debug.Log("Stage_3_4 completed! Next Stage: " + ND_stage_3_5);
            return ND_stage_3_5;
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

            //Enable all Totem Socket Interactors at the clearing
            for (int i = 0; i < TotemSocketInteractors.Length; i++)
            {
                TotemSocketInteractors[i].SetActive(true);
            }

            //Add all Totem Socket Interactors to the Witch Senses List
            for (int i = 0; i < TotemSocketInteractors.Length; i++)
            {
                //Add borage to highlightedObjects list
                _highlightingScript_L.highlightedObjects.Add(TotemSocketInteractors[i]);
                _highlightingScript_R.highlightedObjects.Add(TotemSocketInteractors[i]);
            }

            //Stage Advancing Flag
            _advancemetBool = true;
        }
    }

    private void UnhideUIPrompt()
    {
        uiPrompt.EnableUI();
        uiPrompt.GetComponent<Animator>().SetTrigger("UI_Show");
    }
}
