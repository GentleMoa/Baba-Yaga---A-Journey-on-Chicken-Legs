//AudioManager to provide a ordered workflow for audio triggering during runtime
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    #region AudioEvents

    //Audio Events
    //Audio Events named by this convention: "AudioEvent" + "Audio Source Gameobject" + "Audio Specification"
    //For example: "AE_Player_WitchSenses_On" ---> "AE" (marking it as Audio Event), "Player" (the gameobject which will play the sound), "WitchSenses_On" (the specific sound that will be played)
    public event Action AE_Player_WitchSenses_On;
    public event Action AE_Player_WitchSenses_Off;

    public event Action AE_Owl_VL_T_1_1;
    public event Action AE_Owl_VL_T_1_2;
    public event Action AE_Owl_VL_T_1_3;
    public event Action AE_Owl_VL_T_2_1;
    public event Action AE_Owl_VL_T_2_2;
    public event Action AE_Owl_VL_T_2_3;
    public event Action AE_Owl_VL_T_2_4;
    public event Action AE_Owl_VL_T_3_1;
    public event Action AE_Owl_VL_T_3_2;
    public event Action AE_Owl_VL_T_4_1;
    public event Action AE_Owl_VL_T_4_2;
    public event Action AE_Owl_VL_T_5_1;
    public event Action AE_Owl_VL_T_5_2;
    public event Action AE_Owl_VL_T_5_3;
    public event Action AE_Owl_VL_T_5_4;
    public event Action AE_Owl_VL_T_6_1;
    public event Action AE_Owl_VL_T_6_2;
    public event Action AE_Owl_VL_T_6_3;
    public event Action AE_Owl_VL_T_6_4;
    public event Action AE_Owl_VL_T_6_5;

    public event Action AE_Owl_VL_1_1;
    public event Action AE_Owl_VL_1_2;
    public event Action AE_Owl_VL_1_3;
    public event Action AE_Owl_VL_1_4;
    public event Action AE_Owl_VL_1_5;
    public event Action AE_Owl_VL_1_6;
    public event Action AE_Owl_VL_1_7;
    public event Action AE_Owl_VL_1_8;
    public event Action AE_Owl_VL_1_9;

    public event Action AE_Owl_VL_2_1;
    public event Action AE_Owl_VL_2_2;
    public event Action AE_Owl_VL_2_3;
    public event Action AE_Owl_VL_2_4;
    public event Action AE_Owl_VL_2_5;

    public event Action AE_Owl_VL_3_1;
    public event Action AE_Owl_VL_3_2;
    public event Action AE_Owl_VL_3_3;
    public event Action AE_Owl_VL_3_4;
    public event Action AE_Owl_VL_3_5;
    public event Action AE_Owl_VL_3_6;

    public event Action AE_Owl_VL_Ending;

    #endregion

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

    #region Audio Events Activation

    //Audio Events Activation
    public void ShootAudioEvent_Player_WitchSenses_On()
    {
        AE_Player_WitchSenses_On();
    }

    public void ShootAudioEvent_Player_WitchSenses_Off()
    {
        AE_Player_WitchSenses_Off();
    }

    public void ShootAudioEvent_Owl_VL_T_1_1()
    {
        if (AE_Owl_VL_T_1_1 != null)
        {
            AE_Owl_VL_T_1_1();
        }
    }
    public void ShootAudioEvent_Owl_VL_T_1_2()
    {
        AE_Owl_VL_T_1_2();
    }
    public void ShootAudioEvent_Owl_VL_T_1_3()
    {
        AE_Owl_VL_T_1_3();
    }
    public void ShootAudioEvent_Owl_VL_T_2_1()
    {
        AE_Owl_VL_T_2_1();
    }
    public void ShootAudioEvent_Owl_VL_T_2_2()
    {
        AE_Owl_VL_T_2_2();
    }
    public void ShootAudioEvent_Owl_VL_T_2_3()
    {
        AE_Owl_VL_T_2_3();
    }
    public void ShootAudioEvent_Owl_VL_T_2_4()
    {
        AE_Owl_VL_T_2_4();
    }
    public void ShootAudioEvent_Owl_VL_T_3_1()
    {
        AE_Owl_VL_T_3_1();
    }
    public void ShootAudioEvent_Owl_VL_T_3_2()
    {
        AE_Owl_VL_T_3_2();
    }
    public void ShootAudioEvent_Owl_VL_T_4_1()
    {
        AE_Owl_VL_T_4_1();
    }
    public void ShootAudioEvent_Owl_VL_T_4_2()
    {
        AE_Owl_VL_T_4_2();
    }
    public void ShootAudioEvent_Owl_VL_T_5_1()
    {
        AE_Owl_VL_T_5_1();
    }
    public void ShootAudioEvent_Owl_VL_T_5_2()
    {
        AE_Owl_VL_T_5_2();
    }
    public void ShootAudioEvent_Owl_VL_T_5_3()
    {
        AE_Owl_VL_T_5_3();
    }
    public void ShootAudioEvent_Owl_VL_T_5_4()
    {
        if (AE_Owl_VL_T_5_4 != null)
        {
            AE_Owl_VL_T_5_4();
        }
    }
    public void ShootAudioEvent_Owl_VL_T_6_1()
    {
        if (AE_Owl_VL_T_6_1 != null)
        {
            AE_Owl_VL_T_6_1();
        }
    }
    public void ShootAudioEvent_Owl_VL_T_6_2()
    {
        AE_Owl_VL_T_6_2();
    }
    public void ShootAudioEvent_Owl_VL_T_6_3()
    {
        AE_Owl_VL_T_6_3();
    }
    public void ShootAudioEvent_Owl_VL_T_6_4()
    {
        AE_Owl_VL_T_6_4();
    }
    public void ShootAudioEvent_Owl_VL_T_6_5()
    {
        AE_Owl_VL_T_6_5();
    }

    public void ShootAudioEvent_Owl_VL_1_1()
    {
        AE_Owl_VL_1_1();
    }
    public void ShootAudioEvent_Owl_VL_1_2()
    {
        AE_Owl_VL_1_2();
    }
    public void ShootAudioEvent_Owl_VL_1_3()
    {
        AE_Owl_VL_1_3();
    }
    public void ShootAudioEvent_Owl_VL_1_4()
    {
        AE_Owl_VL_1_4();
    }
    public void ShootAudioEvent_Owl_VL_1_5()
    {
        AE_Owl_VL_1_5();
    }
    public void ShootAudioEvent_Owl_VL_1_6()
    {
        AE_Owl_VL_1_6();
    }
    public void ShootAudioEvent_Owl_VL_1_7()
    {
        AE_Owl_VL_1_7();
    }
    public void ShootAudioEvent_Owl_VL_1_8()
    {
        AE_Owl_VL_1_8();
    }
    public void ShootAudioEvent_Owl_VL_1_9()
    {
        AE_Owl_VL_1_9();
    }
    public void ShootAudioEvent_Owl_VL_2_1()
    {
        AE_Owl_VL_2_1();
    }
    public void ShootAudioEvent_Owl_VL_2_2()
    {
        AE_Owl_VL_2_2();
    }
    public void ShootAudioEvent_Owl_VL_2_3()
    {
        AE_Owl_VL_2_3();
    }
    public void ShootAudioEvent_Owl_VL_2_4()
    {
        AE_Owl_VL_2_4();
    }
    public void ShootAudioEvent_Owl_VL_2_5()
    {
        AE_Owl_VL_2_5();
    }
    public void ShootAudioEvent_Owl_VL_3_1()
    {
        AE_Owl_VL_3_1();
    }
    public void ShootAudioEvent_Owl_VL_3_2()
    {
        AE_Owl_VL_3_2();
    }
    public void ShootAudioEvent_Owl_VL_3_3()
    {
        AE_Owl_VL_3_3();
    }
    public void ShootAudioEvent_Owl_VL_3_4()
    {
        AE_Owl_VL_3_4();
    }
    public void ShootAudioEvent_Owl_VL_3_5()
    {
        AE_Owl_VL_3_5();
    }
    public void ShootAudioEvent_Owl_VL_3_6()
    {
        AE_Owl_VL_3_6();
    }
    public void ShootAudioEvent_Owl_VL_Ending()
    {
        AE_Owl_VL_Ending();
    }

    #endregion
}
