using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleTotemSocketIndicator : MonoBehaviour
{
    //Private Variables
    private WitchSenses _witchSenses_R;
    private WitchSenses _witchSenses_L;

    private void Start()
    {
        //Find Reference to both WitchSenses script (Right & Left Hands)
        _witchSenses_R = GameObject.FindGameObjectWithTag("RightHand").GetComponent<WitchSenses>();
        _witchSenses_L = GameObject.FindGameObjectWithTag("LeftHand").GetComponent<WitchSenses>();
    }

    public void ToggleIndicator(bool toggle)
    {
        if (toggle)
        {
            //Add Socket Indicator to WitchSenses Socket List
            _witchSenses_R.highlightedSockets.Add(gameObject);
            _witchSenses_L.highlightedSockets.Add(gameObject);

            //If WitchSenses are currently active...
            if (_witchSenses_R._witchSensesActive || _witchSenses_L._witchSensesActive)
            {
                //Enable Mesh Renderer
                GetComponent<Renderer>().enabled = true;

                //Enable Emission Keyword
                GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            }
            //If WitchSenses are currently NOT active...
            else
            {
                //Disable Mesh Renderer
                GetComponent<Renderer>().enabled = false;
            }
        }
        else
        {
            //Remove Socket Indicator from WitchSenses Socket List
            _witchSenses_R.highlightedSockets.Remove(gameObject);
            _witchSenses_L.highlightedSockets.Remove(gameObject);

            //Disable Emission Keyword
            GetComponent<Renderer>().material.DisableKeyword("_EMISSION");

            //Disable Mesh Renderer
            GetComponent<Renderer>().enabled = false;
        }
    }
}
