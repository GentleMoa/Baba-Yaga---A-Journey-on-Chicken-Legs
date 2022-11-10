//AudioManager to provide a ordered workflow for audio triggering during runtime
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //Audio Events
    //Audio Events named by this convention: "AudioEvent" + "Audio Source Gameobject" + "Audio Specification"
    //For example: "AE_Player_WitchSenses_On" ---> "AE" (marking it as Audio Event), "Player" (the gameobject which will play the sound), "WitchSenses_On" (the specific sound that will be played)
    public event Action AE_Player_WitchSenses_On;
    public event Action AE_Player_WitchSenses_Off;

    //Singleton
    public static AudioManager Instance { set; get; }

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

    //Audio Events Activation
    public void ShootAudioEvent_Player_WitchSenses_On()
    {
        AE_Player_WitchSenses_On();
    }

    public void ShootAudioEvent_Player_WitchSenses_Off()
    {
        AE_Player_WitchSenses_Off();
    }
}
