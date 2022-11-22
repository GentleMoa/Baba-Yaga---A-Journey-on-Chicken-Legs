using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public Stage currentStage;

    void Update()
    {
        RunStageMachine();
    }

    private void RunStageMachine()
    {
        Stage nextStage = currentStage?.RunCurrentStage();

        if (nextStage != null)
        {
            SwitchToTheNextStage(nextStage);
        }
    }

    private void SwitchToTheNextStage(Stage nextStage)
    {
        currentStage = nextStage;
    }
}
