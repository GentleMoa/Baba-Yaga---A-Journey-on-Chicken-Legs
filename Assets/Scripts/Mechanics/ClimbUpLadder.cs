//A script used for a suggested climbing action, when grabbing onto one of the lower ladder rungs, which teleports the player into the house above
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbUpLadder : MonoBehaviour
{
    //Serialized Variables
    [SerializeField] private Transform climbingExitInHouse;

    //Private Variables
    private GameObject _player;
    private bool _isClimbing = false;
    private Vector3 _ladderRungStartPosition;
    private Vector3 _ladderRungStartRotation;

    //Events
    public event Action ClimbingLadderUp;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    public void ClimbingUp()
    {
        if (_isClimbing == false)
        {
            //When Climbing is initiated
            _isClimbing = true;

            //Trapdoor Animation plays
            //Screen fades to black
            //Climbing noises are heard

            //Fire Climbing Signifier Event
            ClimbingLadderUp();

            //Teleport
            _player.transform.position = climbingExitInHouse.transform.position;

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
}
