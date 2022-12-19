using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ND_Highlighting : MonoBehaviour
{
    //Serialized Variables
    [SerializeField] private InputActionReference input_primaryButton;
    [SerializeField] private ND_Highlighting oppositeHandScript;

    //Private Variables
    private bool _primaryButtonCooldown = false;
    private ND_UI_Highlighter storageVariable;

    //Public Variables
    [HideInInspector]
    public bool _highlightingActive = false;

    //Lists
    public List<GameObject> highlightedObjects = new List<GameObject>();

    void Start()
    {
        //Get all Objects that are interactable / quest related and add them to a list
        foreach (GameObject taggedObjects in GameObject.FindGameObjectsWithTag("HighlightedObject"))
        {
            //Add Objects with Tag "HighlightedObject" to highlightedObjects List
            highlightedObjects.Add(taggedObjects);

            //Remove Borage and Wool Plant Objects, because they are added to highlightedObjects List later tied to Task Stages
            for (int i = 0; i < highlightedObjects.Count; i++)
            {
                if (highlightedObjects[i].GetComponent<ItemController>() != null)
                {
                    if (highlightedObjects[i].GetComponent<ItemController>().Item.id == 1 || highlightedObjects[i].GetComponent<ItemController>().Item.id == 2)
                    {
                        //Debug.Log("Found to-be-removed Object: " + highlightedObjects[i]);
                        highlightedObjects.Remove(highlightedObjects[i]);
                    }
                }
            }
        }
    }

    void Update()
    {
        if (input_primaryButton.action.ReadValue<float>() == 0)
        {
            //Resetting the _primaryButtonCooldown
            _primaryButtonCooldown = false;
        }

        //On button press...
        if (input_primaryButton.action.ReadValue<float>() > 0 && _primaryButtonCooldown == false)
        {
            //Checking wether to activate or deactivate Highlighting
            if (_highlightingActive == false || oppositeHandScript._highlightingActive == false)
            {
                //Setting the _highlightingActive bool to true
                _highlightingActive = true;
                oppositeHandScript._highlightingActive = true;

                //ENABLE HIGHLIGHTING UI AND PLAY ANIM
                for (int i = 0; i < highlightedObjects.Count; i++)
                {
                    if (highlightedObjects[i] != null)
                    {
                        if (highlightedObjects[i].GetComponentInChildren<ND_UI_Highlighter>(true) != null)
                        {
                            highlightedObjects[i].GetComponentInChildren<ND_UI_Highlighter>(true).EnableHighlightingUI();
                            highlightedObjects[i].GetComponentInChildren<ND_UI_Highlighter>(true).GrowUISize();
                            //storageVariable = highlightedObjects[i].GetComponentInChildren(typeof(ND_UI_Highlighter), true) as ND_UI_Highlighter;
                            //storageVariable.EnableHighlightingUI();
                            //storageVariable.GrowUISize();
                        }
                    }
                }

                ////Play Audio
                //AudioManager.Instance.ShootAudioEvent_Player_WitchSenses_On();

                //Debug.Log("Witch Senses are activated!");
            }
            else if (_highlightingActive == true)
            {
                //Setting the _witchSensesActive bool to false
                _highlightingActive = false;
                oppositeHandScript._highlightingActive = false;

                //DISABLE HIGHLIGHTING UI AND PLAY REVERSE ANIM
                for (int i = 0; i < highlightedObjects.Count; i++)
                {
                    if (highlightedObjects[i].GetComponentInChildren<ND_UI_Highlighter>(true) != null)
                    {
                        highlightedObjects[i].GetComponentInChildren<ND_UI_Highlighter>(true).ShrinkUISize();
                        highlightedObjects[i].GetComponentInChildren<ND_UI_Highlighter>(true).Invoke("DisableHighlightingUI", 0.3f);
                        //storageVariable = highlightedObjects[i].GetComponentInChildren(typeof(ND_UI_Highlighter), true) as ND_UI_Highlighter;
                        //storageVariable.ShrinkUISize();
                        //storageVariable.Invoke("DisableHighlightingUI", 0.3f);
                    }
                }

                ////Play Audio
                //AudioManager.Instance.ShootAudioEvent_Player_WitchSenses_Off();

                //Debug.Log("Witch Senses are deactivated!");
            }

            //Activating the _primaryButtonCooldown
            _primaryButtonCooldown = true;
        }
    }
}
