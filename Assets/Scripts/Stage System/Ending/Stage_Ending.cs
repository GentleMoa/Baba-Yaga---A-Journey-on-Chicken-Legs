using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_Ending : Stage
{
    public override Stage RunCurrentStage()
    {
        Debug.Log("Congratulations! You have finished the experience! Thank you for playing!");
        return this;
    }
}
