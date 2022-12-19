//A script used for a suggested climbing action, when grabbing onto one of the lower ladder rungs, which teleports the player into the house above
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbUpLadder : MonoBehaviour
{
    //Serialized Variables
    [SerializeField] private Transform climbingExitInHouse;
    [SerializeField] private FadeTransitions fadeScript;
    [SerializeField] private Animator houseAnimator;
    [SerializeField] private Animator entranceMechAnimator;
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private Stage_T_5_2 stage_T_5_2;
    [SerializeField] private Stage_1_6 stage_1_6;
    [SerializeField] private Stage_3_3 stage_3_3;

    //Private Variables
    private GameObject _player;
    private bool _isClimbing = false;
    private Vector3 _ladderRungStartPosition;
    private Vector3 _ladderRungStartRotation;
    private AudioClip _audioClip_TrapdoorOpen;
    private AudioClip _audioClip_TrapdoorClose;
    private AudioClip _audioClip_LadderClimbing;

    //Events
    public event Action ClimbingLadderUp;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");

        //Subscribe to AudioEvents
        AudioManager.Instance.AE_Trapdoor_Open += Play_Audio_TrapdoorOpen;
        AudioManager.Instance.AE_Trapdoor_Close += Play_Audio_TrapdoorClose;
        AudioManager.Instance.AE_Ladder_Climbing += Play_Audio_LadderClimbing;

        //Get AudioClips from ResourceManager
        _audioClip_TrapdoorOpen = ResourceManager.Instance.audio_trapdoor_open;
        _audioClip_TrapdoorClose = ResourceManager.Instance.audio_trapdoor_close;
        _audioClip_LadderClimbing = ResourceManager.Instance.audio_ladder_climbing;
    }

    public void ClimbingUp()
    {
        if (_isClimbing == false)
        {
            //When Climbing is initiated (flag condition to prevent multiple callings of this function)
            _isClimbing = true;

            //Trapdoor Animation plays
            houseAnimator.SetTrigger("OpenTrapdoor");
            //Trapdoor Audio Open is played
            AudioManager.Instance.ShootAudioEvent_Trapdoor_Open();

            //Delay of 2 sec (while anim and audio are playing)
            Invoke("NestedClimbUpFunction_0", 2.0f);
        }
    }

    //Called in "HouseAnimEvent_SaveRungResetPos" on GameObject "Animated House" via Animation Event
    public void SaveInteractableStartPos()
    {
        //Saving the initial transform values of this object
        _ladderRungStartPosition = this.transform.position;
        _ladderRungStartRotation = this.transform.rotation.eulerAngles;
    }

    //Called on GameObject Button via XR Interactable Event
    public void ResetInteractablePosition()
    {
        //Resetting the transforms to the original values
        this.gameObject.transform.position = _ladderRungStartPosition;
        this.gameObject.transform.rotation = Quaternion.Euler(_ladderRungStartRotation);
    }

    //Audio Functions
    private void Play_Audio_TrapdoorOpen()
    {
        audioSource.clip = _audioClip_TrapdoorOpen;
        audioSource.Play();
    }

    private void Play_Audio_TrapdoorClose()
    {
        audioSource.clip = _audioClip_TrapdoorClose;
        audioSource.Play();
    }

    private void Play_Audio_LadderClimbing()
    {
        audioSource.clip = _audioClip_LadderClimbing;
        audioSource.Play();
    }

    private void OnDisable()
    {
        //Unsubscribe from AudioEvents
        AudioManager.Instance.AE_Trapdoor_Open -= Play_Audio_TrapdoorOpen;
        AudioManager.Instance.AE_Trapdoor_Close -= Play_Audio_TrapdoorClose;
        AudioManager.Instance.AE_Ladder_Climbing -= Play_Audio_LadderClimbing;
    }


    private void NestedClimbUpFunction_0()
    {
        //Screen fades to black
        fadeScript.Fade(true);

        //Delay of 2 Sec (wait while fade effect is playing)
        Invoke("NestedClimbUpFunction_1", 2.0f);
    }

    private void NestedClimbUpFunction_1()
    {
        //Climbing noises are heard
        AudioManager.Instance.ShootAudioEvent_Ladder_Climbing();

        //Delay of 3 sec (while climbing audio is played)
        Invoke("NestedClimbUpFunction_2", 3.0f);
    }

    private void NestedClimbUpFunction_2()
    {
        //Fire Climbing Signifier Event (used by "ObjectToggler" Script)
        ClimbingLadderUp();

        //Teleport the user up into the house
        _player.transform.position = climbingExitInHouse.transform.position;

        //Screen fades from black
        fadeScript.Fade(false);

        //Delay of 2 sec (wait while fade effect is playing)
        Invoke("NestedClimbUpFunction_3", 2.0f);
    }

    private void NestedClimbUpFunction_3()
    {
        //Trapdoor Animation plays in reverse
        houseAnimator.SetTrigger("CloseTrapdoor");

        //Trapdoor Audio Close is played
        AudioManager.Instance.ShootAudioEvent_Trapdoor_Close();

        //Entering Mechanism Animation plays (closing/in reverse)
        entranceMechAnimator.SetTrigger("Closing");

        //After Climbing is finished
        _isClimbing = false;

        //After 2 sec delay (to finish anims & audio)
        Invoke("NestedClimbUpFunction_4", 2.0f);
    }


    private void NestedClimbUpFunction_4()
    {
        //Toggle respective stage advancements after climbing up
        if (StageManager.Instance.currentStage == stage_T_5_2)
        {
            stage_T_5_2.ToggleStageAdvancingFlag();
        } 
        else if (StageManager.Instance.currentStage == stage_1_6)
        {
            stage_1_6.ToggleStageAdvancingFlag();
        }
        else if (StageManager.Instance.currentStage == stage_3_3)
        {
            stage_3_3.ToggleStageAdvancingFlag();
        }
        else
        {
            //Do nothing
        }
    }
}
