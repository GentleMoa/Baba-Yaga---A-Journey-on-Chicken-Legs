using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyInPlaceHolder : MonoBehaviour
{
    //Serialized Variables
    [SerializeField] private GameObject[] stasisObjects;

    void Start()
    {
        //Call ToggleRigidbodyStasis to enable stasis in the beginning
        ToggleRigidbodyStasis(true);
    }

    private void ToggleRigidbodyStasis(bool putInStasis)
    {
        for (int i = 0; i < stasisObjects.Length; i++)
        {
            if (stasisObjects[i].GetComponent<Rigidbody>() != null)
            {
                //Toggle isKinematc to put all objects of this array into a "stasis"
                stasisObjects[i].GetComponent<Rigidbody>().isKinematic = putInStasis;
            }
        }
    }

    public void DisableRigidbodyStasis()
    {
        ToggleRigidbodyStasis(false);
    }
}
