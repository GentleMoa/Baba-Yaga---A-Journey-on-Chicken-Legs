using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public Stage currentStage;

    //Singleton
    public static StageManager Instance { set; get; }

    //Event
    public event Action SS_OnStageSwitched;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

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

        //Shoot Event
        if (SS_OnStageSwitched != null)
        {
            SS_OnStageSwitched();
        }
    }
}
