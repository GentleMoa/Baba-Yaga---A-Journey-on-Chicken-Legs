using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleLookAtUser : MonoBehaviour
{
    //Private Variables
    private Transform _playerTransform;

    void Start()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    void Update()
    {
        if (_playerTransform != null && this.gameObject.activeSelf == true)
        {
            transform.LookAt(_playerTransform);
        }
    }
}
