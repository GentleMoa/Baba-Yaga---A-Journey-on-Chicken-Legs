using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbDownLadder : MonoBehaviour
{
    //Serialized Variables
    [SerializeField] private Transform climbingExitInForest;

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

            //Button Animation
            //Trapdoor Animation plays
            //Screen fades to black
            //Climbing noises are heard

            //Fire Climbing Signifier Event
            ClimbingLadderDown();

            //Teleport
            _player.transform.position = climbingExitInForest.transform.position;

            //Screen fades from black
            //Trapdoor Animation plays in reverse

            //After Climbing is finished
            _isClimbing = false;
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
}
