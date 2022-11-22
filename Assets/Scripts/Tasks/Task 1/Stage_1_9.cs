using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_1_9 : Stage
{
    //Private Variables
    private bool owlCommentFinished;

    //Public Variables
    //public Stage_2_1 stage_2_1;

    public override Stage RunCurrentStage()
    {
        //if (owlCommentFinished == true)
        //{
        //    //return stage_2_1;
        //}
        //else
        //{
        //    return this;
        //}

        Debug.Log("Task 1 Completed!");
        return this;
    }
}
