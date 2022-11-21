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

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        //Saving the initial transform values of this object
        _buttonStartPosition = this.transform.position;
        _buttonStartRotation = this.transform.rotation.eulerAngles;
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

            //Teleport
            _player.transform.position = climbingExitInForest.transform.position;

            //Screen fades from black
            //Trapdoor Animation plays in reverse

            //After Climbing is finished
            _isClimbing = false;
        }
    }

    public void ResetInteractablePosition()
    {
        //Resetting the transforms to the original values
        this.gameObject.transform.position = _buttonStartPosition;
        this.gameObject.transform.rotation = Quaternion.Euler(_buttonStartRotation);
    }
}
