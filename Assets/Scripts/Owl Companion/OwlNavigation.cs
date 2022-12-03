using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OwlNavigation : MonoBehaviour
{
    //Private Variables
    private NavMeshAgent _navMeshAgent;
    private GameObject _player;
    public float distToPlayer;

    //Serialized Variables
    [SerializeField] private GameObject staticOwl;

    void Start()
    {
        //Get reference to private variables
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _player = GameObject.FindGameObjectWithTag("Player");

        //Set stopping distance of NavMeshAgent component to keep some distance between player and owl
        _navMeshAgent.stoppingDistance = 1.0f;
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
        distToPlayer = Mathf.Sqrt((transform.position - _player.transform.position).sqrMagnitude);

        if (distToPlayer > 0.75f)
        {
            _navMeshAgent.SetDestination(_player.transform.position);
        }
    }

    public void ToggleNavOwl(bool navOwlActive)
    {
        if (navOwlActive)
        {
            //Enable the Nav Owl
            gameObject.SetActive(true);

            //Disable the Static Owl
            staticOwl.SetActive(false);
        }
        else
        {
            //Disable the Nav Owl
            gameObject.SetActive(false);

            //Enable the Static Owl
            staticOwl.SetActive(true);
        }
    }
}
