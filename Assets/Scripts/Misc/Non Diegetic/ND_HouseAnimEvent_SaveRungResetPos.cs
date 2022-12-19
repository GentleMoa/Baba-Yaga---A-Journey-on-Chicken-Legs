using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ND_HouseAnimEvent_SaveRungResetPos : MonoBehaviour
{
    //Serialized Variables
    [SerializeField] private ND_ClimbDownLadder ND_climbDownScript;
    [SerializeField] private ND_ClimbUpLadder[] ND_climbingUpScripts;

    //These function are called by the Animation Event set at the very end of the House Bowing Down Animation
    //They have to be in a script on the same object as the animator holding the corresponding animation with the animation event.

    public void SaveButtonInteractableResetPosition()
    {
        ND_climbDownScript.SaveInteractableStartPos();
    }


    public void SaveLadderRungInteractableResetPosition()
    {
        //Set reset positon for ladder rung interactables
        for (int i = 0; i < ND_climbingUpScripts.Length; i++)
        {
            ND_climbingUpScripts[i].SaveInteractableStartPos();
        }
    }
}
