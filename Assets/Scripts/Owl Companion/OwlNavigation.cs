using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OwlNavigation : MonoBehaviour
{
    //Private Variables
    private NavMeshAgent _navMeshAgent;
    private GameObject _player;
    private float _distToPlayer;
    private Animator _animator;
    private bool _inMotion;

    void Start()
    {
        //Get reference to private variables
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _player = GameObject.FindGameObjectWithTag("Player");
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        //This conditions results in the following code being executed only every 10th frame to save performance (Alternatively use InvokeRepeating or a Coroutine for a similar result)
        if (Time.frameCount % 10 == 0)
        {
            //Call FollowPlayerBehavior function that handles navigation
            FollowPlayerBehavior();
        }
    }

    private void FollowPlayerBehavior()
    {
        //Getting the squared magnitude (aka the distance from the owl to the player), this is a little more performant than writing Vector3.Distance(transform.position - _player.transform.position);
        _distToPlayer = Mathf.Sqrt((transform.position - _player.transform.position).sqrMagnitude);

        //If the player is farther away than 1.5 meters...
        if (_distToPlayer > 1.5f)
        {
            //Steer towards the player
            _navMeshAgent.SetDestination(_player.transform.position);
        }

        //If the NavMeshAgent is moved at all...
        if (_navMeshAgent.velocity.sqrMagnitude > 0.0f)
        {
            //...Trigger the flying in motion animation
            if (_inMotion == false)
            {
                _inMotion = true;
                _animator.SetBool("Bool_Flying", true);
            }
        }
        //If the NavMeshAgent is completely still...
        else
        {
            //...Trigger the flying idle animation
            if (_inMotion == true)
            {
                _inMotion = false;
                _animator.SetBool("Bool_Flying", false);
            }
        }
    }
}
