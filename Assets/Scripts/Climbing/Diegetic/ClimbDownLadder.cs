using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbDownLadder : MonoBehaviour
{
    //Serialized Variables
    [SerializeField] private Transform climbingExitInForest;
    [SerializeField] private FadeTransitions fadeScript;
    [SerializeField] private Animator houseAnimator;
    [SerializeField] private Animator entranceMechAnimator;
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private Stage_T_5_3 stage_T_5_3;

    //Private Variables
    private GameObject _player;
    private bool _isClimbing = false;
    private Vector3 _buttonStartPosition;
    private Vector3 _buttonStartRotation;

    //Events
    public event Action ClimbingLadderDown;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    public void ClimbingDown()
    {
        if (_isClimbing == false)
        {
            //When Climbing is initiated
            _isClimbing = true;

            //Entrance Mechanism Animation
            entranceMechAnimator.SetTrigger("Opening");

            //Delay of 11 Secs (to start Trapdoor Animation when Entrance Mech Anim is mostly finished)
            Invoke("NestedClimbDownFunction_0", 11.0f);
        }
    }

    //Called in "HouseAnimEvent_SaveRungResetPos" on GameObject "Animated House" via Animation Event
    public void SaveInteractableStartPos()
    {
        //Saving the initial transform values of this object
        _buttonStartPosition = this.transform.position;
        _buttonStartRotation = this.transform.rotation.eulerAngles;
    }

    //Called on GameObject Button via XR Interactable Event
    public void ResetInteractablePosition()
    {
        //Resetting the transforms to the original values
        this.gameObject.transform.position = _buttonStartPosition;
        this.gameObject.transform.rotation = Quaternion.Euler(_buttonStartRotation);
    }

    private void NestedClimbDownFunction_0()
    {
        //Trapdoor Animation plays
        houseAnimator.SetTrigger("OpenTrapdoor");
        //Trapdoor Audio Close is played
        AudioManager.Instance.ShootAudioEvent_Trapdoor_Open();
        //Delay of 3 sec (while anim and audio are playing)
        Invoke("NestedClimbDownFunction_1", 3.0f);
    }
    private void NestedClimbDownFunction_1()
    {
        //Screen fades to black
        fadeScript.Fade(true);

        //Delay of 2 sec (wait while fade effect is playing)
        Invoke("NestedClimbDownFunction_2", 2.0f);
    }
    private void NestedClimbDownFunction_2()
    {
        //Climbing noises are heard
        AudioManager.Instance.ShootAudioEvent_Ladder_Climbing();

        //Delay of 3 sec (while climbing audio is played)
        Invoke("NestedClimbDownFunction_3", 3.0f);
    }
    private void NestedClimbDownFunction_3()
    {
        //Fire Climbing Signifier Event
        ClimbingLadderDown();

        //Teleport
        _player.transform.position = climbingExitInForest.transform.position;

        //Screen fades from black
        fadeScript.Fade(false);

        //Delay of 2 sec (wait while fade effect is playing)
        Invoke("NestedClimbDownFunction_4", 2.0f);
    }
    private void NestedClimbDownFunction_4()
    {
        //Trapdoor Animation plays in reverse
        houseAnimator.SetTrigger("CloseTrapdoor");

        //Trapdoor Audio Close is played
        AudioManager.Instance.ShootAudioEvent_Trapdoor_Close();

        //After Climbing is finished
        _isClimbing = false;

        //Delay of 2 secs (while anim and audio are playing)
        Invoke("NestedClimbDownFunction_5", 2.0f);
    }

    private void NestedClimbDownFunction_5()
    {
        //Toggle respective stage advancements after climbing up
        stage_T_5_3.ToggleStageAdvancingFlag();
    }
}
