using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_Ending : Stage
{
    //Private Variables
    private bool _experienceCompleted;

    public override Stage RunCurrentStage()
    {
        if (_experienceCompleted == false)
        {
            _experienceCompleted = true;

            Debug.Log("Congratulations! You have finished the experience! Thank you for playing!");
            return this;
        }
        else
        {
            return this;
        }
    }
}
