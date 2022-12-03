using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnStartDisabler : MonoBehaviour
{
    void Start()
    {
        //This is done to allow processes before start (Awake/OnEnable etc.) to take place and then disable the gameobject "from the get go" but not from the very beginning
        Invoke("Disable", 0.25f);
    }

    private void Disable()
    {
        gameObject.SetActive(false);
    }
}
